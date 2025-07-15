<script lang="ts">
   type Props = {
     label?: string 
     content?: string 
     variant?: "text" | "textbox" | "html"
   }
   const { label, content, variant = "text"}: Props = $props()
</script>
<div class="field-display">
  <div class="label">{label}</div>
  {#if variant == "text" }
  <div class="content--text">{content}</div>
  {:else if variant == "html"}
    <div class="content--block">
      {@html content}
    </div>
  {:else}
  <div class="content--block">{content}</div>
  {/if}
</div>
<style lang="scss">
.field-display {
  margin-top: var(--margin-top, 0.5em);
  margin-bottom: var(--margin-bottom, 0.2em);
  display: flex;
  flex-direction: var(--flex-direction, column);
  gap: var(--gap, 0.3em)
}
.label {
  font-weight: 600;
}

.content {
  &--block {
    border: 1px solid $gray-clr;
    border-radius: 10px;
    padding: 1em;
    height: 200px;
    overflow-y: auto;
  }
}
</style>


