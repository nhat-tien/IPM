<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SelectWithCreateButtonCustom from "@components/Select/SelectWithCreatedButtonCustom.svelte";
  import TrashIcon from "@components/Icons/TrashIcon.svelte";
  import SquareSkeleton from "@components/Skeleton/SquareSkeleton.svelte";
  import type { EditProjectDataPage } from "@useCases/useCases.types";
  import transformFileTypeToOption from "@useCases/fileTypeUseCase/transformFileTypeToOption";
  import { openModal } from "@stores/modal.svelte";
  import SingleFieldCreateModal from "@components/Modal/CreateModal/SingleFieldCreateModal.svelte";
  import createFileType from "@useCases/fileTypeUseCase/createFileType";
  import FileUploader from "@components/FileUploader/FileUploader.svelte";
  import Row from "@components/Row/Row.svelte";
  import uploadFile, {
    uploadFileScheme,
  } from "@useCases/fileUseCase/uploadFile";
  import { ZodError } from "zod";
  import toast from "svelte-5-french-toast";
  import getIcon from "@utils/getIcon";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import { invalidate } from "$app/navigation";
    import Card from "@components/Card/Card.svelte";

  let { data }: { data: EditProjectDataPage } = $props();

  let fileState: {
    fileTypeId: string;
    file: File | null;
  } = $state({
    fileTypeId: "",
    file: null,
  });

  let isShowUploadArea = $state(false);

  async function handleUpload() {
    if (!fileState.file) {
      toast.error("Chưa chọn file để upload");
      return;
    }
    try {
      console.log(fileState.fileTypeId);
      uploadFileScheme.parse({
        fileTypeId: fileState.fileTypeId,
        file: fileState.file,
        projectId: data.id,
      });

      const result = await uploadFile({
        fileTypeId: fileState.fileTypeId,
        file: fileState.file,
        projectId: data.id,
      });
      if (result.isSuccess) {
        toast.success("Upload thành công");
        invalidate("project:edit");
        isShowUploadArea = false;
      }
    } catch (e: any) {
      if (e instanceof ZodError) {
        toast.error(e.errors[0].message);
      }
    }
  }
</script>

<Card
  --card-margin-top="1em"
  --card-margin-bottom="5em"
  --card-padding="1em"
  title="File đính kèm"
>
  <ul class="file-list">
    {#await data.files}
      <SquareSkeleton />
    {:then files}
      {#each files as file}
        <li class="file">
          <div class="file__type-icon">
            {@html getIcon(file.fileName)}
          </div>
          <div class="file__info">
            <div>
              <p class="file__filetype">{file.fileType.fileTypeName}</p>
              <p class="file__filename">{file.fileName}</p>
            </div>
            <div class="icon">
              <TrashIcon --stroke=" hsl(0, 84%, 48%)" />
            </div>
          </div>
        </li>
      {/each}
    {/await}
  </ul>
  {#if !isShowUploadArea}
    <Row --justify-content="center">
      <PrimaryButton onclick={() => (isShowUploadArea = true)}
        >Thêm</PrimaryButton
      >
    </Row>
  {:else}
    <div class="file-upload-container">
      <Row --align-items="flex-end">
        {#await data.fileType}
          <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
        {:then fileType}
          <SelectWithCreateButtonCustom
            label="Chọn loại file"
            required
            items={transformFileTypeToOption(fileType)}
            placeHolder=""
            selectFn={(e) => (fileState.fileTypeId = e != null ? e.value + "" : "")}
            btnClickFn={() => openModal(createFileTypeModal)}
            --width="60%"
          />
        {/await}
        <PrimaryButton onclick={() => handleUpload()}>Upload</PrimaryButton>
        <SecondaryButton onclick={() => (isShowUploadArea = false)}>
          Hủy</SecondaryButton
        >
      </Row>
      <FileUploader callback={(file) => (fileState.file = file)} />
    </div>
  {/if}
</Card>

{#snippet createFileTypeModal()}
  <SingleFieldCreateModal
    title={`Thêm loại file`}
    label={`Tên loại file`}
    placeHolder={`Vui lòng nhập tên loại file`}
    fieldName="fileTypeName"
    invalidateStr="project:edit"
    successMessage="Thêm thành công"
    createFn={createFileType}
  />
{/snippet}

<style lang="scss">
  .file-list {
    margin-top: 1em;
  }
  .file {
    padding: 0.5em;
    display: flex;
    flex-direction: row;
    border: 0.5px solid $gray-clr;
    border-radius: 5px;
    gap: 1em;
    margin-bottom: 0.5em;
  }
  .file__info {
    flex: 1;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
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
