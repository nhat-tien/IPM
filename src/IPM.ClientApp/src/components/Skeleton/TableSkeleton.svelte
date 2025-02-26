<script lang="ts">
const { headers, col}: { headers?: string[], col?: number} = $props();
</script>

{#if headers}
  {#each headers as _}
    <td>
      <div>&nbsp;</div>
    </td>
  {/each}
  {:else if col}
  {#each { length: col} }
    <td></td>
  {/each}
{/if}

<style lang="scss">
td {
  width: max-content;
  height: 2em;
  max-width: 1000px;
}
div {
    margin-top: var(--margin-top, 0);
    margin-bottom: var(--margin-bottom, 0);
    margin-left: var(--margin-left, 0);
    margin-right: var(--margin-right, 0);
    width: var(--width, 100%);
    height: var(--height, 100%);
    border-radius: var(--radius, 0);
    animation: pulse 2s ease-in-out infinite;
    background-color: $gray-clr;
  }
  @keyframes pulse {
    50% {
      opacity: 0.5;
    }
  }
</style>

