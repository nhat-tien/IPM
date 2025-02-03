<script lang="ts">
  let {
    type,
    id,
    label,
    placeHolder,
    name,
    required,
    onfocus,
    error,
    errorId = "",
    value = $bindable("")
  }:{
    label?: string;
    id: string;
    type: string;
    placeHolder: string;
    required?: boolean;
    name: string;
    onfocus?: () => void;
    error?: any[];
    errorId?: string;
    value?: string;
  } = $props();
</script>

<div class="text-field">
{#if label != null}
  <label for={id}>{label}
      {#if required}
        <sup>*</sup>
  {/if}
  </label>
{/if}
<input {required} {type} {id} placeholder={placeHolder} {name} bind:value={value} onfocus={onfocus}/>
{#if error != null}
    <div class="error">{error?.filter((e) => e.path[0] === errorId)[0]?.message}</div>
{/if}
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
  .error {
    /* height: 1.2rem; */
    font-size: 0.9rem;
    color: $red-clr;
  }
</style>

