<script lang="ts">
    import type { Snippet } from "svelte";

  type TableProps = {
      hasAction?: boolean,
    headers: string[];
    children: Snippet;
  };

  const { headers, children, hasAction }: TableProps = $props();
</script>

<div class="table-container">
  <div class="row-container"></div>
  <div class="table-wrapper">
    <table>
      <thead>
        <tr>
          {#each headers as header}
            <th>{header}</th>
          {/each}
          {#if hasAction}
            <th class="th-action"></th>
          {/if}
        </tr>
      </thead>
      <tbody>
        {@render children()}
      </tbody>
    </table>
  </div>
  <div class="row-container"></div>
</div>

<style lang="scss">
  .table-container {
    display: flex;
    flex-direction: column;
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
  }
  .row-container {
    padding: 1em 1em 1em 1.5em;
  }
  .table-wrapper {
    overflow-x: auto;
    border-top: 1px solid $gray-clr;
  }
  table {
    border-spacing: 0;
    width: max-content;
    min-width: 100%;
    table-layout: fixed;
  }
  thead {
    background-color: $primary-clr;
  }
  thead th {
    border-bottom: 1px solid $gray-clr;
    width: max-content;
    max-width: 1000px;
    text-align: left;
    padding: 0.7em 1em;
  }
  .th-action {
    width: fit-content;
    max-width: fit-content;
  }
</style>
