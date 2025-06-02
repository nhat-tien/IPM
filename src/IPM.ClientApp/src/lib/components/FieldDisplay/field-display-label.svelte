<script lang="ts">
   const { children } = $props()
</script>
<div>
  {@render children()}
</div>
<style lang="scss">
div {
  margin-top: var(--margin-top, 0);
  margin-bottom: var(--margin-bottom, 0.2em);
  font-weight: 600;
}
</style>
