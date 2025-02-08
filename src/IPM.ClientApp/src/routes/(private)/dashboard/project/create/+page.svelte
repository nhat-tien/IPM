<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import SelectWithCreateButton from "@components/Select/SelectWithCreateButton.svelte";
  import PrimaryTextFieldBindable from "@components/TextField/PrimaryTextFieldBindable.svelte";
  import StepProgressBar from "@components/UniqueComponents/StepProgressBar.svelte";
  import type { PageData } from "./$types";
  import transformCategoryToOption from "@useCases/categoryUseCase/transformCategoryToOption";
  import transformSponsorToOption from "@useCases/sponsorUseCase/transformSponsorToOption";
  import transformAidTypeToOption from "@useCases/aidTypeUseCase/transformAidTypeToOption";
  import transformApprovingAgencyToOption from "@useCases/approvingAgencyUseCase/transformApprovingAgencyToOption";
  import transformCounterpartyToOption from "@useCases/counterpartyUseCase/transformCounterpartyToOption";
  import SingleFieldCreateModal from "@components/Modal/CreateModal/SingleFieldCreateModal.svelte";
  import createCategory from "@useCases/categoryUseCase/createCategory";
  import { openModal } from "@stores/modal.svelte";
  import createSponsor from "@useCases/sponsorUseCase/createSponsor";
  import createAidType from "@useCases/aidTypeUseCase/createAidType";
  import createApprovingAgency from "@useCases/approvingAgencyUseCase/createApprovingAgency";
  import createCounterparty from "@useCases/counterpartyUseCase/createCounterparty";

  let { data }: { data: PageData } = $props();
  let step: 1 | 2 | 3 = $state(1);
  let modelState = $state({
    projectNameVietnamese: "",
    projectNameEnglish: "",
    categoryId: "",
    sponsorId: "",
    aidTypeId: "",
    approvingAgencyId: "",
    counterPartyId: "",
  });
</script>

<TitleWebPage title="Tạo dự án mới" />
<BasicCenterLayout header="Tạo dự án mới" breadcrumb={["Dự án", "Tạo mới"]}>
  <StepProgressBar {step} />
  <div class="container">
    {#if step == 1}
      <h3>Thông tin dự án</h3>
      <PrimaryTextFieldBindable
        id="projectNameVietnamese"
        label="Tên dự án Tiếng Việt"
        placeHolder=""
        type="text"
        name="projectNameVietnamese"
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
        bind:value={modelState.categoryId}
        onclick={() => openModal(createCategoryModal)}
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
      <SelectWithCreateButton
        id="sponsorId"
        items={[]}
        label="Nhà tài trợ"
        placeHolder=""
        --margin-top="1em"
        name="sponsorId"
        bind:value={modelState.sponsorId}
        onclick={() => openModal(createSponsorModal)}
      >
        {#await data.sponsor}
          <option value="">Loading</option>
        {:then sponsors}
          {#each transformSponsorToOption(sponsors) as sponsor}
            <option
              value={sponsor.value}
              selected={sponsor.value == modelState.sponsorId}
              >{sponsor.name}</option
            >
          {/each}
        {/await}
      </SelectWithCreateButton>
      <SelectWithCreateButton
        id="aidTypeId"
        items={[]}
        label="Loại viện trợ"
        placeHolder=""
        --margin-top="1em"
        name="aidTypeId"
        bind:value={modelState.aidTypeId}
        onclick={() => openModal(createAidTypeModal)}
      >
        {#await data.aidType}
          <option value="">Loading</option>
        {:then aidTypes}
          {#each transformAidTypeToOption(aidTypes) as aidType}
            <option
              value={aidType.value}
              selected={aidType.value == modelState.aidTypeId}
              >{aidType.name}</option
            >
          {/each}
        {/await}
      </SelectWithCreateButton>
      <SelectWithCreateButton
        id="approvingAgencyId"
        items={[]}
        label="Cơ quan phê duyệt"
        placeHolder=""
        --margin-top="1em"
        name="approvingAgencyId"
        bind:value={modelState.approvingAgencyId}
        onclick={() => openModal(createApprovingAgencyModal)}
      >
        {#await data.approvingAgency}
          <option value="">Loading</option>
        {:then approvingAgencies}
          {#each transformApprovingAgencyToOption(approvingAgencies) as approvingAgency}
            <option
              value={approvingAgency.value}
              selected={approvingAgency.value == modelState.approvingAgencyId}
              >{approvingAgency.name}</option
            >
          {/each}
        {/await}
      </SelectWithCreateButton>
      <SelectWithCreateButton
        id="counterPartyId"
        items={[]}
        label="Đối tác thực hiện"
        placeHolder=""
        --margin-top="1em"
        name="counterPartyId"
        bind:value={modelState.counterPartyId}
        onclick={() => openModal(createCounterpartyModal)}
      >
        {#await data.counterParty}
          <option value="">Loading</option>
        {:then counterParties}
          {#each transformCounterpartyToOption(counterParties) as counterParty}
            <option
              value={counterParty.value}
              selected={counterParty.value == modelState.counterPartyId}
              >{counterParty.name}</option
            >
          {/each}
        {/await}
      </SelectWithCreateButton>
      <RowToRight --margin-top="1rem">
        <PrimaryButton variant="orange" onclick={() => step++}
          >Tiếp theo</PrimaryButton
        >
      </RowToRight>
    {:else if step == 2}
      <h3>Thành viên</h3>
      <RowToRight>
        <SecondaryButton onclick={() => step--}>Trở lại</SecondaryButton>
        <PrimaryButton variant="orange" onclick={() => step++}
          >Tiếp theo</PrimaryButton
        >
      </RowToRight>
    {:else}
      <h3>File đính kèm</h3>
      <RowToRight>
        <SecondaryButton onclick={() => step--}>Trở lại</SecondaryButton>
        <PrimaryButton variant="orange" onclick={() => {}}
          >Hoàn tất</PrimaryButton
        >
      </RowToRight>
    {/if}
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

{#snippet createSponsorModal()}
  <SingleFieldCreateModal
    title="Thêm nhà tài trợ"
    label="Tên nhà tài trợ"
    placeHolder="Vui lòng nhập tên nhà tài trợ"
    fieldName="sponsorName"
    successMessage="Thêm thành công"
    invalidateStr="project:create"
    createFn={createSponsor}
  />
{/snippet}

{#snippet createAidTypeModal()}
  <SingleFieldCreateModal
    title="Thêm loại viện trợ"
    label="Tên loại viện trợ"
    placeHolder="Vui lòng nhập tên loại viện trợ"
    fieldName="aidTypeName"
    successMessage="Thêm thành công"
    invalidateStr="project:create"
    createFn={createAidType}
  />
{/snippet}

{#snippet createApprovingAgencyModal()}
  <SingleFieldCreateModal
    title="Thêm cơ quan phê duyệt"
    label="Tên cơ quan phê duyệt"
    placeHolder="Vui lòng nhập tên cơ quan phê duyệt"
    fieldName="approvingAgencyName"
    successMessage="Thêm thành công"
    invalidateStr="project:create"
    createFn={createApprovingAgency}
  />
{/snippet}

{#snippet createCounterpartyModal()}
  <SingleFieldCreateModal
    title="Thêm đối tác"
    label="Tên đối tác"
    placeHolder="Vui lòng nhập tên đối tác"
    fieldName="counterpartyName"
    successMessage="Thêm thành công"
    invalidateStr="project:create"
    createFn={createCounterparty}
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
  }
</style>
