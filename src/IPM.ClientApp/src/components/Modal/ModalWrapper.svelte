<script lang="ts">
  import { getModal, getModalType, ModalType } from "@stores/modal.svelte";
  import Modal from "@components/Modal/Modal.svelte";
  import ModalWithCloseIcon from "./ModalWithCloseIcon.svelte";
</script>

{#if getModal()}
  {#if getModalType() === ModalType.CloseModal}
    <ModalWithCloseIcon>
      {@render getModal()?.()}
    </ModalWithCloseIcon>
  {:else}
    <Modal>
      {@render getModal()?.()}
    </Modal>
  {/if}
{/if}
