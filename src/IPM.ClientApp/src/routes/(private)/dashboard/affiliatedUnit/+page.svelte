<script>
  import Breadcrumb from "@components/Breadcrumb/Breadcrumb.svelte";
  import Table from "@components/Table/Table.svelte";
  let headers = [
    "Họ lót",
    "Tên",
    "Địa chỉ",
  ];
  let breadcrumb = ["Đơn vị trực thuộc", "Danh sách"];
</script>

<Breadcrumb listOfTitle={breadcrumb} />
<h1>User</h1>
<Table {headers} {content} />

<style lang="scss">
  h1 {
    font-family: "Inter Bold";
    font-size: 2rem;
    margin: 0.5em auto 1em auto;
  }
</style>
