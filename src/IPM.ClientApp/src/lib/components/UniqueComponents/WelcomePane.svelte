<script lang="ts">
  import Grid2Column from "@components/Grid/Grid2Column.svelte";
  import CircleAvatar from "@components/Avatar/CircleAvatar.svelte";
  import Row from "@components/Row/Row.svelte";
  import { getFullName, getUserInfo } from "@stores/userInfo.svelte";
  let name = getFullName();
</script>
<Grid2Column>
  <div class="left-pane">
    <Row --gap="1em">
          {#await getUserInfo()}
            <CircleAvatar --radius="40px"
              >{" "}</CircleAvatar
            >
          {:then info}
            <CircleAvatar --radius="40px"
              >{info?.firstName.charAt(0)}</CircleAvatar
            >
          {/await}
      <div>
        <p class="welcome-text">Chào mừng</p>
        <p class="name">{name}</p>
      </div>
    </Row>
  </div>
  <div class="right-pane">
    <!-- <img width="80px" alt="illus" src="/images/coding-a-website.svg" /> -->
    <p>International Project Managament System</p>
    <p class="small">Quản Lí Dự Án Quốc Tế</p>
  </div>
</Grid2Column>

<style lang="scss">
  .left-pane {
    flex: 1;
    padding: 0.7em;
    background-color: var(--background-color, $white-clr);
    border-radius: 10px;
    border: 1px solid $gray-clr;
    .welcome-text {
      font-family: "Inter Bold";
      margin-bottom: 0.1em;
    }
    .name {
      font-size: 1.2rem;
    }
  }
  .right-pane {
    flex: 1;
    padding: 0.5em;
    background-color: var(--background-color, $white-clr);
    border-radius: 10px;
    border: 1px solid $gray-clr;
    font-family: "Inter";
    color: $text-second-clr;
    display: flex;
    flex-direction: column;
    gap: 0.5em;
    align-items: center;
    p {
      margin-top: 0.2em;
      font-family: "Inter Bold";
      font-size: 1.2rem;
    }
    .small {
      color: $text-clr;
      font-size: 0.8rem;
    }
  }
</style>
