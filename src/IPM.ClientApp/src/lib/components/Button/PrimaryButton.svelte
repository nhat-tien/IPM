<script lang="ts">
    import Dot from "@components/Loading/Dot.svelte";
  import type { Snippet } from "svelte";

  interface Props {
    children: Snippet;
    onclick?: (e: MouseEvent) => void;
    variant?: "orange" | "black";
    type?: "button" | "submit" | "reset" | null | undefined;
    disabled?: boolean;
    isLoading?: boolean;
  }
  const {
    children,
    onclick = () => {},
    variant = "orange",
    type = "button",
    disabled = false,
    isLoading = false 
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

<button {onclick} class={variantName()} {type} disabled={disabled || isLoading}> 
  {#if isLoading}
    <Dot --font-size="10px" />
  {/if}
  {@render children()}
</button>

<style lang="scss">

  button {
    margin-top: var(--margin-top, 0);
    margin-bottom: var(--margin-bottom, 0);
    margin-left: var(--margin-left, "auto");
    margin-right: var(--margin-right, "auto");
    background-color: var(--background-color, $text-clr);
    color: var(--color, var(--background-clr));
    padding: 0.6em;
    border-radius: 6px;
    opacity: 1;
    width: var(--width, max-content);
    font-size: var(--font-size, 1em);
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    gap: 1em;
  }
  button:hover {
    opacity: 0.8;
  }
  button:disabled {
    opacity: 0.6;
    cursor: not-allowed;
  }
  .button--orange {
    background-color: var(--background-color, $text-second-clr);
    color: var(--color, $white-clr);
    font-weight: 600;
  }
</style>
