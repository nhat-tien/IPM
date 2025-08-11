<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import Row from "@components/Row/Row.svelte";
  import PrimaryTextFieldBindable from "@components/TextField/PrimaryTextFieldBindable.svelte";
  import transformCategoryToOption from "@useCases/categoryUseCase/transformCategoryToOption";
  import type { PageData } from "./$types";
  import createProject from "@useCases/projectUseCase/createProject";
  import { ZodError, type ZodIssue } from "zod";
  import toast from "svelte-5-french-toast";
  import { goto, invalidate } from "$app/navigation";
  import SelectWithSearch from "@components/Select/SelectWithSearch.svelte";
  import { page } from "$app/state";
    import transformAffiliatedUnitToOption from "@useCases/affiliatedUnitUseCase/transformAffliatedUnitToOption";
    import { invalidateCache } from "@stores/cache.svelte";

  let { data }: { data: PageData } = $props();
  let error: ZodIssue[] = $state([]);

  let modelState: {
    projectNameVietnamese: string;
    projectNameEnglish: string;
    affiliatedUnitId: string;
  } = $state({
    projectNameVietnamese: "",
    projectNameEnglish: "",
    affiliatedUnitId: "",
  });

  async function onCreate() {
    const result = await createProject(modelState);
    if (result.isSuccess) {
      toast.success("Tạo dự án thành công");
      invalidateCache("my-project")
      resetForm();

      if(page.url.searchParams.get("redirect") == "all-project") {
        goto("/dashboard/all-project");
      } else {
        goto("/dashboard/project");
      }
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  function clearError() {
    error = [];
  }

  function resetForm() {
    modelState.projectNameVietnamese = "";
    modelState.projectNameEnglish = "";
    modelState.affiliatedUnitId = "";
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
      {#await data.affliatedUnit}
      <div>Loading</div>
      {:then affliatedUnits}
      <SelectWithSearch 
        label="Đơn vị trực thuộc"
        required
        items={transformAffiliatedUnitToOption(affliatedUnits)}
        placeHolder="Chọn đơn vị trực thuộc"
        selectFn={(e) => modelState.affiliatedUnitId = e ? e.value : ""}
        --margin-top="1em"
      />
      {/await}
    <Row --justify-content="flex-end"  --margin-top="1rem">
      <PrimaryButton variant="orange" onclick={() => onCreate()}
        >Xác nhận</PrimaryButton
      >
    </Row >
  </div>
</BasicCenterLayout>

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
