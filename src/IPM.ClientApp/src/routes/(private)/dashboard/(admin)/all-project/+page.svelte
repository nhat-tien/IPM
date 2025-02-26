<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import type { PageData } from "./$types";
  import transformProjectToTable from "@useCases/projectUseCase/transformProjectToTable";
  import { goto } from "$app/navigation";
  import SquareSkeleton from "@components/Skeleton/SquareSkeleton.svelte";
    import TableSkeleton from "@components/Skeleton/TableSkeleton.svelte";

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
  <RowToRight>
    <PrimaryButton
      onclick={() => {
        goto("/dashboard/project/create");
      }}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </RowToRight>
  <Table {headers} hasAction>
    {#await data.project}
      <TableSkeleton {headers} />
    {:then listData}
      {#each transformProjectToTable(listData) as item}
        <TableRow
          row={item}
          onView={() => goto(`project/${item[0]}/view`)}
          onEdit={() => goto(`project/${item[0]}/edit`)}
        />
      {/each}
    {/await}
  </Table>
</BasicCenterLayout>
