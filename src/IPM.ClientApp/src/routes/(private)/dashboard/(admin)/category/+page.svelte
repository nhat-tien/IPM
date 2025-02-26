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
  import transformCategoryToTable from "@useCases/categoryUseCase/transformCategoryToTable";
  import createCategory from "@useCases/categoryUseCase/createCategory";
  import type { Category } from "@useCases/useCases.types";
  import updateCategory from "@useCases/categoryUseCase/updateCategory";
  import deleteCategory from "@useCases/categoryUseCase/deleteCategory";
  import MessageBoxConfirm from "@components/MessageBox/MessageBoxConfirm.svelte";
  import SingleFieldCreateModal from "@components/Modal/CreateModal/SingleFieldCreateModal.svelte";
    import TableSkeleton from "@components/Skeleton/TableSkeleton.svelte";

  let { data }: { data: PageData } = $props();

  type CategoryUpdateDto = Omit<Category, "createdAt" | "updatedAt">;

  let modelName = "Danh mục";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Tên ${modelName.toLowerCase()}`,
  ];
  let error: ZodIssue[] = $state([]);
  let selectedModel: CategoryUpdateDto | null = $state(null);

  function resetError() {
    error = [];
  }

  function selectModel(model: any[]) {
    selectedModel = {
      categoryId: model[0],
      categoryName: model[1],
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
    const result = await updateCategory(formData, selectedModel?.categoryId);

    if (result.isSuccess) {
      toast.success("Cập nhật thành công");
      invalidate("category:getAll");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  async function onDelete() {
    if (selectedModel == null) return;

    const result = await deleteCategory(selectedModel.categoryId);

    if (result.isSuccess) {
      toast.success("Xóa thành công");
      invalidate("category:getAll");
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
    {#await data.category}
      <TableSkeleton {headers} />
    {:then categorys}
      {#each transformCategoryToTable(categorys) as category}
        <TableRow
          row={category}
          onDelete={() => openConfirmDelete(category)}
          onEdit={() => openUpdateModal(category)}
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
    fieldName="categoryName"
    successMessage="Thêm thành công"
    invalidateStr="category:getAll"
    createFn={createCategory}
  />
{/snippet}

{#snippet updateModal()}
  <div class="modal">
    <h4>Chỉnh sửa {modelName.toLowerCase()}</h4>
    <form onsubmit={onUpdate}>
      <PrimaryTextField
        id="categoryName"
        name="categoryName"
        type="text"
        placeHolder=""
        label={`Tên ${modelName.toLowerCase()}`}
        --margin-top="1em"
        --margin-bottom="1em"
        {error}
        required
        value={selectedModel?.categoryName}
        errorId="categoryName"
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
