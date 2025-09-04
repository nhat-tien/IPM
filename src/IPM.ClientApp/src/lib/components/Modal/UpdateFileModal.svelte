<script lang="ts">
    import PrimaryButton from "@components/Button/PrimaryButton.svelte";
    import SecondaryButton from "@components/Button/SecondaryButton.svelte";
    import Row from "@components/Row/Row.svelte";
    import SelectWithSearch from "@components/Select/SelectWithSearch.svelte";
    import SquareSkeleton from "@components/Skeleton/SquareSkeleton.svelte";
    import { closeModal } from "@stores/modal.svelte";
    import transformFileTypeToOption from "@useCases/fileTypeUseCase/transformFileTypeToOption";
    import updateFile from "@useCases/fileUseCase/updateFile";
    import type { FileType } from "@useCases/useCases.types";
    import toast from "svelte-5-french-toast";

    type Props = {
      fileTypes: Promise<FileType[]>,
      fileId: number 
    }

    const { fileTypes, fileId }: Props = $props();

    let fileTypeId = $state("");

    async function handleUpdate() {
      const result = await updateFile({ fileTypeId, fileId });
      if(result.isSuccess) {
        toast.success("Cập nhật thành công");
      }
    }

</script>

<div class="modal">
  <h3>Cập nhật file</h3>
    {#await fileTypes}
      <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
    {:then fileType}
      <SelectWithSearch
        label="Chọn loại file"
        required
        items={transformFileTypeToOption(fileType)}
        placeHolder=""
        selectFn={(e) =>
          (fileTypeId = e != null ? e.value + "" : "")}
        --width="400px"
      />
    {/await}
    <Row --justify-content="flex-end"  --margin-bottom="0">
      <PrimaryButton variant="orange" onclick={() => handleUpdate()}>Cập nhật</PrimaryButton>
      <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
    </Row>
</div>

