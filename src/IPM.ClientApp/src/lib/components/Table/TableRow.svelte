<script lang="ts">
  import FloatMenu from "@components/FloatMenu/FloatMenu.svelte";
  import FloatMenuItem from "@components/FloatMenu/FloatMenuItem.svelte";
  import FloatMenuWrapper from "@components/FloatMenu/FloatMenuWrapper.svelte";
  import EllipsisVerticalIcon from "@components/Icons/EllipsisVerticalIcon.svelte";
  import EyeIcon from "@components/Icons/EyeIcon.svelte";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
  import TrashIcon from "@components/Icons/TrashIcon.svelte";
  import type { Snippet } from "svelte";

  interface Params {
    row: string[];
    onDelete?: () => void;
    onEdit?: () => void;
    onView?: () => void;
    onDeleteLabel?: string;
    onEditLabel?: string;
    onViewLabel?: string;
    menu?: Snippet;
  }
  const {
    row,
    onView,
    onEdit,
    onDelete,
    onViewLabel,
    onEditLabel,
    onDeleteLabel,
    menu,
  }: Params = $props();
</script>

<tr>
  {#each row as cell}
    <td>{cell}</td>
  {/each}
  {#if onEdit || onDelete || onView || menu}
    <td class="td-action">
      <div class="action">
        <FloatMenuWrapper>
          {#snippet centerChild()}
            <div class="icon">
              <EllipsisVerticalIcon />
            </div>
          {/snippet}
          {#snippet menuContainer()}
            {#if menu}
              {@render menu()}
            {:else}
              <FloatMenu>
                {#if onView}
                  <FloatMenuItem>
                    <button class="btn button-view" onclick={onView}>
                      <div class="icon">
                        <EyeIcon />
                      </div>
                      {onViewLabel ?? "Xem"}
                    </button>
                  </FloatMenuItem>
                {/if}
                {#if onEdit}
                  <FloatMenuItem>
                    <button class="btn button-edit" onclick={onEdit}>
                      <div class="icon">
                        <PencilIcon />
                      </div>
                      {onEditLabel ?? "Chỉnh sửa"}
                    </button>
                  </FloatMenuItem>
                {/if}
                {#if onDelete}
                  <FloatMenuItem>
                    <button class="btn button-delete" onclick={onDelete}>
                      <div class="icon">
                        <TrashIcon />
                      </div>
                      {onDeleteLabel ?? "Xóa"}
                    </button>
                  </FloatMenuItem>
                {/if}
              </FloatMenu>
            {/if}
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
    .icon {
      @include size(1.4em);
      @include center;
    }
  }
  .td-action {
    width: fit-content;
  }

  .btn {
    @include float-menu-item;
  }

  .button-edit {
    --icon-clr: var(--edit-500-clr);
    color: var(--edit-500-clr);
  }

  .button-view {
    --icon-clr: var(--view-500-clr);
    color: var(--view-500-clr);
  }

  .button-delete {
    --icon-clr: var(--delete-500-clr);
    color: var(--delete-500-clr);
  }
</style>
