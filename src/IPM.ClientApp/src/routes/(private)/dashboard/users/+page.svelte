<script>
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import Table from "@components/Table/Table.svelte";
    import TableRow from "@components/Table/TableRow.svelte";
  let headers = ["Họ lót", "Tên", "Địa chỉ"];
  let content = [
    ["Nguyễn Thị", "Lan", "An Giang"],
    ["Nguyễn Thị", "Lan", "An Giang"],
  ];

</script>

<BasicCenterLayout header={"User"} breadcrumb={["Users", "List"]}> 
  <Table {headers}> 
    {#each content as row}
      <TableRow row={row} />
    {/each}
  </Table>
</BasicCenterLayout>
