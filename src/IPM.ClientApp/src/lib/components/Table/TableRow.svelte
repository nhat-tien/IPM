<script lang="ts">
  import FloatMenu from "@components/FloatMenu/FloatMenu.svelte";
  import FloatMenuItem from "@components/FloatMenu/FloatMenuItem.svelte";
  import FloatMenuWrapper from "@components/FloatMenu/FloatMenuWrapper.svelte";
  import EllipsisVerticalIcon from "@components/Icons/EllipsisVerticalIcon.svelte";
  import EyeIcon from "@components/Icons/EyeIcon.svelte";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
  import TrashIcon from "@components/Icons/TrashIcon.svelte";

  interface Params {
    row: string[];
    onDelete?: () => void;
    onEdit?: () => void;
    onView?: () => void;
    onDeleteLabel?: string; 
    onEditLabel?: string;
    onViewLabel?: string; 
  }
  const { row, onView, onEdit, onDelete, onViewLabel, onEditLabel, onDeleteLabel }: Params = $props();

</script>

<tr>
  {#each row as cell}
    <td>{cell}</td>
  {/each}
  {#if onEdit || onDelete || onView}
    <td class="td-action">
      <div class="action">
        <FloatMenuWrapper>
          {#snippet centerChild()}
            <div class="icon">
              <EllipsisVerticalIcon />
            </div>
          {/snippet}
          {#snippet menuContainer()}
            <FloatMenu>
              {#if onView}
                <FloatMenuItem>
                  <button class="button-view" onclick={onView}>
                    <div class="icon">
                      <EyeIcon --stroke="hsl(30, 0%, 30%)" />
                    </div>
                    {onViewLabel ?? "Xem"}
                  </button>
                </FloatMenuItem>
              {/if}
              {#if onEdit}
                <FloatMenuItem>
                  <button class="button-edit" onclick={onEdit}>
                    <div class="icon">
                      <PencilIcon --stroke="hsl(40, 84%, 48%)" />
                    </div>
                    {onEditLabel ?? "Chỉnh sửa"}
                  </button>
                </FloatMenuItem>
              {/if}
              {#if onDelete}
                <FloatMenuItem>
                  <button class="button-delete" onclick={onDelete}>
                    <div class="icon">
                      <TrashIcon --stroke=" hsl(0, 84%, 48%)" />
                    </div>
                    {onDeleteLabel ?? "Xóa"}
                  </button>
                </FloatMenuItem>
              {/if}
            </FloatMenu>
          {/snippet}
        </FloatMenuWrapper>
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
      gap: 0.5em;
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
