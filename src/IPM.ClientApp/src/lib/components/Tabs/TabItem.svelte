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
    color: $text-light-clr;
    padding: 0.5em;
    transition: all .15s ease-in-out;
    border-radius: 5px;
    &:hover {
      color: $text-clr;
      background-color: $primary-clr;
    }
  }
  .selected {
    color: $text-second-clr;
    background-color: $primary-clr;
    &:hover {
      color: $text-second-clr;
      background-color: $primary-clr;
    }
  }
</style>
