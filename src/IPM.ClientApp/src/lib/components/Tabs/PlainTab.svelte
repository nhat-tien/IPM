<script lang="ts">
  type Props = {
    tabs: string[];
    currentTab: number;
  };

  let { tabs, currentTab = $bindable() }: Props = $props();
</script>

<div class="tabs">
  {#each tabs as tab, i}
    <div class={ [ "tab", currentTab == i ? "active" : ""] }>
      <button class="tab__click-area" onclick={() => (currentTab = i)}>
        {tab}
      </button>
    </div>
  {/each}
</div>

<style lang="scss">

.tabs {
  display: flex;
  flex-direction: row;
  padding: 0.5em;
}
.tab {
  border-top-left-radius: 10px;
  border-top-right-radius: 10px;
  font-weight: 600;
  color: var(--text-300-clr);
  transition: background-color .1s ease-in-out;
  &:hover {
    background-color: var(--primary-900-clr);
  }
  &.active {
    color: var(--text-500-clr);
    border-bottom: 3px solid var(--primary-500-clr);
    font-weight: 600;
  }
}
.tab__click-area {
  padding: 0.7em 1em;
}
</style>
