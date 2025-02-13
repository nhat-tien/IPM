<script lang="ts">
  import type { EventSelectElements } from "@/shared.types";
  import PlusIcon from "@components/Icons/PlusIcon.svelte";
  import type { Snippet } from "svelte";

  type SelectOption = {
    value: string;
    name: string;
  };
  type SelectProps = {
    name: string;
    label?: string;
    value?: string;
    items: SelectOption[];
    id: string;
    placeHolder: string;
    children?: Snippet;
    onclick?: () => void;
  };
  let {
    value = $bindable(""),
    items,
    label,
    id,
    placeHolder,
    name,
    children,
    onclick,
  }: SelectProps = $props();

  function onChange(target: EventSelectElements) {
    value = target.currentTarget.value;
  }
</script>

<div class="select-container">
  {#if label != null}
    <label for={id}>{label}</label>
  {/if}
  <div class="select-with-button">
    <select {name} {id} onchange={onChange}>
      <option value="" disabled selected hidden>{placeHolder}</option>
      {#if children}
        {@render children()}
      {:else}
        {#each items as item}
          <option value={item.value}>{item.name}</option>
        {/each}
      {/if}
    </select>
    <button {onclick}>
      <PlusIcon --stroke="hsl(0,100%, 100%)" />
    </button>
  </div>
</div>

<style lang="scss">
  select {
    border: 0.5px solid $gray-clr;
    padding: 0.4em 0.5em;
    border-radius: 5px 0 0 5px;
    width: var(--width, 100%);
  }

  .select-container {
    margin-top: var(--margin-top);
    margin-bottom: var(--margin-bottom);
    label {
      display: block;
    }
  }
  .select-with-button {
    display: flex;
    flex-direction: row;
    margin-top: 0.2em;
    button {
      width: 2em;
      padding: 0.2em;
      display: flex;
      justify-content: center;
      align-items: center;
      background-color: $secondary-clr;
      border-radius: 0 5px 5px 0;
      &:hover {
        opacity: 0.8;
      }
    }
  }
</style>
