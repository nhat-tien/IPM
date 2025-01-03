<script lang="ts">
  type TextFieldProps = {
    label?: string;
    id: string;
    type: string;
    placeHolder: string;
    name: string;
  };
  const { type, id, label, placeHolder, name }: TextFieldProps = $props();
</script>

<div class="text-field">
{#if label != null}
  <label for={id}>{label}</label>
{/if}
<input {type} {id} placeholder={placeHolder} {name}/>
</div>

<style lang="scss">
  .text-field {
    margin-top: var(--margin-top);
    margin-bottom: var(--margin-bottom);
    width: var(--width, 100%);
 }
  input {
    padding: 0.4em 0.5em;
    border: 0.5px solid $gray-clr;
    border-radius: 5px;
    width: 100%;
    margin-top: 0.2em;
  }
  input:focus {
    border: 1px solid $secondary-clr;
  }
</style>
