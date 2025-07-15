<script lang="ts">
  import SelectWithCreateButtonCustom from "@components/Select/SelectWithCreatedButtonCustom.svelte";
  import transformCategoryToOption from "@useCases/categoryUseCase/transformCategoryToOption";
  import transformAffliatedUnitToOption from "@useCases/affiliatedUnitUseCase/transformAffliatedUnitToOption";
  import SquareSkeleton from "@components/Skeleton/SquareSkeleton.svelte";
  import transformApprovingAgencyToOption from "@useCases/approvingAgencyUseCase/transformApprovingAgencyToOption";
  import transformSponsorToOption from "@useCases/sponsorUseCase/transformSponsorToOption";
  import type {
    EditProjectDataPage,
    EditState,
  } from "@useCases/useCases.types";
  import transformAidTypeToOption from "@useCases/aidTypeUseCase/transformAidTypeToOption";
  import transformCounterpartyToOption from "@useCases/counterpartyUseCase/transformCounterpartyToOption";
  import SingleFieldCreateModal from "@components/Modal/CreateModal/SingleFieldCreateModal.svelte";
  import createAidType from "@useCases/aidTypeUseCase/createAidType";
  import createApprovingAgency from "@useCases/approvingAgencyUseCase/createApprovingAgency";
  import createCategory from "@useCases/categoryUseCase/createCategory";
  import createCounterparty from "@useCases/counterpartyUseCase/createCounterparty";
  import createSponsor from "@useCases/sponsorUseCase/createSponsor";
  import { openModal } from "@stores/modal.svelte";
  import createAffiliatedUnit from "@useCases/affiliatedUnitUseCase/createAffiliatedUnit";
  import Row from "@components/Row/Row.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import DatePicker from "@components/DatePicker/DatePicker.svelte";
  import updateProject from "@useCases/projectUseCase/updateProject";
  import toast from "svelte-5-french-toast";
  import { invalidateCache } from "@stores/cache.svelte";
    import Card from "@components/Card/Card.svelte";
    import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
    import RichTextEditor from "@components/RichTextEditor/RichTextEditor.svelte";

  let {
    modelState = $bindable(),
    data,
  }: { modelState: EditState; data: EditProjectDataPage } = $props();

  function handleCancel() {
    //TODO:
  }

  async function handleSave() {
    const updateDto = {
      projectNameVietnamese: modelState.projectNameVietnamese,
      projectNameEnglish: modelState.projectNameEnglish,
      projectProgress: modelState.projectProgress,
      content: modelState.content,
      projectPurpose: modelState.projectPurpose,
      projectBudget: modelState.projectBudget,
      startDate: modelState.startDate,
      endDate: modelState.endDate,
      percentageOfProgress: modelState.percentageOfProgress,
      fundedEquipment: modelState.fundedEquipment,
      categoryId: modelState.categoryId,
      affiliatedUnitId: modelState.affiliatedUnitId,
      sponsorId: modelState.sponsorId,
      aidTypeId: modelState.aidTypeId,
      approvingAgencyId: modelState.approvingAgencyId,
      counterPartyId: modelState.counterPartyId,
    };
    const result = await updateProject({
      formData: updateDto,
      id: data.id,
      project: data.project,
    });

    if (result.isSuccess) {
      invalidateCache(`project:${data.id}`);
      toast.success("Chỉnh sửa dự án thành công");
    }
  }
</script>

<Card
  --card-margin-top="1em"
  --card-margin-bottom="5em"
  --card-padding="1em"
  title="Thông tin dự án"
>
  <PrimaryTextField
    id="projectNameVietnamese"
    label="Tên dự án Tiếng Việt"
    placeHolder=""
    type="text"
    name="projectNameVietnamese"
    bind:value={modelState.projectNameVietnamese}
    --margin-top="1.5em"
  />
  <PrimaryTextField
    id="projectNameEnglish"
    label="Tên dự án Tiếng Anh"
    placeHolder=""
    type="text"
    name="projectNameEnglish"
    bind:value={modelState.projectNameEnglish}
    --margin-top="1.5em"
  />
  <PrimaryTextField
    id="projectPurpose"
    label="Mục tiêu dự án"
    placeHolder=""
    type="text"
    name="projectPurpose"
    bind:value={modelState.projectPurpose}
    --margin-top="1.5em"
  />
  <RichTextEditor
    label="Nội dung"
    bind:value={modelState.content}
    --margin-top="1.5em"
  />
  <PrimaryTextField
    id="projectProgress"
    label="Tiến độ dự án"
    placeHolder=""
    type="text"
    name="projectProgress"
    bind:value={modelState.projectProgress}
    --margin-top="1.5em"
  />
  <PrimaryTextField
    id="percentageOfProgress"
    label="Phần trăm tiến độ"
    placeHolder=""
    type="text"
    name="percentageOfProgress"
    bind:value={modelState.percentageOfProgress}
    --margin-top="1.5em"
  />
  <PrimaryTextField
    id="fundedEquipment"
    label="Thiết bị tài trợ"
    placeHolder=""
    type="text"
    name="fundedEquipment"
    bind:value={modelState.fundedEquipment}
    --margin-top="1.5em"
  />
  <PrimaryTextField
    id="projectBudget"
    label="Kinh phí dự án"
    placeHolder=""
    type="text"
    name="projectBudget"
    bind:value={modelState.projectBudget}
    --margin-top="1.5em"
  />
  <DatePicker
    --margin-top="1.5em"
    --width="20ch"
    label="Ngày bắt đầu"
    id="startDate"
    bind:value={modelState.startDate}
  />
  <DatePicker
    --margin-top="1.5em"
    --width="20ch"
    label="Ngày kết thúc"
    id="endDate"
    bind:value={modelState.endDate}
  />
  {#await data.affiliatedUnit}
    <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
  {:then affiliatedUnit}
    <SelectWithCreateButtonCustom
      label="Đơn vị trực thuộc"
      required
      value={data.project.affiliatedUnit?.affiliatedUnitName}
      items={transformAffliatedUnitToOption(affiliatedUnit)}
      placeHolder="Chọn đơn vị trực thuộc"
      selectFn={(e) => (modelState.affiliatedUnitId = e ? parseInt(e.value) : null)}
      btnClickFn={() => openModal(createAffiliatedUnitModal)}
      --margin-top="1em"
    />
  {/await}
  {#await data.category}
    <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
  {:then categories}
    <SelectWithCreateButtonCustom
      label="Danh mục"
      required
      value={data.project.category?.categoryName}
      items={transformCategoryToOption(categories)}
      placeHolder="Chọn danh mục"
      selectFn={(e) => (modelState.categoryId = e ? parseInt(e.value) : null)}
      btnClickFn={() => openModal(createCategoryModal)}
      --margin-top="1em"
    />
  {/await}
  {#await data.approvingAgency}
    <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
  {:then approvingAgencies}
    <SelectWithCreateButtonCustom
      label="Cơ quan phê duyệt"
      required
      value={data.project.approvingAgency?.approvingAgencyName}
      items={transformApprovingAgencyToOption(approvingAgencies)}
      placeHolder="Chọn cơ quan phê duyệt"
      selectFn={(e) => (modelState.approvingAgencyId = e ? parseInt(e.value) : null)}
      btnClickFn={() => openModal(createApprovingAgencyModal)}
      --margin-top="1em"
    />
  {/await}
  {#await data.sponsor}
    <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
  {:then sponsors}
    <SelectWithCreateButtonCustom
      label="Nhà tài trợ"
      required
      value={data.project.sponsor?.sponsorName}
      items={transformSponsorToOption(sponsors)}
      placeHolder="Chọn nhà tài trợ"
      selectFn={(e) => (modelState.sponsorId = e ? parseInt(e.value) : null)}
      btnClickFn={() => openModal(createSponsorModal)}
      --margin-top="1em"
    />
  {/await}
  {#await data.aidType}
    <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
  {:then aidTypes}
    <SelectWithCreateButtonCustom
      label="Loại viện trợ"
      required
      value={data.project.aidType?.aidTypeName}
      items={transformAidTypeToOption(aidTypes)}
      placeHolder="Chọn loại viện trợ"
      selectFn={(e) => (modelState.aidTypeId = e ? parseInt(e.value) : null)}
      btnClickFn={() => openModal(createAidTypeModal)}
      --margin-top="1em"
    />
  {/await}
  {#await data.counterparty}
    <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
  {:then counterparties}
    <SelectWithCreateButtonCustom
      label="Đối tác"
      required
      value={data.project.counterparty?.counterpartyName}
      items={transformCounterpartyToOption(counterparties)}
      placeHolder="Chọn đối tác"
      selectFn={(e) => (modelState.counterPartyId = e ? parseInt(e.value) : null)}
      btnClickFn={() => openModal(createCounterpartyModal)}
      --margin-top="1em"
    />
  {/await}

  <Row --justify-content="flex-end"  --padding="0 1em 0 0" --margin-top="1.5em">
    <SecondaryButton onclick={() => handleCancel()}
      >Hủy bỏ thay đổi</SecondaryButton
    >
    <PrimaryButton variant="orange" onclick={() => handleSave()}
      >Lưu</PrimaryButton
    >
  </Row >
</Card>

{#snippet createAffiliatedUnitModal()}
  <SingleFieldCreateModal
    title="Thêm đơn vị trực thuộc"
    label="Tên đơn vị trực thuộc"
    placeHolder="Vui lòng nhập tên đơn vị trực thuộc"
    fieldName="affiliatedUnitName"
    successMessage="Thêm thành công"
    invalidateStr="project:edit"
    createFn={createAffiliatedUnit}
  />
{/snippet}
{#snippet createCategoryModal()}
  <SingleFieldCreateModal
    title="Thêm danh mục"
    label="Tên danh mục"
    placeHolder="Vui lòng nhập tên danh mục"
    fieldName="categoryName"
    successMessage="Thêm thành công"
    invalidateStr="project:edit"
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
    invalidateStr="project:edit"
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
    invalidateStr="project:edit"
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
    invalidateStr="project:edit"
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
    invalidateStr="project:edit"
    createFn={createCounterparty}
  />
{/snippet}

<style lang="scss">
  // .container {
  //   background-color: $white-clr;
  //   border: 1px solid $gray-clr;
  //   border-radius: 15px;
  //   padding: 1em;
  //   margin-top: 1em;
  //   margin-bottom: 5em;
  // }
</style>
