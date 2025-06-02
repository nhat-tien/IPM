<script lang="ts">
    import { invalidate } from "$app/navigation";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import FileUploader from "@components/FileUploader/FileUploader.svelte";
  import Row from "@components/Row/Row.svelte";
    import { invalidateCache } from "@stores/cache.svelte";
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
      invalidateCache("profile");
      invalidate("user:profile");
      closeModal();
    }
  }
</script>

<div class="modal">
  <h3>Thay đổi hình đại diện</h3>
  <FileUploader callback={(file) => (avatar = file)} />
  <Row --justify-content="flex-end"  --margin-bottom="0">
    <PrimaryButton variant="orange" onclick={handleUpload}
      >Tải lên</PrimaryButton
    >
    <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
  </Row >
</div>

<style lang="scss">
  .modal {
    width: 40vw;
  }
</style>
