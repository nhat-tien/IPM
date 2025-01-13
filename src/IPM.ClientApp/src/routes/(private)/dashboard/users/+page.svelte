<script>
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import Table from "@components/Table/Table.svelte";
  let headers = ["Họ lót", "Tên", "Địa chỉ"];
  let content = [["Nguyễn Thị", "Lan", "An Giang"]];
</script>

<BasicCenterLayout header={"User"} breadcrumb={["Users", "List"]}> 
  <Table {headers} {content} />
</BasicCenterLayout>
