<script lang="ts">
  import type { EventSelectElements } from "@/shared.types";
  import PlusIcon from "@components/Icons/PlusIcon.svelte";
  import type { OptionType } from "@useCases/useCases.types";
  import type { Snippet } from "svelte";

  let {
    value = $bindable(""),
    items,
    label,
    id,
    placeHolder,
    name,
    required,
    error,
    errorId,
    children,
    onclick,
  }: {
    name: string;
    label?: string;
    value?: string;
    items: OptionType[];
    id: string;
    required?: boolean;
    placeHolder: string;
    error?: any[];
    errorId?: string;
    children?: Snippet;
    onclick?: () => void;
  } = $props();

  function onChange(target: EventSelectElements) {
    value = target.currentTarget.value;
  }
</script>

<div class="select-container">
  {#if label != null}
    <label for={id}
      >{label}
      {#if required}
        <sup>*</sup>
      {/if}
    </label>
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
{#if error != null}
    <div class="error">{error?.filter((e) => e.path[0] === errorId)[0]?.message}</div>
{/if}
</div>

<style lang="scss">
  select {
    border: 0.5px solid $gray-clr;
    padding: 0.4em 0.5em;
    border-radius: 5px 0 0 5px;
    width: 100%;
  }

  .select-container {
    margin-top: var(--margin-top);
    margin-bottom: var(--margin-bottom);
    width: var(--width, 100%);
    label {
      display: block;
      margin-top: 0.2em;
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
      background-color: var(--primary-500-clr);
      border-radius: 0 5px 5px 0;
      &:hover {
        opacity: 0.8;
      }
    }
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
