<script lang="ts">
  import type { CustomDragEvent } from "@/shared.types";
    import ArrowUpTray from "@components/Icons/ArrowUpTray.svelte";
  import TrashIcon from "@components/Icons/TrashIcon.svelte";
    import getIcon from "@utils/getIcon";

  let {
    buttonText = "Upload",
    descriptionText = "Drag or click to upload",
    maxFiles = 1,
    maxFilesCallback = () => {},
    callback,
    listFiles = true,
    trigger = () => {
      if (input) {
        input.click();
      }
    },
  }: {
    buttonText?: string;
    doneButtonText?: string;
    doneText?: string;
    descriptionText?: string;
    maxFiles?: number;
    callback: (fiels: File) => void;
    doneCallback?: () => void;
    trigger?: () => void;
    maxFilesCallback?: (files: Array<File>, maxFiles: number) => void;
    listFiles?: boolean;
  } = $props();

  let dragZone: HTMLDivElement | null = $state(null);
  let inputFiles: Array<File> = $state([]);
  let dragZoneFiles: Array<File> = $state([]);
  let input: HTMLInputElement | null = $state(null);
  let dragging: boolean = $state(false);

  let files: Array<File> = $derived.by(() => {
    return [...inputFiles, ...dragZoneFiles];
  });

  $effect(() => {
    if (files.length >= maxFiles) {
      maxFilesCallback(files, maxFiles);
      callback(files[0]);
    }
  });

  function dragover(e: CustomDragEvent) {
    e.preventDefault();
  }
  function dragenter(e: CustomDragEvent) {
    e.preventDefault();
    dragging = true;
  }
  function dragleave(e: CustomDragEvent) {
    e.preventDefault();
    dragging = false;
  }
  function drop(e: CustomDragEvent) {
    e.preventDefault();
    dragging = false;
    if (e.dataTransfer) {
      dragZoneFiles.push(
        ...[...e.dataTransfer.items]
          .filter((i) => i.kind === "file")
          .map((i) => i.getAsFile()!),
      );
      dragZoneFiles = [...dragZoneFiles];
    }
  }
  function formatBytes(a: number, b = 2, k = 1024) {
    let d = Math.floor(Math.log(a) / Math.log(k));
    return 0 == a
      ? "0 Bytes"
      : parseFloat((a / Math.pow(k, d)).toFixed(Math.max(0, b))) +
          " " +
          ["Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"][d];
  }

  function inputChanged() {
    if (input && input.files) {
      inputFiles = [...inputFiles, ...input.files];
    }
  }

  function del() {
    inputFiles = [];
    dragZoneFiles = [];
  }

  function openFile(file: File) {
    window.open(URL.createObjectURL(file), "filewin");
  }
</script>

<!-- svelte-ignore a11y_no_static_element_interactions -->
<div
  bind:this={dragZone}
  ondragover={dragover}
  ondrop={drop}
  ondragenter={dragenter}
  ondragleave={dragleave}
  class={`fileUploader dragzone ${dragging ? "dragging" : ""}`}
>
  <!-- {#if files.length !== maxFiles} -->
  {#if listFiles}
    <ul>
      {#each files.slice(0, maxFiles) as file}
        <!-- svelte-ignore a11y_click_events_have_key_events -->
        <!-- svelte-ignore a11y_no_noninteractive_element_interactions -->
        <li onclick={() => openFile(file)}>
          <span class="icon">
            <span class="fileicon">{@html getIcon(file.name)}</span>
            <span
              class="deleteicon"
              onclick={(e) => {
                del();
                e.stopPropagation();
              }}
              >
              <TrashIcon />
            </span
            >
          </span>
          <span class="filename">{file.name}</span>
          <span class="filesize">{formatBytes(file.size)}</span>
        </li>
      {/each}
    </ul>
  {/if}
  <div class="buttons">
    {#if !files.length}
      <button onclick={trigger} class="upload">
        <ArrowUpTray />
        {buttonText}
      </button>
    {/if}
  </div>
  {#if descriptionText && !files.length}
    <span class="text">{descriptionText}</span>{/if}
  <!-- {:else if maxFiles > 1} -->
  <!--   <svg -->
  <!--     xmlns="http://www.w3.org/2000/svg" -->
  <!--     xmlns:xlink="http://www.w3.org/1999/xlink" -->
  <!--     aria-hidden="true" -->
  <!--     role="img" -->
  <!--     class="iconify iconify--ph" -->
  <!--     width="32" -->
  <!--     height="32" -->
  <!--     preserveAspectRatio="xMidYMid meet" -->
  <!--     viewBox="0 0 256 256" -->
  <!--     ><path -->
  <!--       fill="currentColor" -->
  <!--       d="m150.8 86.8l-88 88a3.9 3.9 0 0 1-5.6 0l-44-44a4 4 0 1 1 5.6-5.6L60 166.3l85.2-85.1a4 4 0 1 1 5.6 5.6Zm92-5.6a3.9 3.9 0 0 0-5.6 0L152 166.3l-20.5-20.5a4 4 0 0 0-5.7 5.7l23.4 23.3a3.9 3.9 0 0 0 5.6 0l88-88a3.9 3.9 0 0 0 0-5.6Z" -->
  <!--     ></path></svg -->
  <!--   > -->
  <!--   <!-- svelte-ignore a11y_click_events_have_key_events -->
  <!--   {#if doneText}<span class="doneText" onclick={() => callback(files)} -->
  <!--       >{doneText}</span -->
  <!--     >{/if} -->
  <!-- {:else} -->
  <!--   <svg -->
  <!--     xmlns="http://www.w3.org/2000/svg" -->
  <!--     xmlns:xlink="http://www.w3.org/1999/xlink" -->
  <!--     aria-hidden="true" -->
  <!--     role="img" -->
  <!--     class="iconify iconify--ph" -->
  <!--     width="32" -->
  <!--     height="32" -->
  <!--     preserveAspectRatio="xMidYMid meet" -->
  <!--     viewBox="0 0 256 256" -->
  <!--     ><path -->
  <!--       fill="currentColor" -->
  <!--       d="M174.9 101.2a4.1 4.1 0 0 1-.1 5.7l-58.7 56a4.3 4.3 0 0 1-2.8 1.1a3.9 3.9 0 0 1-2.7-1.1l-29.4-28a4 4 0 1 1 5.6-5.8l26.5 25.4l55.9-53.4a4.1 4.1 0 0 1 5.7.1ZM228 128A100 100 0 1 1 128 28a100.2 100.2 0 0 1 100 100Zm-8 0a92 92 0 1 0-92 92a92.1 92.1 0 0 0 92-92Z" -->
  <!--     ></path></svg -->
  <!--   > -->
  <!--   {#if doneText}<span class="doneText">{doneText}</span>{/if} -->
  <!-- {/if} -->
</div>
<input
  type="file"
  hidden
  bind:this={input}
  onchange={inputChanged}
  multiple={maxFiles > 1}
/>

<style lang="scss">
  .dragzone {
    padding: 20px;
    border-radius: 6px;
    border: 2px dashed #0001;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    transition: background-color 0.3s ease;
  }
  .dragzone ul {
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
  }
  .dragzone li {
    transition: background-color 0.2s ease-in-out;
    list-style: none;
    display: flex;
    align-items: center;
    cursor: pointer;
    padding: 3px 8px;
    border-radius: 3px;
    width: max-content;
    gap: 20px;
  }
  .dragzone li:hover {
    background-color: #0001;
  }
  .dragzone .filesize {
    flex: 1;
    text-align: right;
    opacity: 0.2;
    font-style: italic;
  }
  .dragzone li .filename {
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    display: block;
    font-weight: 200;
    opacity: 0.8;
  }
  .dragzone.dragging {
    background: #0662;
  }
  /* .dragzone svg:not(li svg) { */
  /*   width: 15vw; */
  /*   height: 15vw; */
  /*   color: #777; */
  /*   opacity: 0.6; */
  /* } */
  .dragzone li .icon {
    width: 20px;
    height: 30px;
    margin-right: 10px;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .dragzone li .icon :global(svg) {
    width: 28px;
    color: #333;
  }
  .deleteicon {
    display: none;
    width: 25px;
  }
  .dragzone li:hover .fileicon {
    display: none;
  }
  .dragzone li:hover .deleteicon {
    display: block;
    cursor: pointer;
  }
  /* .dragzone .doneText { */
  /*   font-size: 1.3rem; */
  /*   color: #333; */
  /*   opacity: 0.5; */
  /*   font-weight: 200; */
  /*   font-style: italic; */
  /*   margin-top: 2rem; */
  /* } */
  .dragzone .text {
    font-style: italic;
    color: #333;
    opacity: 0.5;
    font-weight: 200;
  }
  .buttons {
    width: 40%;
    display: flex;
  }
  .buttons button {
    margin: 0 5px;
    transition: background-color 0.2s ease;
    padding: 0.5rem 1rem;
    margin-bottom: 1rem;
    flex: 1;
    border: 1px solid #0001;
    background: transparent;
    cursor: pointer;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    gap: 0.5em;
  }
  .buttons button:hover {
    background: #0001;
  }
</style>
