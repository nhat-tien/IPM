<script lang="ts">
  import logout from "$lib/useCases/AuthUseCases/logoutUseCase";
  import CircleAvatar from "@components/Avatar/CircleAvatar.svelte";
  import FloatMenu from "@components/FloatMenu/FloatMenu.svelte";
  import FloatMenuItem from "@components/FloatMenu/FloatMenuItem.svelte";
  import FloatMenuWrapper from "@components/FloatMenu/FloatMenuWrapper.svelte";
  import BellIcon from "@components/Icons/BellIcon.svelte";
  import BookIcon from "@components/Icons/BookIcon.svelte";
  import HomeIcon from "@components/Icons/HomeIcon.svelte";
  import SideMenuGroup from "@components/SideMenu/SideMenuGroup.svelte";
  import SideMenuItem from "@components/SideMenu/SideMenuItem.svelte";


  import { getUserInfo } from "@stores/userInfo.svelte";
  import type { Snippet } from "svelte";
  const { children }: { children: Snippet } = $props();
  let info = getUserInfo();
</script>

<header>
  <div class="logo">IPM Demo</div>
  <div class="right-pane">
    <div class="avatar">
      <FloatMenuWrapper>
        {#snippet centerChild()}
          <CircleAvatar --radius="30px"
            >{info?.firstName.charAt(0)}</CircleAvatar
          >
        {/snippet}
        {#snippet menuContainer()}
          <FloatMenu>
            <FloatMenuItem>Hello</FloatMenuItem>
            <FloatMenuItem>Hello</FloatMenuItem>
            <FloatMenuItem>Hello</FloatMenuItem>
            <FloatMenuItem>
              <button onclick={logout}>Đăng xuất</button>
            </FloatMenuItem>
          </FloatMenu>
        {/snippet}
      </FloatMenuWrapper>
    </div>
  </div>
</header>
<main>
  <section class="side-menu">
    <SideMenuItem href="/dashboard">
      {#snippet icon()}
        <HomeIcon />
      {/snippet}
      {#snippet content()}
        DashBoard
      {/snippet}
    </SideMenuItem>
    <SideMenuGroup title="Project">
      <SideMenuItem href="/">
        {#snippet icon()}
          <BookIcon />
        {/snippet}
        {#snippet content()}
          New
        {/snippet}
      </SideMenuItem>
      <SideMenuItem href="/">
        {#snippet icon()}
          <BellIcon />
        {/snippet}
        {#snippet content()}
          Gi do
        {/snippet}
      </SideMenuItem>
    </SideMenuGroup>
    <SideMenuItem href="/dashboard/affiliatedUnit">
      {#snippet icon()}
        <BookIcon />
      {/snippet}
      {#snippet content()}
        Đơn vị trực thuộc
      {/snippet}
    </SideMenuItem>
    <SideMenuItem href="/dashboard/users">
      {#snippet icon()}
        <BookIcon />
      {/snippet}
      {#snippet content()}
        User
      {/snippet}
    </SideMenuItem>
  </section>
  <section class="main-center">
    {@render children()}
  </section>
</main>

<style lang="scss">
  header {
    position: absolute;
    top: 0;
    width: 100%;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    padding: 1em 2em;
    background-color: #fff;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 2px;
  }

  main {
    margin: 4rem 0 0 0;
    width: 100%;
    display: flex;
    flex-direction: row;
  }

  .side-menu {
    width: 25%;
    padding: 2em 1.5em 2em 1em;
    display: flex;
    flex-direction: column;
  }
  .main-center {
    flex: 1;
    padding: 1em;
    overflow-y: auto;
  }
  .logo {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    font-family: "Inter Bold";
  }
</style>
