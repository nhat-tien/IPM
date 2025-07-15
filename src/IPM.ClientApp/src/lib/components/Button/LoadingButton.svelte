<script lang="ts">
  import Dot from "@components/Loading/Dot.svelte";
  import type { Snippet } from "svelte";

  type LoadingButtonProps = {
    children: Snippet;
    isLoading: boolean;
    type?: "button" | "submit" | "reset" | null | undefined;
    onclick?: (e: MouseEvent) => void;
  };

  const { children, isLoading, onclick = (_e) => {}, type = "submit"}: LoadingButtonProps = $props();
</script>

<button {onclick} disabled={isLoading} {type}>
  {#if isLoading}
    <Dot --font-size="8px" />
  {/if}
  {@render children()}
</button>

<style lang="scss">
  button {
    margin-top: var(--margin-top, 0);
    margin-bottom: var(--margin-bottom, 0);
    background-color: $text-clr;
    color: var(--background-clr);
    padding: 0.6em;
    border-radius: 6px;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    gap: 2em;
    opacity: 1;
  }
  button:hover {
    opacity: 0.8;
  }
  button:disabled {
    opacity: 0.8;
    cursor: not-allowed;
  }
</style>
