<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import Row from "@components/Row/Row.svelte";
  import type { PageData } from "./$types";
  import transformProjectToTable from "@useCases/projectUseCase/transformProjectToTable";
  import { goto } from "$app/navigation";
    import RowSkeleton from "@components/Skeleton/RowSkeleton.svelte";
    import Container from "@components/Container/Container.svelte";

  let { data }: { data: PageData } = $props();

  let modelName = "Dự án";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Tên ${modelName.toLowerCase()}`,
    "Danh mục",
  ];
</script>

<TitleWebPage title={modelName} />
<BasicCenterLayout header={modelName} breadcrumb={[modelName, "Danh sách"]}>
  <Row --justify-content="flex-end" >
    <PrimaryButton
      onclick={() => {
        goto("/dashboard/project/create");
      }}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </Row >
  <Container>
    <Row --padding="1em 1em 1em 1.5em"></Row>
  <Table {headers} hasAction>
    {#await data.project}
      <RowSkeleton {headers} />
    {:then listData}
      {#each transformProjectToTable(listData) as item}
        <TableRow
          row={item}
          onViewLabel="Chi tiết"
          onView={() => goto(`project/${item[0]}/view`)}
          onEdit={() => goto(`project/${item[0]}/edit`)}
        />
      {/each}
    {/await}
  </Table>
    <Row --padding="1em 1em 1em 1.5em"></Row>
  </Container>
</BasicCenterLayout>
