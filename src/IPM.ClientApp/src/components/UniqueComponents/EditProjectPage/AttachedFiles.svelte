<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SelectWithCreateButtonCustom from "@components/Select/SelectWithCreatedButtonCustom.svelte";
  import TrashIcon from "@components/Icons/TrashIcon.svelte";
  import RowCenter from "@components/Row/RowCenter.svelte";
  import SquareSkeleton from "@components/Skeleton/SquareSkeleton.svelte";
  import type {
    EditState,
    EditProjectDataPage,
  } from "@useCases/useCases.types";
  import transformFileTypeToOption from "@useCases/fileTypeUseCase/transformFileTypeToOption";
  import { openModal } from "@stores/modal.svelte";
  import SingleFieldCreateModal from "@components/Modal/CreateModal/SingleFieldCreateModal.svelte";
  import createFileType from "@useCases/fileTypeUseCase/createFileType";
    import { fail } from "@sveltejs/kit";
    import RowToLeft from "@components/Row/RowToLeft.svelte";
    import FileUploader from "@components/FileUploader/FileUploader.svelte";

  let {
    modelState = $bindable(),
    data,
  }: { modelState: EditState; data: EditProjectDataPage } = $props();

  let isShowUploadArea = $state(false);
</script>

<div class="container">
  <h2>File đính kèm</h2>
  <h3>Danh sách file</h3>
  <ul class="file-list">
    <li class="file">
      <div>
        <p class="file__filetype">File type</p>
        <p class="file__filename">File Name</p>
      </div>
      <div class="icon">
        <TrashIcon --stroke=" hsl(0, 84%, 48%)" />
      </div>
    </li>
  </ul>
  <!-- {#if !isShowUploadArea} -->
    <!-- <RowCenter> -->
    <!--   <PrimaryButton onclick={() => (isShowUploadArea = true)} -->
    <!--     >Thêm</PrimaryButton -->
    <!--   > -->
    <!-- </RowCenter> -->
  <!-- {:else} -->
    <div class="file-upload-container">
       <RowToLeft
      --align-items="flex-end"
    >
      {#await data.fileType}
        <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
      {:then fileType}
        <SelectWithCreateButtonCustom
          label="Chọn loại file"
          required
          items={transformFileTypeToOption(fileType)}
          placeHolder="Chọn đơn vị trực thuộc"
          selectFn={(e) => {}}
          btnClickFn={() => openModal(createFileTypeModal)}
        --width="60%"
        />
      {/await}
      <PrimaryButton onclick={() => isShowUploadArea = false}>Upload</PrimaryButton>
       </RowToLeft>
    <input class="file-upload-area" type="file" />
      <FileUploader callback={(file) => {}}/>
    </div>
  <!-- {/if} -->
</div>

{#snippet createFileTypeModal()}
  <SingleFieldCreateModal
    title={`Thêm loại file`}
    label={`Tên loại file`}
    placeHolder={`Vui lòng nhập tên loại file`}
    fieldName="fileTypeName"
    invalidateStr="fileType:getAll"
    successMessage="Thêm thành công"
    createFn={createFileType}
  />
{/snippet}

<style lang="scss">
  .container {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
  }
  h2 {
    margin-bottom: 1em;
  }
  .file-list {
    margin-top: 1em;
  }
  .file {
    padding: 0.5em;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    border: 0.5px solid $gray-clr;
    border-radius: 5px;
  }
  .file__filetype {
    font-weight: 600;
  }
  .icon {
    width: 1.4em;
    @include center;
  }
  .file-upload-container {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
  }
</style>
