<script lang="ts">
  import CircleAvatar from "@components/Avatar/CircleAvatar.svelte";
  import type { Snippet } from "svelte";
  const { children }: { children: Snippet } = $props();
</script>

<header>
  <div class="logo">IPM Demo</div>
  <div class="right-pane">
    <div class="avatar">
      <CircleAvatar>T</CircleAvatar>
    </div>
  </div>
</header>
<main>
  <section class="side-menu">
    side-menu
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
  padding: 1em;
  background-color: #fff;
  box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 2px;
}

main {
  margin: 5rem 0 0 0;
  width: 100%;
  display: flex;
  flex-direction: row;
}

.side-menu {
  width: 25%;
}
.main-center {
  flex: 1;
}
</style>
