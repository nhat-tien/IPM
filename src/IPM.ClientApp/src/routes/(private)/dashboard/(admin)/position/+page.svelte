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
  import transformPositionToTable from "@useCases/positionUseCase/transformPositionToTable";
  import createPosition from "@useCases/positionUseCase/createPosition";
  import type { Position } from "@useCases/useCases.types";
  import updatePosition from "@useCases/positionUseCase/updatePosition";
  import deletePosition from "@useCases/positionUseCase/deletePosition";
  import MessageBoxConfirm from "@components/MessageBox/MessageBoxConfirm.svelte";

  type PositionUpdateDto = Omit<Position, "createdAt" | "updatedAt">;
  let { data }: { data: PageData } = $props();
  let selectedModel: PositionUpdateDto | null = $state(null);

  let modelName = "Chức vụ";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Tên ${modelName.toLowerCase()}`,
  ];
  let error: ZodIssue[] = $state([]);

  function resetError() {
    error = [];
  }

  function selectModel(model: any[]) {
    selectedModel = {
      positionId: model[0],
      positionName: model[1],
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

  async function onCreate(e: EventSubmitElements) {
    e.preventDefault();

    const formData = new FormData(e.target as HTMLFormElement);
    const result = await createPosition(formData);

    if (result.isSuccess) {
      toast.success("Thêm thành công");
      invalidate("position:getAll");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  async function onUpdate(e: EventSubmitElements) {
    e.preventDefault();

    if (selectedModel == null) return;

    const formData = new FormData(e.target as HTMLFormElement);
    const result = await updatePosition(formData, selectedModel?.positionId);

    if (result.isSuccess) {
      toast.success("Cập nhật thành công");
      invalidate("position:getAll");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  async function onDelete() {
    if (selectedModel == null) return;

    const result = await deletePosition(selectedModel.positionId);

    if (result.isSuccess) {
      toast.success("Xóa thành công");
      invalidate("position:getAll");
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
    {#await data.position}
      <div>Loading</div>
    {:then positions}
      {#each transformPositionToTable(positions) as position}
        <TableRow
          row={position}
          onDelete={() => openConfirmDelete(position)}
          onEdit={() => openUpdateModal(position)}
        />
      {/each}
    {/await}
  </Table>
</BasicCenterLayout>

{#snippet createModal()}
  <div class="modal">
    <h4>Thêm {modelName.toLowerCase()}</h4>
    <form onsubmit={onCreate}>
      <PrimaryTextField
        id="positionName"
        name="positionName"
        type="text"
        placeHolder=""
        label={`Tên ${modelName.toLowerCase()}`}
        --margin-top="1em"
        --margin-bottom="1em"
        {error}
        errorId="positionName"
        onfocus={resetError}
      ></PrimaryTextField>
      <RowToLeft>
        <PrimaryButton variant="orange" type="submit">Thêm</PrimaryButton>
        <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
      </RowToLeft>
    </form>
  </div>
{/snippet}

{#snippet updateModal()}
  <div class="modal">
    <h4>Chỉnh sửa {modelName.toLowerCase()}</h4>
    <form onsubmit={onUpdate}>
      <PrimaryTextField
        id="positionName"
        name="positionName"
        type="text"
        placeHolder=""
        label={`Tên ${modelName.toLowerCase()}`}
        --margin-top="1em"
        --margin-bottom="1em"
        required
        value={selectedModel?.positionName}
        {error}
        errorId="positionName"
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
