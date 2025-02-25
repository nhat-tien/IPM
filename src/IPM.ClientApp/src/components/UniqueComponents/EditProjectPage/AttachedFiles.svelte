<script lang="ts">
    import type { EditState, EditProjectDataPage } from "@useCases/useCases.types";

  let {
    modelState = $bindable(),
    data,
  }: { modelState: EditState; data: EditProjectDataPage } = $props();



</script>    
<div class="container">
      <h2>File đính kèm</h2>
    </div>
<style lang="scss">
  .container {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
  }
  h2 {
    margin-bottom: 1em;
  }
</style>

