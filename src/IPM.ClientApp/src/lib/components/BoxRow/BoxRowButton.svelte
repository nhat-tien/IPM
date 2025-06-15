<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import type { Snippet } from "svelte";

  type Props = {
    title: string;
    description?: string;
    btnLabel?: string;
    isDisableBtn?: boolean;
    button?: Snippet;
    onclick?: () => void;
  };
  const {
    title,
    description,
    btnLabel = "",
    onclick = () => {},
    isDisableBtn = false,
    button,
  }: Props = $props();
</script>

<div class="box-row">
  <div class="title-section">
    <p class="title">{title}</p>
    <p class="description">{description}</p>
  </div>
  {#if button}
    {@render button()}
  {:else}
    <PrimaryButton variant="orange" {onclick} disabled={isDisableBtn}
      >{btnLabel}</PrimaryButton
    >
  {/if}
</div>

<style lang="scss">
  .box-row {
    display: flex;
    flex-direction: row;
    padding: 1em;
    justify-content: space-between;
    border-top: var(--border-top, 1px solid $gray-clr);
    border-bottom: var(--border-bottom, 1px solid $gray-clr);
  }
  .title-section {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    gap: 0.3em;
    color: var(--box-row-button-color, $text-clr);
  }
  .title {
    font-weight: 700;
  }
  .description {
    font-size: 0.9rem;
  }
</style>
