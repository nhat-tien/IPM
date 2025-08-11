<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import FloatMenu from "@components/FloatMenu/FloatMenu.svelte";
  import FloatMenuItem from "@components/FloatMenu/FloatMenuItem.svelte";
  import type { PageData } from "./$types";
  import transformUserToTable from "@useCases/userUseCase/transformUserToTable";
  import RowSkeleton from "@components/Skeleton/RowSkeleton.svelte";
  import Row from "@components/Row/Row.svelte";
  import Card from "@components/Card/Card.svelte";
  import PlainTab from "@components/Tabs/PlainTab.svelte";
  import ArrowPathIcon from "@components/Icons/ArrowPathIcon.svelte";
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
  let currentTab = $state(0);
</script>

<TitleWebPage title={modelName} />
<BasicCenterLayout header={modelName} breadcrumb={[modelName, "Danh sách"]}>
  <Card>
    <PlainTab bind:currentTab tabs={["Danh sách", "Chờ xác nhận"]} />
    <Row --padding="1em 1em 1em 1.5em"></Row>
    {#if currentTab == 0}
      <Table {headers} hasAction={true}>
        {#await data.users}
          <RowSkeleton {headers} />
        {:then users}
          {#each transformUserToTable(users) as user}
            <TableRow row={user}>
              {#snippet menu()}
                <FloatMenu>
                  <FloatMenuItem>
                    <button class="float-menu-item" onclick={() => {}}>
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
    {:else if currentTab == 1}
      <Table {headers} hasAction={true}>
        {#await data.usersInactive}
          <RowSkeleton {headers} />
        {:then users}
          {#each transformUserToTable(users) as user}
            <TableRow row={user} />
          {/each}
        {/await}
      </Table>
    {/if}
    <Row --padding="1em 1em 1em 1.5em"></Row>
  </Card>
</BasicCenterLayout>

<style lang="scss">
.float-menu-item {
  @include float-menu-item;
}
</style>
