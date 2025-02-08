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
            <FloatMenuItem>
              <a href="/dashboard/profile">
                <Row --margin-top="0" --margin-bottom="0">
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
  }
  .icon {
    width: 1.2em;
    @include center;
  }
</style>
