<script lang="ts">
  import type { EventSelectElements } from "@/shared.types";

  type SelectOption = {
    value: string;
    name: string;
  };
  type SelectProps = {
    name?: string;
    label?: string;
    value?: string;
    items: SelectOption[];
    id?: string;
    placeHolder?: string;
  };
  let {
    value = $bindable(""),
    items,
    label,
    id,
    placeHolder,
    name,
  }: SelectProps = $props();

  function onChange(target: EventSelectElements) {
    value = target.currentTarget.value;
  }
</script>

<div class="select-container">
{#if label != null}
  <label for={id}>{label}</label>
{/if}
<select {name} {id} onchange={onChange}>
  <option value="" disabled selected hidden>{placeHolder}</option>
  {#each items as item}
    {#if item.value == value}
      <option value={item.value} selected>{item.name}</option>
      {:else}
      <option value={item.value}>{item.name}</option>
    {/if}
  {/each}
</select>
</div>

<style lang="scss">
  select {
    border: 0.5px solid $gray-clr;
    padding: 0.4em 0.5em;
    border-radius: 5px;
    width: var(--width, 100%);
    margin-top: 0.2em;
  }
  .select-container {
    margin-top: var(--margin-top);
    margin-bottom: var(--margin-bottom);
    label {
      display: block;
    }
  }
</style>
