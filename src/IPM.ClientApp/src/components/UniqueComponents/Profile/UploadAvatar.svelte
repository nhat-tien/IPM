<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import FileUploader from "@components/FileUploader/FileUploader.svelte";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import { closeModal } from "@stores/modal.svelte";
  import uploadAvatar from "@useCases/userUseCase/uploadAvatar";
  import toast from "svelte-5-french-toast";
  let avatar: File | null = $state(null);

  async function handleUpload() {
    if (!avatar) {
      return;
    }
    const result = await uploadAvatar({ avatar: avatar });
    if (result.isSuccess) {
      toast.success("Upload avatar thành công");
      closeModal();
    }
  }
</script>

<div class="modal">
  <h3>Thay đổi hình đại diện</h3>
  <FileUploader callback={(file) => (avatar = file)} />
  <RowToRight --margin-bottom="0">
    <PrimaryButton variant="orange" onclick={handleUpload}
      >Tải lên</PrimaryButton
    >
    <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
  </RowToRight>
</div>

<style lang="scss">
  .modal {
    width: 40vw;
  }
</style>
