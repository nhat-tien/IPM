<script lang="ts">
    import type { EventSelectElements } from "@/shared.types";

  type SelectOption = {
    value: string;
    name: string;
  };
  type SelectProps = {
    name: string,
    label?: string,
    value?: string,
    items: SelectOption[],
    id: string,
    placeHolder: string,
  };
  let { value = $bindable(""), items, label, id, placeHolder, name}: SelectProps = $props();

  function onChange(target: EventSelectElements) {
    value = target.currentTarget.value;
  }
</script>

{#if label != null}
  <label for={id}>{label}</label>
{/if}
<select {name} {id} onchange={onChange}> 
   <option value="" disabled selected hidden>{placeHolder}</option>
  {#each items as item}
    <option value={item.value}>{item.name}</option>
  {/each}
</select>

<style lang="scss">
  select {
    border: 0.5px solid $gray-clr;
    padding: 0.4em 0.5em;
    border-radius: 5px;
    margin-top: 0.2em;
  }
</style>
