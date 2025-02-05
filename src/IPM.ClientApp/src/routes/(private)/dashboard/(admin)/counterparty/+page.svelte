<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import { closeModal, openModal } from "@stores/modal.svelte";
  import toast from "svelte-5-french-toast";
  import { ZodError, type ZodIssue } from "zod";
  import type { PageData } from "./$types";
  import type { EventSubmitElements } from "@/shared.types";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import { invalidate } from "$app/navigation";
  import RowToLeft from "@components/Row/RowToLeft.svelte";
  import transformCounterpartyToTable from "@useCases/counterpartyUseCase/transformCounterpartyToTable";
  import createCounterparty from "@useCases/counterpartyUseCase/createCounterparty";
  import type { Counterparty } from "@useCases/useCases.types";
  import MessageBoxConfirm from "@components/MessageBox/MessageBoxConfirm.svelte";
  import updateCounterparty from "@useCases/counterpartyUseCase/updateCounterparty";
  import deleteCounterparty from "@useCases/counterpartyUseCase/deleteCounterparty";
  import SingleFieldCreateModal from "@components/Modal/CreateModal/SingleFieldCreateModal.svelte";

  type CounterpartyUpdateDto = Omit<Counterparty, "createdAt" | "updatedAt">;
  let { data }: { data: PageData } = $props();

  let modelName = "Đối tác";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Tên ${modelName.toLowerCase()}`,
  ];
  let error: ZodIssue[] = $state([]);
  let selectedModel: CounterpartyUpdateDto | null = $state(null);

  function resetError() {
    error = [];
  }

  function selectModel(model: any[]) {
    selectedModel = {
      counterpartyId: model[0],
      counterpartyName: model[1],
    };
  }

  function openUpdateModal(model: any[]) {
    selectModel(model);
    openModal(updateModal);
  }

  function openConfirmDelete(model: any[]) {
    selectModel(model);
    openModal(confirmDelete);
  }

  async function onUpdate(e: EventSubmitElements) {
    e.preventDefault();

    if (selectedModel == null) return;

    const formData = new FormData(e.target as HTMLFormElement);
    const result = await updateCounterparty(
      formData,
      selectedModel?.counterpartyId,
    );

    if (result.isSuccess) {
      toast.success("Cập nhật thành công");
      invalidate("counterparty:getAll");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  async function onDelete() {
    if (selectedModel == null) return;

    const result = await deleteCounterparty(selectedModel.counterpartyId);

    if (result.isSuccess) {
      toast.success("Xóa thành công");
      invalidate("counterparty:getAll");
      closeModal();
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }
</script>

<TitleWebPage title={modelName} />
<BasicCenterLayout header={modelName} breadcrumb={[modelName, "Danh sách"]}>
  <RowToRight>
    <PrimaryButton
      onclick={() => {
        resetError();
        openModal(createModal);
      }}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </RowToRight>
  <Table hasAction {headers}>
    {#await data.counterparty}
      <div>Loading</div>
    {:then counterpartys}
      {#each transformCounterpartyToTable(counterpartys) as counterparty}
        <TableRow
          row={counterparty}
          onDelete={() => openConfirmDelete(counterparty)}
          onEdit={() => openUpdateModal(counterparty)}
        />
      {/each}
    {/await}
  </Table>
</BasicCenterLayout>

{#snippet createModal()}
  <SingleFieldCreateModal
    title={`Thêm ${modelName.toLowerCase()}`}
    label={`Tên ${modelName.toLowerCase()}`}
    placeHolder={`Vui lòng nhập tên ${modelName.toLowerCase()}`}
    fieldName="counterpartyName"
    invalidateStr="counterparty:getAll"
    successMessage="Thêm thành công"
    createFn={createCounterparty}
  />
{/snippet}

{#snippet updateModal()}
  <div class="modal">
    <h4>Chỉnh sửa {modelName.toLowerCase()}</h4>
    <form onsubmit={onUpdate}>
      <PrimaryTextField
        id="counterpartyName"
        name="counterpartyName"
        type="text"
        placeHolder=""
        label={`Tên ${modelName.toLowerCase()}`}
        --margin-top="1em"
        --margin-bottom="1em"
        required
        value={selectedModel?.counterpartyName}
        {error}
        errorId="counterpartyName"
        onfocus={resetError}
      ></PrimaryTextField>
      <RowToLeft>
        <PrimaryButton variant="orange" type="submit">Lưu</PrimaryButton>
        <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
      </RowToLeft>
    </form>
  </div>
{/snippet}

{#snippet confirmDelete()}
  <MessageBoxConfirm
    title="Bạn có chắc muốn xóa?"
    onYes={() => onDelete()}
    onNo={() => closeModal()}
  />
{/snippet}

<style lang="scss">
  form {
    display: flex;
    flex-direction: column;
  }
</style>
