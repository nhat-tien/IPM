<script lang="ts">
  import type { Snippet } from "svelte";

  const {
    icon,
    children,
    variant,
    onclick = (_e) => {},
    type = "button",
  }: {
    icon: Snippet;
    children: Snippet;
    variant?: string;
    type?: "button" | "submit" | "reset" | null | undefined;
    onclick?: (e: MouseEvent) => void;
  } = $props();

  const variantName = () => {
    switch (variant) {
      case "orange":
        return "button--orange";
      default:
        return "";
    }
  };
</script>

<button {onclick} {type} class={variantName()}>
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
    width: var(--icon-size, 1.5em);
  }
  button {
    margin-top: var(--margin-top, 0);
    margin-bottom: var(--margin-bottom, 0);
    background-color: $white-clr;
    color: var(--color, $text-clr);
    font-weight: 600;
    padding: 0.4em 0.5em;
    border-radius: 10px;
    border: 1px solid var(--border-color, $gray-clr);
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    gap: 0.3em;
    width: var(--btn-width, max-content);
    &:hover {
      background-color: hsl(0, 0%, 95%);
    }
  }

  .button--orange {
    background-color: var(--background-color, $text-second-clr);
    color: var(--color, $white-clr);
    font-weight: 600;
    &:hover {
      background-color: var(--background-color, $text-second-clr);
      opacity: 0.8;
    }
  }
</style>
