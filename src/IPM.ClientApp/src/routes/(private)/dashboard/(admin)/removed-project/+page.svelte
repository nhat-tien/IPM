<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import Row from "@components/Row/Row.svelte";
  import type { PageData } from "./$types";
  import transformProjectToTable from "@useCases/projectUseCase/transformProjectToTable";
  import { goto, invalidate } from "$app/navigation";
  import RowSkeleton from "@components/Skeleton/RowSkeleton.svelte";
  import Container from "@components/Container/Container.svelte";
  import FloatMenu from "@components/FloatMenu/FloatMenu.svelte";
  import FloatMenuItem from "@components/FloatMenu/FloatMenuItem.svelte";
  import ArrowPathIcon from "@components/Icons/ArrowPathIcon.svelte";
  import restoreProject from "@useCases/projectUseCase/restoreProject";
  import toast from "svelte-5-french-toast";
    import { invalidateCache } from "@stores/cache.svelte";

  let { data }: { data: PageData } = $props();

  let modelName = "Dự án đã xóa";
  let headers = [`Mã dự án`, `Tên dự án`, "Danh mục"];

  const handleRestoreProject = async (id: number) => {
    const result = await restoreProject({
      id: id + "",
    });
    if (result.isSuccess) {
      invalidate(`project:getAllRemove`);
      invalidateCache(`project:${id}`);
      toast.success("Khôi phục dự án thành công");
    }
  };
</script>

<TitleWebPage title={modelName} />
<BasicCenterLayout header={modelName} breadcrumb={[modelName, "Danh sách"]}>
  <Row --justify-content="flex-end">
    <PrimaryButton
      onclick={() => {
        goto("/dashboard/project/create");
      }}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </Row>
  <Container>
    <Row --padding="1em 1em 1em 1.5em"></Row>
    <Table {headers} hasAction>
      {#await data.project}
        <RowSkeleton {headers} />
      {:then listData}
        {#each transformProjectToTable(listData) as item}
          <TableRow row={item} onViewLabel="Chi tiết">
            {#snippet menu()}
              <FloatMenu>
                <FloatMenuItem>
                  <button
                    class="button-view"
                    onclick={() => handleRestoreProject(item[0])}
                  >
                    <div class="icon">
                      <ArrowPathIcon --stroke="hsl(30, 0%, 30%)" />
                    </div>
                    Khôi phục
                  </button>
                </FloatMenuItem>
              </FloatMenu>
            {/snippet}
          </TableRow>
        {/each}
      {/await}
    </Table>
    <Row --padding="1em 1em 1em 1.5em"></Row>
  </Container>
</BasicCenterLayout>

<style lang="scss">
  .icon {
    width: 1.4em;
    @include center;
  }
  button {
    display: flex;
    flex-direction: row;
    align-items: center;
    gap: 0.5em;
  }
</style>
