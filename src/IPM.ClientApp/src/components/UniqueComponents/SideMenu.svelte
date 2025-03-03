<script lang="ts">
  import HomeIcon from "@components/Icons/HomeIcon.svelte";
  import KeyIcon from "@components/Icons/KeyIcon.svelte";
  import ListBulletIcon from "@components/Icons/ListBulletIcon.svelte";
  import PresentationChartBarIcon from "@components/Icons/PresentationChartBarIcon.svelte";
  import RectangleStackIcon from "@components/Icons/RectangleStackIcon.svelte";
  import UserGroupIcon from "@components/Icons/UserGroupIcon.svelte";
  import SideMenuGroup from "@components/SideMenu/SideMenuGroup.svelte";
  import SideMenuItem from "@components/SideMenu/SideMenuItem.svelte";
</script>

<aside class="side-menu">
  <div class="column">
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
  </div>
</aside>

<style lang="scss">
  .side-menu {
    width: 25%;
    padding: 2em 1.5em 2em 1em;
    max-height: 100%;
    overflow-x: hidden;
    overflow-y: auto;
    scrollbar-gutter: stable;
  }
  .column {
    display: flex;
    flex-direction: column;
  }
</style>
