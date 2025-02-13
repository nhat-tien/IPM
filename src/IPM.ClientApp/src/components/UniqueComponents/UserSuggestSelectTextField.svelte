<script lang="ts">
  import type { WindowMouseEvent } from "@/shared.types";
  import type { User } from "@useCases/useCases.types";
  import Fuse from "fuse.js";

  let {
    label,
    placeHolder,
    users,
    excludeUsers,
    selectionCallback,
  }: {
    label?: string;
    placeHolder: string;
    users: User[];
    excludeUsers: User[];
    selectionCallback: (user: User) => void;
  } = $props();

  let searchString = $state("");
  let searchUsers = $derived.by(() => {
    return users.filter(e => !excludeUsers.find(x => x.email == e.email));
  });
  $inspect(searchUsers);
  let fuse = $derived(new Fuse(searchUsers, {
    keys: ["firstName", "lastName", "email"],
  }));
  let searchResults = $derived(fuse.search(searchString, { limit: 5 }));
  let isShow = $state(false);

  function handleSelect(user: User) {
    searchString = "";
    isShow = false;
    selectionCallback(user);
  }

  let container: HTMLDivElement | null = $state(null);
  function onWindowClick(e: WindowMouseEvent) {
    if (!container) {
      return;
    }
    if (container.contains(e.target as Node) == false) {
      isShow = false;
    }
  }
</script>

<svelte:window onclick={onWindowClick} />
<div bind:this={container} class="text-field">
  {#if label != null}
    <label for="userName">{label} </label>
  {/if}
  <input
    type="text"
    id="userName"
    onfocusin={() => (isShow = true)}
    bind:value={searchString}
    placeholder={placeHolder}
    name="userName"
  />
  {#if searchResults.length !== 0 && isShow}
    <div class="suggest-container">
      {#each searchResults as { item }}
        <button class="suggest-item" onclick={() => handleSelect(item)}>
          <p class="suggest-item__name">
            {`${item.lastName} ${item.firstName}`}
          </p>
          <p class="suggest-item__email">{item.email}</p>
        </button>
      {/each}
    </div>
  {/if}
</div>

<style lang="scss">
  .text-field {
    margin-top: var(--margin-top);
    margin-bottom: var(--margin-bottom);
    width: var(--width, 100%);
    position: relative;
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
  .suggest-container {
    position: absolute;
    top: calc(100% + 5px);
    left: 0;
    width: 100%;
    border-radius: 15px;
    background-color: $white-clr;
    box-shadow:
      rgba(60, 64, 67, 0.3) 0px 1px 2px 0px,
      rgba(60, 64, 67, 0.15) 0px 1px 3px 1px;
  }
  .suggest-item {
    padding: 0.5em;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    width: 100%;
    &:hover {
      background-color: $gray-clr;
    }
    &:first-child {
      border-top-left-radius: 15px;
      border-top-right-radius: 15px;
    }
    &:last-child {
      border-bottom-right-radius: 15px;
      border-bottom-left-radius: 15px;
    }
  }
  .suggest-item__name {
    font-family: "Inter SemiBold";
  }
  .suggest-item__email {
    font-size: 0.9rem;
  }
</style>
