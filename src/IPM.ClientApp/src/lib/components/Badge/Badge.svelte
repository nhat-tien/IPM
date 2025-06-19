<script lang="ts">
  import type { Snippet } from "svelte";

  type Props = {
    children: Snippet;
    isHasDot?: boolean
    variant?: "blue" | "gray" | "green";
  };

  const { children, variant = "blue", isHasDot = true }: Props = $props();
</script>

<div class={`badge badge--${variant}`}>
  {#if isHasDot}
    <div class="badge-dot"></div>
  {/if}
  {@render children()}
</div>

<style lang="scss">
  @mixin badge-variant(
    $front-color: hsl(0, 100%, 50%),
    $back-color: hsl(0, 100%, 96%)
  ) {
    color: $front-color;
    border-color: $front-color;
    background-color: $back-color;
    .badge-dot {
      border-radius: 90%;
      width: 2ch;
      height: 2ch;
      background-color: $front-color;
    }
  }

  .badge {
    width: max-content;
    font-size: var(--font-size, 0.8rem);
    padding: var(--padding, 0.5em 1em);
    border: var(--border, 1px solid);
    border-radius: var(--border-radius, 1em);
    display: flex;
    flex-direction: row;
    align-items: center;
    gap: 1ch;
    &--blue {
      @include badge-variant(hsl(240, 100%, 60%), hsl(240, 100%, 96%));
    }
    &--gray {
      @include badge-variant(hsl(0, 0%, 30%), hsl(0, 0%, 96%));
    }
    &--green {
      @include badge-variant(hsl(100, 100%, 20%), hsl(100, 100%, 96%));
    }
  }
</style>
