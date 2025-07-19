<script lang="ts">
  import clickOutside from "@lib/attachHelpers/clickOutside";
  import { tick, type Snippet } from "svelte";
  import { fly } from "svelte/transition";

  type FloatMenuWrapperProps = {
    centerChild: Snippet;
    menuContainer: Snippet;
  };
  const { centerChild, menuContainer }: FloatMenuWrapperProps = $props();

  let anchor: HTMLDivElement | undefined = $state();
  let menu: HTMLDivElement | undefined = $state();

  let menuState = $state({
    isShow: false,
    x: 0,
    y: 0
  });

  function onClick() {
    menuState.isShow = !menuState.isShow;

    tick().then(() => {
      const anchorPosition = anchor?.getBoundingClientRect();
      const anchorWidth = anchorPosition?.width ?? 0;
      const anchorHeight = anchorPosition?.height ?? 0;

      const menuPosition = menu?.getBoundingClientRect();
      const menuWidth = menuPosition?.width ?? 0;
      const menuHeight = menuPosition?.height ?? 0;

      console.log(anchorPosition)

      const windowWidth = window.innerWidth;
      const windowHeight = window.innerHeight;

      let x,y : number;

      x = anchorPosition?.left ?? 0;
      y = anchorPosition?.top ?? 0;
      
      x = x + anchorWidth;
      if(x + menuWidth > windowWidth) {
        x = x - (menuWidth + anchorWidth);
      }

      y = y + anchorHeight;
      if(y + menuHeight > windowHeight) {
        y = y - (menuHeight + anchorHeight);
      }
      menuState.x = x;
      menuState.y = y;
    })
  }

</script>


<!-- svelte-ignore a11y_click_events_have_key_events -->
<!-- svelte-ignore a11y_no_static_element_interactions -->
<div 
  class="float-menu-wrapper" 
  onclick={onClick} 
  {@attach clickOutside(() => menuState.isShow = false) } >
  <div class="center-child" bind:this={anchor}>
    {@render centerChild()}
  </div>
  {#if menuState.isShow}
    <div transition:fly={{ x: 0, y: -10, duration: 100 }} bind:this={menu} class="float-menu" style={`top: ${menuState.y}px; left: ${menuState.x}px`} >
      {@render menuContainer()}
    </div>
  {/if}
</div>

<style lang="scss">
  .float-menu-wrapper {
    position: relative;
  }
  .float-menu {
    position: fixed;
    z-index: 100;
  }
  .center-child {
    cursor: pointer;
  }
</style>
