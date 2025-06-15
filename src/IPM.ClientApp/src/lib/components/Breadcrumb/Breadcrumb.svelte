<script lang="ts">
  import ChevronRightIcon from "@components/Icons/ChevronRightIcon.svelte";

  const {
    listOfTitle,
  }: {
    listOfTitle: Array<{ name: string; callback: () => void }>;
  } = $props();
</script>

<div class="breadcrumb">
  {#each listOfTitle as item, index}
    <button onclick={item.callback}>{item.name}</button>
    {#if index < listOfTitle.length - 1}
      <div class="icon">
        <ChevronRightIcon --stroke="$text_light_clr" />
      </div>
    {/if}
  {/each}
</div>

<style lang="scss">
  .breadcrumb {
    font-family: "Inter Medium";
    display: flex;
    padding: 0.2em;
    flex-direction: row;
    align-items: center;
    gap: 0.5em;
    color: $text_light_clr;
  }
  .icon {
    width: 1em;
    stroke: $text_light_clr;
    @include center;
  }
  button:hover {
    color: $text-clr;
  }
</style>
