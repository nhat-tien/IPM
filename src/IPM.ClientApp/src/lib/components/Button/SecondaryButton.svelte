<script lang="ts">
  import type { Snippet } from "svelte";
  const {
    children,
    onclick = () => {},
    type = "button",
  }: {
    children: Snippet;
    onclick?: () => void;
    type?: "button" | "submit" | "reset" | null | undefined;
  } = $props();
</script>

<button {onclick} {type}>
  {@render children()}
</button>

<style lang="scss">
  button {
    margin-top: var(--margin-top, 0);
    margin-bottom: var(--margin-bottom, 0);
    background-color: $white-clr;
    width: var(--width, max-content);
    color: var(--color, $text-clr);
    font-family: "Inter SemiBold";
    padding: 0.6em;
    border-radius: 10px;
    border: 1px solid var(--border-color, $gray-clr);

    &:hover {
      background-color: hsl(0, 0%, 95%);
    }
  }
</style>
