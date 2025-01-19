<script lang="ts">
  import BookIcon from "@components/Icons/BookIcon.svelte";
  import HomeIcon from "@components/Icons/HomeIcon.svelte";
  import SideMenuGroup from "@components/SideMenu/SideMenuGroup.svelte";
  import SideMenuItem from "@components/SideMenu/SideMenuItem.svelte";
</script>

<section class="side-menu">
  <div class="column">
    <SideMenuItem href="/dashboard">
      {#snippet icon()}
        <HomeIcon />
      {/snippet}
      {#snippet content()}
        Trang chủ
      {/snippet}
    </SideMenuItem>
    <SideMenuItem href="/dashboard/my-project">
      {#snippet icon()}
        <BookIcon />
      {/snippet}
      {#snippet content()}
        Dự án của tôi
      {/snippet}
    </SideMenuItem>
    <SideMenuGroup title="Quản lí của Admin">
      <SideMenuItem href="/dashboard/project">
        {#snippet icon()}
          <BookIcon />
        {/snippet}
        {#snippet content()}
          Tất cả dự án
        {/snippet}
      </SideMenuItem>
      <SideMenuItem href="/dashboard/affiliatedUnit">
        {#snippet icon()}
          <BookIcon />
        {/snippet}
        {#snippet content()}
          Đơn vị trực thuộc
        {/snippet}
      </SideMenuItem>
      <SideMenuItem href="/dashboard/approvingAgency">
        {#snippet icon()}
          <BookIcon />
        {/snippet}
        {#snippet content()}
          Cơ quan phê duyệt
        {/snippet}
      </SideMenuItem>
      <SideMenuItem href="/dashboard/aidType">
        {#snippet icon()}
          <BookIcon />
        {/snippet}
        {#snippet content()}
          Loại viện trợ
        {/snippet}
      </SideMenuItem>
      <SideMenuItem href="/dashboard/currencyUnit">
        {#snippet icon()}
          <BookIcon />
        {/snippet}
        {#snippet content()}
          Đơn vị tiền tệ
        {/snippet}
      </SideMenuItem>
      <SideMenuItem href="/dashboard/counterparty">
        {#snippet icon()}
          <BookIcon />
        {/snippet}
        {#snippet content()}
          Đối tác
        {/snippet}
      </SideMenuItem>
      <SideMenuItem href="/dashboard/category">
        {#snippet icon()}
          <BookIcon />
        {/snippet}
        {#snippet content()}
          Danh mục
        {/snippet}
      </SideMenuItem>
      <SideMenuItem href="/dashboard/sponsor">
        {#snippet icon()}
          <BookIcon />
        {/snippet}
        {#snippet content()}
          Nhà tài trợ
        {/snippet}
      </SideMenuItem>
      <SideMenuItem href="/dashboard/position">
        {#snippet icon()}
          <BookIcon />
        {/snippet}
        {#snippet content()}
          Chức vụ
        {/snippet}
      </SideMenuItem>
    </SideMenuGroup>
  </div>
</section>

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
