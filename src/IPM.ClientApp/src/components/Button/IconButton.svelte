<script lang="ts">
  import type { Snippet } from "svelte";

  const {
    icon,
    children,
    onclick = (_e) => {},
    type = "button",
  }: {
    icon: Snippet,
    children: Snippet;
    type?: "button" | "submit" | "reset" | null | undefined;
    onclick?: (e: MouseEvent) => void;
  } = $props();

</script>

<button {onclick} {type}> 
    <div class="icon">
      {@render icon()}
    </div>
    <div>
      {@render children()}
    </div>
</button>

<style lang="scss">
  .icon {
    @include center;
    width: 1.5em;
  }
  button {
    margin-top: var(--margin-top, 0);
    margin-bottom: var(--margin-bottom, 0);
    background-color: $white-clr;
    color: var(--color, $text-clr);
    font-family: "Inter SemiBold";
    padding: 0.4em 0.5em;
    border-radius: 10px;
    border: 1px solid var(--border-color, $gray-clr);
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    gap: 0.3em;
    &:hover {
      background-color: hsl(0, 0%, 95%);
    }
  }
</style>
