<script lang="ts">
  import Breadcrumb from "@components/Breadcrumb/Breadcrumb.svelte";
  import type { Snippet } from "svelte";

  type BasicCenterLayoutProps = {
    header: string;
    breadcrumb?: string[];
    breadcrumbWithCallback?: Array<{ name: string; callback: () => void }>;
    children: Snippet;
  };

  const {
    header,
    breadcrumb,
    children,
    breadcrumbWithCallback,
  }: BasicCenterLayoutProps = $props();

  function addCallback(list: string[]) {
    return list.map((e) => ({
      name: e,
      callback: () => {},
    }));
  }
</script>

{#if breadcrumb}
  <Breadcrumb listOfTitle={addCallback(breadcrumb)} />
  {:else if breadcrumbWithCallback}
    <Breadcrumb listOfTitle={breadcrumbWithCallback} />
{/if}

<h1>{header}</h1>
{@render children()}

<style lang="scss">
  h1 {
    font-family: "Inter Bold";
    font-size: 2rem;
    margin: 0.5em auto 0.2em auto;
  }
</style>
