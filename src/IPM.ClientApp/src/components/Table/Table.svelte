<script lang="ts">
  type TableProps = {
    headers: string[];
    content: any[][];
  };

  const { headers, content }: TableProps = $props();
</script>

<div class="table-container">
  <div class="row-container">Search</div>
  <div class="table-wrapper">
    <table>
      <thead>
        <tr>
          {#each headers as header}
            <th>{header}</th>
          {/each}
        </tr>
      </thead>
      <tbody>
        {#each content as row}
          <tr>
            {#each row as cell}
              <td>{cell}</td>
            {/each}
          </tr>
        {/each}
      </tbody>
    </table>
  </div>
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
    border-bottom: 1px solid $gray-clr;
  }
  .table-wrapper {
    overflow-x: auto;
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
  tbody td {
    padding: 1em;
    width: max-content;
    max-width: 1000px;
  }

  tbody tr:not(:last-child) td {
    border-bottom: 1px solid $gray-clr;
  }
</style>
