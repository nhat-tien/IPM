<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import type { PageData } from "./$types";
  import transformUserToTable from "@useCases/userUseCase/transformUserToTable";
  import RowSkeleton from "@components/Skeleton/RowSkeleton.svelte";
  import Container from "@components/Container/Container.svelte";
    import Row from "@components/Row/Row.svelte";
  let { data }: { data: PageData } = $props();

  let modelName = "Người dùng";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Username`,
    `Email`,
    `Họ lót`,
    `Tên`,
    `Vai trò`,
  ];
</script>

<TitleWebPage title={modelName} />
<BasicCenterLayout header={modelName} breadcrumb={[modelName, "Danh sách"]}>
  <Container>
    <Row --padding="1em 1em 1em 1.5em"></Row>
    <Table {headers}>
      {#await data.users}
        <RowSkeleton {headers} />
      {:then users}
        {#each transformUserToTable(users) as user}
          <TableRow row={user} />
        {/each}
      {/await}
    </Table>
    <Row --padding="1em 1em 1em 1.5em"></Row>
  </Container>
</BasicCenterLayout>
