<script lang="ts">
  import type { Snippet } from "svelte";

  interface Props {
    children: Snippet;
    onclick?: (e: MouseEvent) => void;
    variant?: "orange" | "black";
    type?: "button" | "submit" | "reset" | null | undefined;
    disabled?: boolean;
  }
  const {
    children,
    onclick = () => {},
    variant = "orange",
    type = "button",
  }: Props = $props();

  let variantName = () => {
    switch (variant) {
      case "orange":
        return "button--orange";
      default:
        return "";
    }
  };
</script>

<button {onclick} class={variantName()} {type}>
  {@render children()}
</button>

<style lang="scss">
  button {
    margin-top: var(--margin-top, 0);
    margin-bottom: var(--margin-bottom, 0);
    margin-left: var(--margin-left, "auto");
    margin-right: var(--margin-right, "auto");
    background-color: var(--background-color, $text-clr);
    color: var(--color, $primary-clr);
    padding: 0.6em;
    border-radius: 10px;
    opacity: 1;
    width: var(--width, max-content);
    font-size: var(--font-size, 1em);
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
