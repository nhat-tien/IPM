<script lang="ts">
  import CircleAvatar from "@components/Avatar/CircleAvatar.svelte";
  import FloatMenu from "@components/FloatMenu/FloatMenu.svelte";
  import FloatMenuItem from "@components/FloatMenu/FloatMenuItem.svelte";
  import FloatMenuWrapper from "@components/FloatMenu/FloatMenuWrapper.svelte";
  import logout from "$lib/useCases/authUseCases/logoutUseCase";
  import { getUserInfo } from "@stores/userInfo.svelte";

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
</style>
