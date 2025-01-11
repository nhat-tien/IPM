<script lang="ts">
    import ChevronRightIcon from "@components/Icons/ChevronRightIcon.svelte";

type BreadcrumbProps = {
  listOfTitle: string[]
}
const { listOfTitle }: BreadcrumbProps = $props();
</script>

<div class="breadcrumb">
  {#each listOfTitle as title, index}
    <div>{title}</div>
    {#if index < listOfTitle.length - 1}
      <div class="icon">
        <ChevronRightIcon 
        --stroke="$text-light-clr"
        />
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
  color: $text-light-clr;
}
.icon {
  width: 1em;
  display: flex;
  justify-content: center;
  align-items: center;
  stroke: $text-light-clr;
}
</style>
