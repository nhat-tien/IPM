<script lang="ts">
  import type { Snippet } from "svelte";

  const {
    icon,
    children,
    isLoading,
    onclick = (_e) => {},
    type = "submit",
  }: {
    icon: Snippet,
    children: Snippet;
    isLoading: boolean;
    type?: "button" | "submit" | "reset" | null | undefined;
    onclick?: (e: MouseEvent) => void;
  } = $props();

</script>

<button {onclick} disabled={isLoading} {type}> 
    <div class="icon">
      {@render icon()}
    </div>
    <div>
      {@render children()}
    </div>
</button>

<style lang="scss">
  button {
    margin-top: var(--margin-top, 0);
    margin-bottom: var(--margin-bottom, 0);
    background-color: $text-clr;
    color: $primary-clr;
    padding: 0.6em;
    border-radius: 6px;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    gap: var(--gap, 2em);
    opacity: 1;
  }
  button:hover {
    opacity: 0.8;
  }
  button:disabled {
    opacity: 0.8;
    cursor: not-allowed;
  }
  .icon {
    @include center;
  }
</style>
