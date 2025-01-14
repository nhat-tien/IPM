<script lang="ts">
  import type { Snippet } from "svelte";
  const {
    children,
    onclick = () => {},
    variant,
    type = "button"
  }: {
    children: Snippet;
    onclick?: () => void;
    variant?: string;
    type?: "button" | "submit" | "reset" | null | undefined;
  } = $props();

  let variantName = () => {
    switch(variant) {
      case "orange": 
         return "button--orange";
      default:
        return "";
    }
  }
</script>

<button {onclick} class={variantName()} {type}>
  {@render children()}
</button>

<style lang="scss">
  button {
    margin-top: var(--margin-top, 0);
    margin-bottom: var(--margin-bottom, 0);
    background-color: var(--background-color, $text-clr);
    color: var(--color, $primary-clr);
    padding: 0.6em;
    border-radius: 10px;
    opacity: 1;
  }
  button:hover {
    opacity: 0.8;
  }
  .button--orange {
    background-color: var(--background-color, $text-second-clr);
    color: var(--color, $white-clr);
  font-family: "Inter SemiBold";
  }
</style>
