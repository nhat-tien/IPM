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
  import transformAidTypeToTable from "@useCases/aidTypeUseCase/transformAidTypeToTable";
  import createAidType from "@useCases/aidTypeUseCase/createAidType";
  import { ZodError, type ZodIssue } from "zod";
  import type { PageData } from "./$types";
  import type { EventSubmitElements } from "@/shared.types";
  import { invalidate } from "$app/navigation";
  import Row from "@components/Row/Row.svelte";
  import type { AidType } from "@useCases/useCases.types";
  import MessageBoxConfirm from "@components/MessageBox/MessageBoxConfirm.svelte";
  import deleteAidType from "@useCases/aidTypeUseCase/deleteAidType";
  import updateAidType from "@useCases/aidTypeUseCase/updateAidType";
  import SingleFieldCreateModal from "@components/Modal/CreateModal/SingleFieldCreateModal.svelte";
  import RowSkeleton from "@components/Skeleton/RowSkeleton.svelte";
  import Container from "@components/Container/Container.svelte";

  type AidTypeUpdateDto = Omit<AidType, "createdAt" | "updatedAt">;
  let { data }: { data: PageData } = $props();

  let modelName = "Loại viện trợ";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Tên ${modelName.toLowerCase()}`,
  ];
  let error: ZodIssue[] = $state([]);
  let selectedModel: AidTypeUpdateDto | null = $state(null);

  function resetError() {
    error = [];
  }

  function selectModel(model: any[]) {
    selectedModel = {
      aidTypeId: model[0],
      aidTypeName: model[1],
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
    const result = await updateAidType(formData, selectedModel?.aidTypeId);

    if (result.isSuccess) {
      toast.success("Cập nhật thành công");
      invalidate("aidType:getAll");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }
  async function onDelete() {
    if (selectedModel == null) return;

    const result = await deleteAidType(selectedModel.aidTypeId);

    if (result.isSuccess) {
      toast.success("Xóa thành công");
      invalidate("aidType:getAll");
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
  <Row --justify-content="flex-end">
    <PrimaryButton
      onclick={(e) => {
        e.stopPropagation();
        openModal(createModal);
      }}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </Row>
  <Container>
    <Row --padding="1em 1em 1em 1.5em"></Row>
    <Table hasAction {headers}>
      {#await data.aidType}
        <RowSkeleton {headers} />
      {:then aidTypes}
        {#each transformAidTypeToTable(aidTypes) as aidType}
          <TableRow
            row={aidType}
            onDelete={() => openConfirmDelete(aidType)}
            onEdit={() => openUpdateModal(aidType)}
          />
        {/each}
      {/await}
    </Table>
    <Row --padding="1em 1em 1em 1.5em"></Row>
  </Container>
</BasicCenterLayout>

{#snippet createModal()}
  <SingleFieldCreateModal
    title={`Thêm ${modelName.toLowerCase()}`}
    label={`Tên ${modelName.toLowerCase()}`}
    placeHolder={`Vui lòng nhập tên ${modelName.toLowerCase()}`}
    fieldName="aidTypeName"
    invalidateStr="aidType:getAll"
    successMessage="Thêm thành công"
    createFn={createAidType}
  />
{/snippet}

{#snippet updateModal()}
  <div class="modal">
    <h4>Chỉnh sửa {modelName.toLowerCase()}</h4>
    <form onsubmit={onUpdate}>
      <PrimaryTextField
        id="aidTypeName"
        name="aidTypeName"
        type="text"
        placeHolder=""
        label={`Tên ${modelName.toLowerCase()}`}
        --margin-top="1em"
        --margin-bottom="1em"
        required
        {error}
        errorId="aidTypeName"
        value={selectedModel?.aidTypeName}
        onfocus={resetError}
      ></PrimaryTextField>
      <Row>
        <PrimaryButton variant="orange" type="submit">Lưu</PrimaryButton>
        <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
      </Row>
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
