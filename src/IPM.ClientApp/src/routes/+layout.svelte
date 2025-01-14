<script lang="ts">
  import type { Snippet } from "svelte";
  import "$lib/scss/_global.scss";
  import { Toaster } from "svelte-5-french-toast";
  import { getModal } from "@stores/modal.svelte";
  import Modal from "@components/Modal/Modal.svelte";
  const { children }: { children: Snippet } = $props();
</script>

<Toaster />
{@render children()}

{#if getModal()}
  <Modal>
    {@render getModal()?.()}
  </Modal>
{/if}



