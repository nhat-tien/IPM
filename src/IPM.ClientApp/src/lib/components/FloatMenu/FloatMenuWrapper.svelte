<script lang="ts">
  import clickOutside from "@lib/helpers/clickOutside";
  import type { Snippet } from "svelte";
  import { fly } from "svelte/transition";

  type FloatMenuWrapperProps = {
    centerChild: Snippet;
    menuContainer: Snippet;
  };
  const { centerChild, menuContainer }: FloatMenuWrapperProps = $props();
  let isShow = $state(false);
</script>


<!-- svelte-ignore a11y_click_events_have_key_events -->
<!-- svelte-ignore a11y_no_static_element_interactions -->
<div class="float-menu-wrapper" onclick={() => isShow = !isShow} onclickoutside={() => isShow = false} {@attach clickOutside({}) } >
  <div class="center-child">
    {@render centerChild()}
  </div>
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
    z-index: 100;
  }
  .center-child {
    cursor: pointer;
  }
</style>
