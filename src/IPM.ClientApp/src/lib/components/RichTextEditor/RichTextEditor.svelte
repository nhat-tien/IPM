<script lang="ts">
  import {
    Composer,
    ContentEditable,
    ToolbarRichText,
    ActionBar,
    RichTextPlugin,
    HistoryPlugin,
    ListPlugin,
    CheckListPlugin,
    HorizontalRulePlugin,
    ImagePlugin,
    generateHtmlFromNodes,
    generateNodesFromDOM,
    type LexicalEditor,
  } from "svelte-lexical";
  import {
    HeadingNode,
    QuoteNode,
    ListNode,
    ListItemNode,
    HorizontalRuleNode,
    ImageNode,
  } from "svelte-lexical";
  import { theme } from "svelte-lexical/dist/themes/default";
  import {
    $getRoot as getRoot,
    $createTextNode as createTextNode,
    $createParagraphNode as createParagraphNode,
  } from "svelte-lexical";
    import type { EditState } from "@useCases/useCases.types";

  let composer: Composer | undefined = $state();

  const initialConfig = {
    theme: theme,
    namespace: "editor",
    nodes: [
      HeadingNode,
      ListNode,
      ListItemNode,
      QuoteNode,
      HorizontalRuleNode,
      ImageNode,
    ],
    onError: (error: any) => {
      throw error;
    },
    editorState: (editor: LexicalEditor) => {
        const parser = new DOMParser();
        const dom = parser.parseFromString(value, "text/html");
        const nodes = generateNodesFromDOM(editor, dom);
        const selection = getRoot().select();
        selection.insertNodes(nodes);
    },
  };

  type Props = {
    label?: string;
    required?: boolean;
    value: string;
  };

  let { label, required = false, value = $bindable("") }: Props = $props();

  $effect(() => {
    const editor = composer?.getEditor();
    editor?.registerUpdateListener(({ editorState }) => {
      editorState.read(() => {
        const html = generateHtmlFromNodes(editor);
        value = html;
      });
    });
  });

</script>

<div class="rich-text-wrapper">
  {#if label != null}
    <p>
      {label}
      {#if required}
        <sup>*</sup>
      {/if}
    </p>
  {/if}
  <Composer {initialConfig} bind:this={composer}>
    <div class="editor-shell svelte-lexical">
      <ToolbarRichText />
      <div class="editor-container">
        <div class="editor-scroller">
          <div class="editor">
            <ContentEditable />
          </div>
        </div>
        <RichTextPlugin />
        <HistoryPlugin />
        <ListPlugin />
        <CheckListPlugin />
        <HorizontalRulePlugin />
        <ImagePlugin />

        <ActionBar />
      </div>
    </div>
  </Composer>
</div>

<style lang="scss">
  :global(.svelte-lexical .toolbar) {
    position: relative !important;
  }

  :global(.svelte-lexical .actions) {
    display: none;
  }

  :global(.svelte-lexical) {
    margin: 0;
    margin-top: 0.2em;
  }

  .rich-text-wrapper {
    margin-top: var(--margin-top);
    margin-bottom: var(--margin-bottom);
    width: var(--width, 100%);
  }
</style>
