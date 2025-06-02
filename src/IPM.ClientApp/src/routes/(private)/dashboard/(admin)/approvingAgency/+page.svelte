<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import MessageBoxConfirm from "@components/MessageBox/MessageBoxConfirm.svelte";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import RowToLeft from "@components/Row/RowToLeft.svelte";
  import { closeModal, openModal } from "@stores/modal.svelte";
  import toast from "svelte-5-french-toast";
  import updateApprovingAgency from "@useCases/approvingAgencyUseCase/updateApprovingAgency";
  import deleteApprovingAgency from "@useCases/approvingAgencyUseCase/deleteApprovingAgency";
  import { invalidate } from "$app/navigation";
  import createApprovingAgency from "@useCases/approvingAgencyUseCase/createApprovingAgency";
  import transformApprovingAgencyToTable from "@useCases/approvingAgencyUseCase/transformApprovingAgencyToTable";
  import { ZodError, type ZodIssue } from "zod";
  import type { PageData } from "./$types";
  import type { EventSubmitElements } from "@/shared.types";
  import type { ApprovingAgency } from "@useCases/useCases.types";
  import SingleFieldCreateModal from "@components/Modal/CreateModal/SingleFieldCreateModal.svelte";
  import RowSkeleton from "@components/Skeleton/RowSkeleton.svelte";

  type ApprovingAgencyUpdateDto = Omit<
    ApprovingAgency,
    "createdAt" | "updatedAt"
  >;
  let { data }: { data: PageData } = $props();

  let modelName = "Cơ quan phê duyệt";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Tên ${modelName.toLowerCase()}`,
  ];
  let error: ZodIssue[] = $state([]);
  let selectedModel: ApprovingAgencyUpdateDto | null = $state(null);

  function resetError() {
    error = [];
  }

  function selectModel(model: any[]) {
    selectedModel = {
      approvingAgencyId: model[0],
      approvingAgencyName: model[1],
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
    const result = await updateApprovingAgency(
      formData,
      selectedModel?.approvingAgencyId,
    );

    if (result.isSuccess) {
      toast.success("Cập nhật thành công");
      invalidate("approvingAgency:getAll");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  async function onDelete() {
    if (selectedModel == null) return;

    const result = await deleteApprovingAgency(selectedModel.approvingAgencyId);

    if (result.isSuccess) {
      toast.success("Xóa thành công");
      invalidate("approvingAgency:getAll");
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
      onclick={(e) => {
        e.stopPropagation();
        resetError();
        openModal(createModal);
      }}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </RowToRight>
  <Table {headers} hasAction>
    {#await data.approvingAgency}
      <RowSkeleton {headers} />
    {:then listData}
      {#each transformApprovingAgencyToTable(listData) as item}
        <TableRow
          row={item}
          onDelete={() => openConfirmDelete(item)}
          onEdit={() => openUpdateModal(item)}
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
    fieldName="approvingAgencyName"
    invalidateStr="approvingAgency:getAll"
    successMessage="Thêm thành công"
    createFn={createApprovingAgency}
  />
{/snippet}

{#snippet updateModal()}
  <div class="modal">
    <h4>Thêm {modelName.toLowerCase()}</h4>
    <form onsubmit={onUpdate}>
      <PrimaryTextField
        id="approvingAgencyName"
        name="approvingAgencyName"
        type="text"
        placeHolder=""
        label={`Tên ${modelName.toLowerCase()}`}
        --margin-top="1em"
        --margin-bottom="1em"
        required
        {error}
        errorId="approvingAgencyName"
        onfocus={resetError}
        value={selectedModel?.approvingAgencyName}
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
