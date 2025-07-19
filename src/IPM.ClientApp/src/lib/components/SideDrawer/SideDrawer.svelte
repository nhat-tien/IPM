<script lang="ts">
  import clickOutside from "@lib/attachHelpers/clickOutside";
  import type { Snippet } from "svelte";
    import { fade, fly } from "svelte/transition";
  interface Props {
    children: Snippet;
    isOpen: boolean;
  }
  let { children, isOpen = $bindable(false) }: Props = $props();
  let parentNode: Node | undefined = $state(undefined);
</script>

{#if isOpen}
<div bind:this={parentNode} class="modal-backdrop" transition:fade={{ duration: 300 }} >
  <div 
      transition:fly={{ x: 50, duration: 300 }} 
      class="modal" 
      {@attach clickOutside(() => isOpen = false,{ limit: parentNode}) } >
    <div class="content">
      {@render children()}
    </div>
  </div>
</div>
{/if}

<style lang="scss">
  .modal-backdrop {
    position: fixed;
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
    position: fixed;
    display: flex;
    height: 100vh;
    top: 0;
    right: 0;
    width: 500px;
    flex-direction: column;
    align-items: flex-start;
    text-align: left;
  }

  .content {
    padding: 1.5rem;
    width: 100%;
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

