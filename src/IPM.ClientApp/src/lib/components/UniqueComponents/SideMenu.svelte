<script lang="ts">
  import HomeIcon from "@components/Icons/HomeIcon.svelte";
  import KeyIcon from "@components/Icons/KeyIcon.svelte";
  import ListBulletIcon from "@components/Icons/ListBulletIcon.svelte";
  import PresentationChartBarIcon from "@components/Icons/PresentationChartBarIcon.svelte";
  import RectangleStackIcon from "@components/Icons/RectangleStackIcon.svelte";
    import TrashIcon from "@components/Icons/TrashIcon.svelte";
  import UserGroupIcon from "@components/Icons/UserGroupIcon.svelte";
  import SideMenuGroup from "@components/SideMenu/SideMenuGroup.svelte";
  import SideMenuItem from "@components/SideMenu/SideMenuItem.svelte";
  import { isCurrentUserHasRole } from "@services/guardService";

  interface Props {
    isSideMenuOpen: boolean
  }
  const { isSideMenuOpen }:Props = $props();

  let isShowContent = $state(true);

  function ontransitionstart(e: TransitionEvent) {
    if(e.propertyName == "width") {
        isShowContent = false;
    }
  }

  function ontransitionend() {
    if(isSideMenuOpen) {
      isShowContent = true;
    } else {
      isShowContent = false;
    }
  }

</script>

<aside class="side-menu" class:close={!isSideMenuOpen} {ontransitionstart} {ontransitionend}>
  <div
    class="column"
    class:close={!isShowContent}
  >
    <SideMenuItem href="/dashboard">
      {#snippet icon()}
        <HomeIcon />
      {/snippet}
      {#snippet content()}
        Trang chủ
      {/snippet}
    </SideMenuItem>
    <SideMenuItem href="/dashboard/project">
      {#snippet icon()}
        <PresentationChartBarIcon />
      {/snippet}
      {#snippet content()}
        Dự án của tôi
      {/snippet}
    </SideMenuItem>
    {#await isCurrentUserHasRole(["Admin"])}
      <!-- -->
    {:then isCurrentUserHasRole} 
        {#if isCurrentUserHasRole}
          <SideMenuGroup title="Quản lí của Admin">
            {#snippet icon()}
              <KeyIcon />
            {/snippet}
            <SideMenuItem href="/dashboard/all-project">
              {#snippet icon()}
                <RectangleStackIcon />
              {/snippet}
              {#snippet content()}
                Tất cả dự án
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/removed-project">
              {#snippet icon()}
                <TrashIcon />
              {/snippet}
              {#snippet content()}
              Dự án đã xóa
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/affiliatedUnit">
              {#snippet icon()}
                <ListBulletIcon />
              {/snippet}
              {#snippet content()}
                Đơn vị trực thuộc
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/approvingAgency">
              {#snippet icon()}
                <ListBulletIcon />
              {/snippet}
              {#snippet content()}
                Cơ quan phê duyệt
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/aidType">
              {#snippet icon()}
                <ListBulletIcon />
              {/snippet}
              {#snippet content()}
                Loại viện trợ
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/currencyUnit">
              {#snippet icon()}
                <ListBulletIcon />
              {/snippet}
              {#snippet content()}
                Đơn vị tiền tệ
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/counterparty">
              {#snippet icon()}
                <ListBulletIcon />
              {/snippet}
              {#snippet content()}
                Đối tác
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/category">
              {#snippet icon()}
                <ListBulletIcon />
              {/snippet}
              {#snippet content()}
                Danh mục
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/sponsor">
              {#snippet icon()}
                <ListBulletIcon />
              {/snippet}
              {#snippet content()}
                Nhà tài trợ
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/position">
              {#snippet icon()}
                <ListBulletIcon />
              {/snippet}
              {#snippet content()}
                Chức vụ
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/fileType">
              {#snippet icon()}
                <ListBulletIcon />
              {/snippet}
              {#snippet content()}
                Loại file
              {/snippet}
            </SideMenuItem>
            <SideMenuItem href="/dashboard/users">
              {#snippet icon()}
                <UserGroupIcon />
              {/snippet}
              {#snippet content()}
                Danh sách người dùng
              {/snippet}
            </SideMenuItem>
          </SideMenuGroup>
        {/if}
    {/await}
  </div>
</aside>

<style lang="scss">
  .side-menu {
    padding: 2em 1.5em 2em 1em;
    max-height: 100%;
    overflow-x: hidden;
    overflow-y: auto;
    scrollbar-gutter: stable;
    transition: all .3s ease-in-out;
    width: 25%;
    &.close {
      width: 0;
      padding: 0;
      .column {
        display: none;
      }
    }
  }
  .column {
    display: flex;
    flex-direction: column;
    white-space: no-wrap;
    &.close {
      display: none;
    }
  }
</style>
