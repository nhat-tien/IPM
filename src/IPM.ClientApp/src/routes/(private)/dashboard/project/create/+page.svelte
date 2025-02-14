<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import SelectWithCreateButton from "@components/Select/SelectWithCreateButton.svelte";
  import PrimaryTextFieldBindable from "@components/TextField/PrimaryTextFieldBindable.svelte";
  import SingleFieldCreateModal from "@components/Modal/CreateModal/SingleFieldCreateModal.svelte";
  import transformCategoryToOption from "@useCases/categoryUseCase/transformCategoryToOption";
  import createCategory from "@useCases/categoryUseCase/createCategory";
  import { openModal } from "@stores/modal.svelte";
  import type { PageData } from "./$types";
  import createProject from "@useCases/projectUseCase/createProject";
  import { ZodError, type ZodIssue } from "zod";
  import toast from "svelte-5-french-toast";
  import { invalidate } from "$app/navigation";

  let { data }: { data: PageData } = $props();
  let error: ZodIssue[] = $state([]);

  let modelState: {
    projectNameVietnamese: string;
    projectNameEnglish: string;
    categoryId: string;
  } = $state({
    projectNameVietnamese: "",
    projectNameEnglish: "",
    categoryId: "",
  });

  async function onCreate() {
    const result = await createProject(modelState);
    if (result.isSuccess) {
      toast.success("Tạo dự án thành công");
      invalidate("project:create");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  function clearError() {
    error = [];
  }
</script>

<TitleWebPage title="Tạo dự án mới" />
<BasicCenterLayout header="Tạo dự án mới" breadcrumb={["Dự án", "Tạo mới"]}>
  <div class="container">
    <h3>Thông tin dự án</h3>
    <PrimaryTextFieldBindable
      id="projectNameVietnamese"
      label="Tên dự án Tiếng Việt"
      placeHolder=""
      type="text"
      name="projectNameVietnamese"
      {error}
      errorId="projectNameVietnamese"
      onfocus={clearError}
      bind:value={modelState.projectNameVietnamese}
      --margin-top="1.5em"
      required
    />
    <PrimaryTextFieldBindable
      id="projectNameEnglish"
      label="Tên dự án Tiếng Anh"
      placeHolder=""
      type="text"
      name="projectNameEnglish"
      {error}
      errorId="projectNameEnglish"
      bind:value={modelState.projectNameEnglish}
      --margin-top="1em"
      required
    />
    <SelectWithCreateButton
      id="categoryId"
      items={[]}
      label="Danh mục"
      placeHolder=""
      --margin-top="1em"
      name="categoryId"
      {error}
      errorId="categoryId"
      bind:value={modelState.categoryId}
      onclick={() => openModal(createCategoryModal)}
      required
    >
      {#await data.category}
        <option value="">Loading</option>
      {:then categories}
        {#each transformCategoryToOption(categories) as category}
          <option
            value={category.value}
            selected={category.value == modelState.categoryId}
            >{category.name}</option
          >
        {/each}
      {/await}
    </SelectWithCreateButton>
    <RowToRight --margin-top="1rem">
      <PrimaryButton variant="orange" onclick={() => onCreate()}
        >Xác nhận</PrimaryButton
      >
    </RowToRight>
  </div>
</BasicCenterLayout>

{#snippet createCategoryModal()}
  <SingleFieldCreateModal
    title="Thêm danh mục"
    label="Tên danh mục"
    placeHolder="Vui lòng nhập tên danh mục"
    fieldName="categoryName"
    successMessage="Thêm thành công"
    invalidateStr="project:create"
    createFn={createCategory}
  />
{/snippet}

<style lang="scss">
  .container {
    display: flex;
    flex-direction: column;
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
  }
</style>
