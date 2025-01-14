<script lang="ts">
  const { row }: { row: string[] } = $props();
</script>
<tr>
  {#each row as cell}
    <td>{cell}</td>
  {/each}
</tr>
<style lang="scss">
 td {
    padding: 1em;
    width: max-content;
    max-width: 1000px;
    border-bottom: 1px solid $gray-clr;
  }

</style>
