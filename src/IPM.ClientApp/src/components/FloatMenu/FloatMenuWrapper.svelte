<script lang="ts">
  import type { WindowMouseEvent } from "@/shared.types";
  import type { Snippet } from "svelte";
  import { fly } from "svelte/transition";

  type FloatMenuWrapperProps = {
    centerChild: Snippet;
    menuContainer: Snippet;
  };
  const { centerChild, menuContainer }: FloatMenuWrapperProps = $props();

  let isShow = $state(false);
  let container: HTMLDivElement | null = $state(null);

  function onWindowClick(e: WindowMouseEvent) {
    if (!container) {
      return;
    }
    if (container.contains(e.target as Node) == false) {
      isShow = false;
    }
  }
  function show() {
    isShow = !isShow;
  }
</script>

<svelte:window onclick={onWindowClick} />

<!-- svelte-ignore a11y_click_events_have_key_events -->
<!-- svelte-ignore a11y_no_static_element_interactions -->
<div bind:this={container} class="float-menu-wrapper">
  <button onclick={show} class="center-child">
    {@render centerChild()}
  </button>
  {#if isShow}
    <div transition:fly={{ x: 0, y: -10, duration: 100 }} class="float-menu">
      {@render menuContainer()}
    </div>
  {/if}
</div>

<style lang="scss">
  .float-menu-wrapper {
    position: relative;
  }
  .float-menu {
    position: absolute;
    top: 140%;
    right: 0;
  }
  .center-child {
    cursor: pointer;
  }
</style>
