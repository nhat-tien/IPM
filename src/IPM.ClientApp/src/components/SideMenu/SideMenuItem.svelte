<script lang="ts">
  import type { Snippet } from "svelte";

  type SideMenuItemProps = {
    isSelected?: boolean;
    href: string;
    icon: Snippet;
    content: Snippet;
  };

  const { content, icon, href, isSelected = false }: SideMenuItemProps = $props();
</script>

<a {href} class={["side-menu-item", isSelected ? "selected" : ""]}>
  <div class="icon">
    {@render icon()}
  </div>
  <div class="content">
    {@render content()}
  </div>
</a>

<style lang="scss">
.side-menu-item {
  display: flex;
  flex-direction: row;
  align-items: center;
  padding: 0.5em;
  border-radius: 5px;
  gap: 1em;
  transition: background-color .15s ease-in-out;
}
.icon {
  width: 1.7em;
  @include center;
}
.side-menu-item.selected {
  background-color: hsl(0, 0%, 92%);
}
.side-menu-item:hover {
  background-color: hsl(0, 0%, 92%);
}
</style>
