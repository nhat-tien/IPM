<script lang="ts">
  import type { Snippet } from "svelte";

  const { children }: { children: Snippet } = $props();
</script>

<main>
  <section class="img-container">
    <div class="inner-rec"></div>
  </section>
  <section class="form-area">
    {@render children()}
  </section>
</main>
<style lang="scss">
main {
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: row;
}
.img-container {
  width: 60%;
  background-color: $primary-clr;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 0.5rem;
  .inner-rec {
    background-color: $secondary-clr;
    width: 100%;
    height: 100%;
    border-radius: 10px;
  }
}
.form-area {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
</style>
