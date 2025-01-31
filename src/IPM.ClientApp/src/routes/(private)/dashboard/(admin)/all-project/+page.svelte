<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import type { PageData } from "./$types";
  // import type { Project } from "@useCases/useCases.types";
  import transformProjectToTable from "@useCases/projectUseCase/transformProjectToTable";
    import { goto } from "$app/navigation";

  // type ProjectUpdateDto = Omit<Project, "createdAt" | "updatedAt">;
  let { data }: { data: PageData } = $props();

  let modelName = "Dự án";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Tên ${modelName.toLowerCase()}`,
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
  <Table {headers}>
    {#await data.project}
      <div>Loading</div>
    {:then listData}
      {#each transformProjectToTable(listData) as item}
        <TableRow row={item} />
      {/each}
    {/await}
  </Table>
</BasicCenterLayout>

<style lang="scss">
</style>
