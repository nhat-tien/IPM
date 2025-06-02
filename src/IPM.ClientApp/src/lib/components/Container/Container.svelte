<script lang="ts">
  import type { Snippet } from "svelte";

  type Props = {
    children: Snippet;
  };

  const { children }: Props = $props();
</script>

<section>
  {@render children()}
</section>

<style lang="scss">
  section {
      background-color: $white-clr;
      border: 1px solid $gray-clr;
      border-radius: 15px;
      margin-top: var(--margin-top, 0.5em);
      margin-bottom: var(--margin-bottom, 0.5em);
      padding-top: var(--padding-top, 0);
      padding-bottom: var(--padding-bottom, 0);
      padding-right: var(--padding-right, 0);
      padding-left: var(--padding-left, 0);
      padding: var(--padding, 0 0 0 0);
  }
</style>
