<script lang="ts">
    import Grid2Column from "@components/Grid/Grid2Column.svelte";
    import CircleAvatar from "@components/Avatar/CircleAvatar.svelte";
    import Row from "@components/Row/Row.svelte";
    import { getFullName } from "@stores/userInfo.svelte";
    let name = getFullName()
</script>
<Grid2Column>
  <div class="left-pane">
    <Row --gap="1em">
      <CircleAvatar --radius="40px"
      >T</CircleAvatar
      >
      <div>
        <p class="welcome-text">Chào mừng</p>
        <p class="name">{name}</p>
      </div>
    </Row>
  </div>
  <div class="right-pane">
    <small>Phòng quan hệ doanh nghiệp</small>
    <p>Quản Lí Dự Án Quốc Tế</p>
  </div>
</Grid2Column>

<style lang="scss">
.left-pane {
  flex: 1;
  padding: 0.5em;
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
  background-color: var(--background-color, $text-second-clr);
  border-radius: 10px;
  font-family: "Inter";
  color: #fff;
  p {
    margin-top: 0.2em;
    font-family: "Inter Bold";
    font-size: 1.2rem;
  }
}
</style>
