<script lang="ts">
  import type { Snippet } from "svelte";

  type FloatMenuProps = {
    children: Snippet;
  };
  const { children }: FloatMenuProps = $props();
</script>

<div>
  {@render children()}
</div>

<style lang="scss">
  div {
    background-color: #fff;
    border-radius: 10px;
    box-shadow:
      rgba(60, 64, 67, 0.3) 0px 1px 2px 0px,
      rgba(60, 64, 67, 0.15) 0px 1px 3px 1px;
  }
</style>
