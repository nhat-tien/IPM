<script lang="ts">
  import type { WindowMouseEvent } from "@/shared.types";
  import ChevronDownIcon from "@components/Icons/ChevronDownIcon.svelte";
  import CloseCircleSolidIcon from "@components/Icons/CloseCircleSolidIcon.svelte";
  import type { OptionType } from "@useCases/useCases.types";
  import Fuse from "fuse.js";

  let {
    value,
    items,
    label,
    placeHolder,
    required,
    error,
    errorId,
    selectFn,
  }: {
    value?: string | null;
    label?: string;
    items: OptionType[];
    required?: boolean;
    placeHolder?: string;
    error?: any[];
    errorId?: string;
    selectFn: (value: OptionType) => void;
  } = $props();

  let searchString = $state("");
  let isShowDropdown = $state(false);
  let isShowRemoveIcon = $derived(value);

  let fuse = $derived(
    new Fuse(items, {
      keys: ["name"],
    }),
  );
  let searchResults: OptionType[] = $derived.by(() => {
    if (searchString == "") {
      return items;
    }
    return fuse.search(searchString, { limit: 5 }).map((e) => e.item);
  });

  function handleSelect(selectValue: OptionType) {
    searchString = "";
    isShowDropdown = false;
    value = selectValue.name;
    selectFn(selectValue);
  }

  let container: HTMLDivElement | null = $state(null);
  let input: HTMLInputElement | null = $state(null);

  function onWindowClick(e: WindowMouseEvent) {
    if (!container) {
      return;
    }
    if (container.contains(e.target as Node) == false) {
      isShowDropdown = false;
    }
  }

  $effect(() => {
    if(input) {
      input.focus()
    }
  })
</script>

<svelte:window onclick={onWindowClick} />
<div class="select-container">
  {#if label != null}
    <p>
      {label}
      {#if required}
        <sup>*</sup>
      {/if}
    </p>
  {/if}
  <div bind:this={container} class="select-with-button">
    <div class="select">
      <button class="value-show" onclick={() => (isShowDropdown = true)}> 
        {#if value}
          <span class="value">{value}</span>
          {:else}
          <span class="placeHolder">{placeHolder}</span>
        {/if}
      </button>
      {#if isShowRemoveIcon}
        <button class="select-icon remove-icon" onclick={() => (value = null)}>
          <CloseCircleSolidIcon />
        </button>
      {:else}
        <button class="select-icon" onclick={() => (isShowDropdown = true)}>
          <ChevronDownIcon />
        </button>
      {/if}
    </div>
    {#if isShowDropdown}
      <div class="float-container">
        <div class="input">
          <input
            bind:this={input}
            type="text"
            bind:value={searchString}
            placeholder="Gõ để tìm kiếm"
          />
        </div>
        <div class="suggest-container">
          {#each searchResults as item}
            <button class="suggest-item" onclick={() => handleSelect(item)}>
              <p class="suggest-item__name">
                {item.name}
              </p>
            </button>
          {/each}
        </div>
      </div>
    {/if}
  </div>
  {#if error != null}
    <div class="error">
      {error?.filter((e) => e.path[0] === errorId)[0]?.message}
    </div>
  {/if}
</div>

<style lang="scss">
  .select {
    border: 0.5px solid $gray-clr;
    padding: 0.5em 0.8em;
    border-radius: 5px;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    .value-show {
      flex: 1;
      text-align: left;
      .placeHolder {
        color: $view-clr;
      }
    }
  }
  .select-icon {
    width: 1em;
    margin-right: 0;
    @include center;
  }
  .remove-icon {
    width: 1.4em;
  }

  .select-container {
    margin-top: var(--margin-top);
    margin-bottom: var(--margin-bottom);
    width: var(--width, 100%);
  }
  .select-with-button {
    display: flex;
    flex-direction: row;
    margin-top: 0.2em;
    position: relative;
  }
  sup {
    color: $red-clr;
  }
  .error {
    /* height: 1.2rem; */
    font-size: 0.9rem;
    color: $red-clr;
  }
  .float-container {
    position: absolute;
    z-index: 1;
    top: calc(100% + 5px);
    left: 0;
    width: 100%;
    border-radius: 5px;
    background-color: $white-clr;
    padding: 0.5em;
    box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
    input {
      padding: 0.4em 0.5em;
      border: 0.5px solid $gray-clr;
      border-radius: 5px;
      width: 100%;
      margin-top: 0.2em;
      &:focus {
        border: 1px solid $secondary-clr;
      }
    }
  }

  .suggest-item {
    padding: 0.5em;
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    width: 100%;
    margin: 0.2em 0;
    &:hover {
      background-color: $gray-clr;
    }
    &:first-child {
      border-top-left-radius: 5px;
      border-top-right-radius: 5px;
    }
    &:last-child {
      border-bottom-right-radius: 5px;
      border-bottom-left-radius: 5px;
    }
  }
</style>

