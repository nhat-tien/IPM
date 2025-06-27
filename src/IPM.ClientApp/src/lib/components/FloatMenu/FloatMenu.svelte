<script lang="ts">
  import type { Snippet } from "svelte";

  type FloatMenuProps = {
    children: Snippet;
  };
  const { children }: FloatMenuProps = $props();
</script>

<ul>
  {@render children()}
</ul>

<style lang="scss">
  ul {
    background-color: #fff;
    border-radius: 10px;
    box-shadow:
      rgba(60, 64, 67, 0.3) 0px 1px 2px 0px,
      rgba(60, 64, 67, 0.15) 0px 1px 3px 1px;
    width: max-content;
    padding: 5px;
  }
</style>
