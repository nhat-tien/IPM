<script lang="ts">
  import Breadcrumb from "@components/Breadcrumb/Breadcrumb.svelte";
    import type { Snippet } from "svelte";

  type BasicCenterLayoutProps = {
    header: string;
    breadcrumb: string[];
    children: Snippet;
  };
  const { header, breadcrumb, children }: BasicCenterLayoutProps = $props();
</script>

<Breadcrumb listOfTitle={breadcrumb} />
<h1>{header}</h1>
{@render children()}

<style lang="scss">
  h1 {
    font-family: "Inter Bold";
    font-size: 2rem;
    margin: 0.5em auto 1em auto;
  }
</style>
