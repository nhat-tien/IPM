<script lang="ts">
  import { getModal, getModalType, ModalType, isModalOpen} from "@stores/modal.svelte";
  import Modal from "@components/Modal/Modal.svelte";
  import ModalWithCloseIcon from "./ModalWithCloseIcon.svelte";
</script>

{#if isModalOpen()}
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
