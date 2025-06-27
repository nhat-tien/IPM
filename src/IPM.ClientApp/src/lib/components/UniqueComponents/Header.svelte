<script lang="ts">
  import CircleAvatar from "@components/Avatar/CircleAvatar.svelte";
  import FloatMenu from "@components/FloatMenu/FloatMenu.svelte";
  import FloatMenuItem from "@components/FloatMenu/FloatMenuItem.svelte";
  import FloatMenuWrapper from "@components/FloatMenu/FloatMenuWrapper.svelte";
  import logout from "$lib/useCases/authUseCases/logoutUseCase";
  import { getUserInfo } from "@stores/userInfo.svelte";
  import IconButton from "@components/Button/IconButton.svelte";
  import LogoutIcon from "@components/Icons/LogoutIcon.svelte";
  import Row from "@components/Row/Row.svelte";
  import UserIcon from "@components/Icons/UserIcon.svelte";
  import SideBarIcon from "@components/Icons/SideBarIcon.svelte";

  interface Props {
    onClickSideBar: () => void
  }
  const { onClickSideBar }:Props = $props();
</script>

<header>
  <div class="left-pane">
    <button onclick={onClickSideBar} class="side-bar-icon">
      <SideBarIcon />
    </button>
    <a href="/dashboard" class="logo">IPM Demo</a>
  </div>
  <div class="right-pane">
    <div class="avatar">
      <FloatMenuWrapper>
        {#snippet centerChild()}
          {#await getUserInfo()}
            <CircleAvatar --radius="30px"
              >{" "}</CircleAvatar
            >
          {:then info}
            <CircleAvatar --radius="30px"
              >{info?.firstName.charAt(0)}</CircleAvatar
            >
          {/await}
        {/snippet}
        {#snippet menuContainer()}
          <FloatMenu>
            <FloatMenuItem>
              <a href="/dashboard/profile">
                <Row --padding="0.7em" --margin-top="0" --margin-bottom="0">
                  <div class="icon">
                    <UserIcon />
                  </div>
                  <div>Profile</div>
                </Row>
              </a>
            </FloatMenuItem>
            <FloatMenuItem>
              <IconButton onclick={logout}>
                {#snippet icon()}
                  <LogoutIcon --stroke="hsl(30, 0%, 50%)" />
                {/snippet}
                Đăng xuất
              </IconButton>
            </FloatMenuItem>
          </FloatMenu>
        {/snippet}
      </FloatMenuWrapper>
    </div>
  </div>
</header>

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

  .logo {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    font-family: "Inter Bold";
    width: max-content;
  }
  .icon {
    width: 1.2em;
    @include center;
  }
  .side-bar-icon {
    width: 2em;
    @include center;
  }

  .left-pane {
    display: flex;
    flex-direction: row;
    justify-content: center;
    gap: 1em;
  }
</style>
