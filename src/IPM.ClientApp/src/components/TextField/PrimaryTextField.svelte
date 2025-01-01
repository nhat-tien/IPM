<script lang="ts">
  type TextFieldProps = {
    label?: string;
    id: string;
    type: string;
    placeHolder: string;
  };
  const { type, id, label, placeHolder }: TextFieldProps = $props();
</script>

  {#if label != null}
    <label for={id}>{label}</label>
  {/if}
  <input {type} {id} placeholder={placeHolder} />

<style lang="scss">
    input {
      padding: 0.4em 0.5em;
      border: 0.5px solid $gray-clr;
      border-radius: 5px;
      width: 100%;
        margin-top: 0.2em;
    }
    input:focus {
      border: 1px solid $text-clr;
    }
</style>
