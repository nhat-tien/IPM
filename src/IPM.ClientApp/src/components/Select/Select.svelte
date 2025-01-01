<script lang="ts">
  type SelectOption = {
    value: string;
    name: string;
  };
  type SelectProps = {
    value: string,
    items: SelectOption[];
  };
  let { value = $bindable(""), items }: SelectProps = $props();

  function onChange(target: EventSelectElements) {
    value = target.currentTarget.value;
  }
</script>

<select onchange={onChange}>
  {#each items as item}
    <option value={item.value}>{item.name}</option>
  {/each}
</select>

<style lang="scss">
  select {
    border: 0.5px solid $gray-clr;
    padding: 0.4em 0.5em;
    border-radius: 5px;
  }
</style>
