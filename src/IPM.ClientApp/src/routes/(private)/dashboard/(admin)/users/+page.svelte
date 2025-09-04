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
  import CheckIcon from "@components/Icons/CheckIcon.svelte";
  import verifyUser from "@useCases/userUseCase/verifyUser";
    import toast from "svelte-5-french-toast";
    import { invalidate } from "$app/navigation";
    import { invalidateCache } from "@stores/cache.svelte";
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

  async function handleVerifyUser(userId: string) {
    const result = await verifyUser(userId);
    if(result.isSuccess) {
      toast.success("Xác nhận thành công");
      invalidateCache("users");
      invalidateCache("users:inactive");
      invalidate("users:getAll");
    } else {
      toast.error("Đã xảy ra lỗi");
    }
  }
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
                      </div>
                    </button>
                  </FloatMenuItem>
                </FloatMenu>
              {/snippet}
            </TableRow>
          {/each}
        {/await}
      </Table>
    {:else if currentTab == 1}
      <Table headers={headers} hasAction={true}>
        {#await data.usersInactive}
          <RowSkeleton {headers} />
        {:then users}
          {#each transformUserToTable(users) as user}
            <TableRow row={user} >
              {#snippet menu()}
                <FloatMenu>
                  <FloatMenuItem>
                    <button class="float-menu-item" onclick={() => handleVerifyUser(user[0])}>
                      <div class="icon">
                        <CheckIcon --stroke="var(--success-500-clr)" />
                      </div>
                      Xác nhận
                    </button>
                  </FloatMenuItem>
                </FloatMenu>
              {/snippet}
            </TableRow>
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
