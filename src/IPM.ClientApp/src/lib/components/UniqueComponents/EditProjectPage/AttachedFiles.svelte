<script lang="ts">
  import type { EditProjectDataPage } from "@useCases/useCases.types";
  import transformFileTypeToOption from "@useCases/fileTypeUseCase/transformFileTypeToOption";
  import { closeModal, openModal } from "@stores/modal.svelte";
  import FileUploader from "@components/FileUploader/FileUploader.svelte";
  import Row from "@components/Row/Row.svelte";
  import uploadFile, {
    uploadFileScheme,
  } from "@useCases/fileUseCase/uploadFile";
  import { ZodError } from "zod";
  import toast from "svelte-5-french-toast";
  import getIcon from "@utils/getIcon";
  import { invalidate } from "$app/navigation";
  import { getUserInfo } from "@stores/userInfo.svelte";
  import { getDateOrNull, formatDate } from "@utils/datetime";
  import getUrlFile from "@useCases/fileUseCase/downloadFile";
  import deleteFile from "@useCases/fileUseCase/deleteFile";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SelectWithSearch from "@components/Select/SelectWithSearch.svelte";
  import TrashIcon from "@components/Icons/TrashIcon.svelte";
  import SquareSkeleton from "@components/Skeleton/SquareSkeleton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import Card from "@components/Card/Card.svelte";
  import Error from "@/routes/+error.svelte";
  import ClockIcon from "@components/Icons/ClockIcon.svelte";
  import DownloadIcon from "@components/Icons/DownloadIcon.svelte";
  import ArrowTopRightOnSquare from "@components/Icons/ArrowTopRightOnSquare.svelte";
  import MessageBoxConfirm from "@components/MessageBox/MessageBoxConfirm.svelte";
  import { type FileApp } from "@useCases/useCases.types";
  import SideDrawer from "@components/SideDrawer/SideDrawer.svelte";
  import UserBadge from "@components/Badge/UserBadge.svelte";

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
      uploadFileScheme.parse({
        fileTypeId: fileState.fileTypeId,
        file: fileState.file,
        projectId: data.id,
      });

      const info = await getUserInfo();

      if (!info) {
        throw Error;
      }

      const result = await uploadFile({
        fileTypeId: fileState.fileTypeId,
        file: fileState.file,
        projectId: data.id,
        userId: info?.sub,
      });
      if (result.isSuccess) {
        toast.success("Upload thành công");
        invalidate("project:edit");
        isShowUploadArea = false;
      }
    } catch (e: any) {
      if (e instanceof ZodError) {
        toast.error(e.errors[0].message);
      } else {
        toast.error("Xảy ra lỗi");
      }
    }
  }

  let deletedFile: FileApp | undefined = $state();

  async function handleDelete(fileId: number) {
    const result = await deleteFile(fileId);

    if (result.isSuccess) {
      toast.success("Đã xóa file");
      invalidate("project:edit");
    }
  }

  async function handleDownload(fileId: number) {
    const result = await getUrlFile(fileId);
    var link = document.createElement("a");

    if(!result) return;

    console.log(result.name)

    link.setAttribute("download", result.name);
    link.href = result?.url;
    document.body.appendChild(link);
    link.click();
    link.remove();
  }

  let isOpenDetailFile = $state(false);
  let selectedFile: FileApp | undefined = $state();
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
            <div class="file-info__label">
              <p class="file__filename">{file.fileName}</p>
              <p class="file__filetype">{file.fileType.fileTypeName}</p>
            </div>
            <div class="file-info__date">
              <div class="icon-date">
                <ClockIcon />
              </div>
              <p>{formatDate("H:M AM d/m/Y", getDateOrNull(file.createdAt), { isAMPMformat: true})}</p>
            </div>
            <div class="file-info__action">
              <button
                class="icon"
                onclick={() => {
                  isOpenDetailFile = true;
                  selectedFile = file;
                }}
              >
                <ArrowTopRightOnSquare />
              </button>
              <button class="icon" onclick={() => handleDownload(file.fileId)}>
                <DownloadIcon />
              </button>
              <button
                class="icon"
                onclick={() => {
                  deletedFile = file;
                  openModal(confirmDelete);
                }}
              >
                <TrashIcon --stroke="hsl(0, 84%, 48%)" />
              </button>
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
          <SelectWithSearch
            label="Chọn loại file"
            required
            items={transformFileTypeToOption(fileType)}
            placeHolder=""
            selectFn={(e) =>
              (fileState.fileTypeId = e != null ? e.value + "" : "")}
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

<SideDrawer bind:isOpen={isOpenDetailFile}>
  <h3>{selectedFile?.fileName}</h3>
  <table class="file-detail">
    <tbody>
      <tr>
        <td>Loại file</td>
        <td>{selectedFile?.fileType.fileTypeName}</td>
      </tr>
      <tr>
        <td>Người tải lên</td>
        <td>
          <UserBadge user={selectedFile?.user} />
        </td>
      </tr>
      <tr>
        <td>Thời gian</td>
        <td
          >{formatDate(
            "H:M:s d/m/Y",
            getDateOrNull(selectedFile?.createdAt ?? ""),
          )}</td
        >
      </tr>
    </tbody>
  </table>
</SideDrawer>

{#snippet confirmDelete()}
  <MessageBoxConfirm
    title="Bạn có chắc muốn xóa?"
    description={`Xóa file ${deletedFile?.fileName}`}
    onYes={() => {
      if (deletedFile) handleDelete(deletedFile.fileId);
      closeModal();
    }}
    onNo={() => closeModal()}
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
    position: relative;
    flex-direction: row;
    align-items: center;
  }
  .file__filename {
    font-weight: 600;
  }
  .icon {
    width: 2em;
    @include center;
    padding: 0.2em;
    @include hover-button-icon;
  }
  .file-upload-container {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
  }

  .file-info__label {
    width: 50%;
  }
  .file-info__action {
    position: absolute;
    right: 0;
    display: flex;
    flex-direction: row;
    gap: 6px;
  }
  .file-info__date {
    font-size: 0.8rem;
    display: flex;
    flex-direction: row;
    gap: 0.1em;
  }

  .icon-date {
    width: 0.9rem;
    @include center;
  }
  .file-detail {
    width: 100%;
    margin-top: 10px;
    td {
      padding: 10px 0;
    }
  }
</style>
