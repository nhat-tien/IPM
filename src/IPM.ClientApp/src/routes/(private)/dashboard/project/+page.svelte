<script>
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import Table from "@components/Table/Table.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  let header = "Dự án";
  let modelName = "Dự án";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Tên ${modelName.toLowerCase()}`,
    "Danh mục",
  ];
</script>

<TitleWebPage title={header} />
<BasicCenterLayout {header} breadcrumb={[header, "Danh sách"]}>
  <Table {headers} hasAction>
    <TableRow row={["", "", ""]} onView={() => {}} onEdit={() => {}} />
  </Table>
</BasicCenterLayout>
