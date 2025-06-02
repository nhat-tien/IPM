<script lang="ts">
const { children } = $props();
</script>
<div class="col">
  {@render children()}
</div>
<style lang="scss">
.col {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
}
</style>

