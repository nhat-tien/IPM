<script lang="ts">
  import clickOutside from "@lib/attachHelpers/clickOutside";
  import { closeModal } from "@stores/modal.svelte";
  import type { Snippet } from "svelte";
  const { children }: { children: Snippet } = $props();
  let parentNode: Node | undefined = $state(undefined);
</script>

<div bind:this={parentNode} class="modal-backdrop" >
  <div 
    class="modal"
    {@attach clickOutside(() => closeModal(), { limit: parentNode}) } >
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
    backdrop-filter: blur(10px);
  }
  .modal {
    background-color: $white-clr;
    display: flex;
    flex-direction: column;
    border-radius: 10px;
    animation: scale-larger 0.07s linear;
    align-items: flex-start;
    text-align: left;
  }

  .content {
    padding: 1.5rem;
  }

  @keyframes scale-larger {
    0% {
      transform: scale(0.7);
    }
    100% {
      transform: scale(1);
    }
  }
</style>
