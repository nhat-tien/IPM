<script lang="ts">
  import type { Snippet } from "svelte";

  const {
    children,
    onclick,
    isSelected
  }: {
    children: Snippet;
    onclick?: () => void;
    isSelected?: boolean;
  } = $props();
</script>

<button {onclick} class={ isSelected ? "selected" : ""}>
  {@render children()}
</button>

<style lang="scss">
  button {
    color: $text_light_clr;
    padding: 0.5em;
    transition: all .15s ease-in-out;
    border-radius: 5px;
    &:hover {
      color: $text-clr;
      background-color: var(--background-clr);
    }
  }
  .selected {
    color: $text-second-clr;
    background-color: var(--background-clr);
    &:hover {
      color: $text-second-clr;
      background-color: var(--background-clr);
    }
  }
</style>
