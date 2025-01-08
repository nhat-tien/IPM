<script lang="ts">
  type TextFieldProps = {
    label?: string;
    id: string;
    type: string;
    placeHolder: string;
    required?: boolean;
    name: string;
    onfocus?: () => void
  };
  const {
    type,
    id,
    label,
    placeHolder,
    name,
    required,
    onfocus,
  }: TextFieldProps = $props();
</script>

<div class="text-field">
{#if label != null}
  <label for={id}>{label}
      {#if required}
        <sup>*</sup>
  {/if}
  </label>
{/if}
<input {required} {type} {id} placeholder={placeHolder} {name} onfocus={onfocus}/>
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
  sup {
    color: $red-clr;
  }
</style>
