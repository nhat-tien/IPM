<script lang="ts">
    import PrimaryButton from "@components/Button/PrimaryButton.svelte";
    import TrashIcon from "@components/Icons/TrashIcon.svelte";
    import RowCenter from "@components/Row/RowCenter.svelte";
  import type {
    EditState,
    EditProjectDataPage,
  } from "@useCases/useCases.types";

  let {
    modelState = $bindable(),
    data,
  }: { modelState: EditState; data: EditProjectDataPage } = $props();

    let isShowUploadArea = $state(false);
</script>

<div class="container">
  <h2>File đính kèm</h2>
  <h3>Danh sách file</h3>
  <ul class="file-list">
    <li class="file">
      <div>
        <p class="file__filetype">File type</p>
        <p class="file__filename">File Name</p>
      </div>
          <div class="icon">
            <TrashIcon --stroke=" hsl(0, 84%, 48%)" />
          </div>
    </li>
  </ul>
  {#if !isShowUploadArea}
    <RowCenter>
      <PrimaryButton onclick={() => isShowUploadArea = true}>Thêm</PrimaryButton>
    </RowCenter>
    {:else}
    <div>

    </div>
  {/if}
</div>

<style lang="scss">
  .container {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
  }
  h2 {
    margin-bottom: 1em;
  }
  .file-list {
    margin-top: 1em;
  }
  .file {
    padding: 0.5em;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    border: 0.5px solid $gray-clr;
    border-radius: 5px;
  }
  .file__filetype {
    font-weight: 600;
  }
  .icon {
    width: 1.4em;
    @include center;
  }
</style>
