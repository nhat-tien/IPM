<script lang="ts">
  import ChevronDownIcon from "@components/Icons/ChevronDownIcon.svelte";
  import type { Snippet } from "svelte";
  type SideMenuGroupProps = {
    title: string;
    children: Snippet;
    icon?: Snippet;
  };
  let open = $state(false);
  const { title, children, icon }: SideMenuGroupProps = $props();
</script>

<button
  class={["side-menu-group-title", open ? "open" : ""]}
  onclick={() => (open = !open)}
>
  <span class="title">
  {#if icon}
    <span class="icon">
      {@render icon()}
    </span>
  {/if}
  {title}
  </span>
  <div class="icon-chevron">
    <ChevronDownIcon />
  </div>
</button>
<div class={["side-menu-group", open ? "open" : ""]}>
  {@render children()}
</div>

<style lang="scss">
  .side-menu-group-title {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    padding: 0.5em;
    margin-top: 1em;
    border-radius: 5px;
    transition: background-color 0.15s ease-in-out;
  }
  .title {
    display: flex;
    flex-direction: row;
    align-items: center;
    gap: 0.5em;
  }
  .side-menu-group-title:hover {
    background-color: hsl(0, 0%, 92%);
  }
  .side-menu-group-title.open .icon-chevron {
    transform-origin: center;
    transform: rotate(180deg);
  }
  .side-menu-group {
    margin-bottom: 1em;
    max-height: 0;
    overflow: hidden;
    transition: max-height 0.3s ease-in-out;
  }
  .side-menu-group.open {
    max-height: 3000px;
  }
  .icon {
    width: 1.5em;
    @include center;
  }
  .icon-chevron {
    width: 1.5em;
    transition: transform 0.4s ease-in-out;
    @include center;
  }
</style>
