<script lang="ts">
    import EyeIcon from "@components/Icons/EyeIcon.svelte";
    import PencilIcon from "@components/Icons/PencilIcon.svelte";
    import TrashIcon from "@components/Icons/TrashIcon.svelte";

  const {
    row,
    onView,
    onEdit,
    onDelete,
  }: {
    row: string[];
    onDelete?: () => void;
    onEdit?: () => void;
    onView?: () => void;
  } = $props();
</script>

<tr>
  {#each row as cell}
    <td>{cell}</td>
  {/each}
  {#if onEdit || onDelete || onView }
  <td class="td-action">
    <div class="action">
    {#if onView}
      <button class="button-view" onclick={onView}>
        <div class="icon">
        <EyeIcon --stroke="hsl(30, 0%, 30%)"/>
        </div>
        Xem
      </button>
    {/if}
    {#if onEdit}
      <button class="button-edit" onclick={onEdit}>
        <div class="icon">
          <PencilIcon --stroke="hsl(40, 84%, 48%)"/>
        </div>
        Chỉnh sửa
      </button>
    {/if}
    {#if onDelete}
      <button class="button-delete" onclick={onDelete}>
        <div class="icon">
        <TrashIcon --stroke=" hsl(0, 84%, 48%)"/>
        </div>
        Xóa
      </button>
    {/if}
    </div>
  </td>
  {/if}
</tr>

<style lang="scss">
  td {
    padding: 1em;
    width: max-content;
    max-width: 1000px;
    border-bottom: 1px solid $gray-clr;
  }
  .action {
    display: flex;
    flex-direction: row;
    gap: 0.5em;
    align-items: center;
    button {
      display: flex;
      flex-direction: row;
      align-items: center;
    }
    .icon {
      width: 1.4em;
      @include center;
    }
  }
  .td-action {
    width: fit-content;
  }
  .button-edit {
    color: $edit-clr;
  }
  .button-view {
    color: $view-clr;
  }
  .button-delete {
    color: $delete-clr;
  }
</style>
