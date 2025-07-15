<script lang="ts">
  import type { Snippet } from "svelte";

  const { children }: { children: Snippet } = $props();
</script>

<main>
  <section class="img-container">
    <div class="inner-rec">
      <div class="float-rect">
        <img src="/images/business-businessman-giving-a-lecture-ted-talk.svg" alt="illu" />
      </div>
    </div>
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
  background-color: var(--background-clr);
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 0.5rem;
  .inner-rec {
    background-color: var(--primary-500-clr);
    width: 100%;
    height: 100%;
    border-radius: 10px;
    position: relative;
  }
}
.form-area {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
.float-rect {
  $radius: 300px;
  background-color: var(--background-clr);
  border-radius: 999px;
  position: absolute;
  width: $radius;
  height: $radius;
  bottom: calc(40% - ($radius/2));
  right: calc(50% - ($radius/2));
  overflow: hidden;
  img {
    width: 100%;
  }
}

</style>
