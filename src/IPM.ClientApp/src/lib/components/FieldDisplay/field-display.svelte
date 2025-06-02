<script lang="ts">
   const { children } = $props()
</script>
<div>
  {@render children()}
</div>
<style lang="scss">
div {
  margin-top: var(--margin-top, 0.5em);
  margin-bottom: var(--margin-bottom, 0.5em);
}
</style>

