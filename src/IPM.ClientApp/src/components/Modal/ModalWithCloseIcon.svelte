<script lang="ts">
  import CloseIcon from "@components/Icons/CloseIcon.svelte";
  import type { Snippet } from "svelte";
  import { closeModal } from "@stores/modal.svelte";

  const { children }: { children: Snippet } = $props();
</script>

<div class="modal-backdrop">
  <div class="modal">
    <div class="header">
      <button class="close-btn" onclick={() => closeModal()}>
        <CloseIcon />
      </button>
    </div>
    <div class="content">
      {@render children()}
    </div>
  </div>
</div>

<style lang="scss">
  .modal-backdrop {
    position: absolute;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: rgba(0, 0, 0, 0.5);
  }
  .modal {
    background-color: $white-clr;
    display: flex;
    flex-direction: column;
    border-radius: 10px;
  }

  .header {
    width: 100%;
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
  }

  .close-btn {
    width: 30px;
    margin: 0.2em;
    @include center;
    @include hover-button-icon;
  }
  .content {
    padding: 0 1rem 1rem 1rem;
  }
</style>
