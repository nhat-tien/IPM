<script lang="ts">
  import type { Snippet } from "svelte";
  import "$lib/scss/_global.scss";
  import { Toaster } from "svelte-5-french-toast";
  import ModalWrapper from "@components/Modal/ModalWrapper.svelte";
  const { children }: { children: Snippet } = $props();
</script>

<Toaster />
{@render children()}
<ModalWrapper />




