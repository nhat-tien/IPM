<script lang="ts">
  import type { Snippet } from "svelte";

  const { children }: { children: Snippet } = $props();
</script>

<div class="container">
  <div class="tab">
    {@render children()}
  </div>
</div>

<style lang="scss">
  .container {
    width: 100%;
    display: flex;
    flex-direction: row;
    justify-content: center;
  }
  .tab {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 10px;
    padding: 0.5em;
    margin-top: 1em;
    width: max-content;
    display: flex;
    flex-direction: row;
    justify-content: center;
    gap: 1em;
  }
</style>
