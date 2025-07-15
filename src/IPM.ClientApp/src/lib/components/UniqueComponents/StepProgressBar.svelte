<script lang="ts">
  const { step }: { step: number } = $props();
</script>

<ul class="container">
  <li class="step-container highlight">
    <div class="step__circle">1</div>
    <div class="step__desc">Thông tin dự án</div>
  </li>
  <li class={["step-container", step > 1 ? "highlight" : ""]}>
    <div class="step__circle">2</div>
    <div class="step__desc">Thành viên</div>
  </li>
  <li class={["step-container", step > 2 ? "highlight" : ""]}>
    <div class="step__circle">3</div>
    <div class="step__desc">File đính kèm</div>
  </li>
</ul>

<style lang="scss">
  .container {
    display: flex;
    flex-direction: row;
    margin-bottom: 1rem;
  }
  .step-container:not(:first-child)::before {
    content: "";
    width: 100%;
    height: 3px;
    background-color: $gray-clr;
    position: absolute;
    top: 20px;
    right: 50%;
    z-index: -9;
  }
  .step-container {
    position: relative;
    flex: 1;
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 0.5em;
    gap: 0.5em;
  }
  .step__circle {
    border-radius: 99%;
    background-color: $white-clr;
    border: 3px solid $gray-clr;
    width: 2em;
    height: 2em;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .highlight {
    .step__circle {
      border: 3px solid var(--primary-500-clr);
    }
    &:not(:first-child)::before {
      background-color: var(--primary-500-clr);
    }
  }
</style>
