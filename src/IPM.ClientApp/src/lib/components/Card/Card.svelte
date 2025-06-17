<script lang="ts">
  import type { Snippet } from "svelte";

  type Props = {
    children: Snippet;
    title?: string;
    description?: string;
    sideArea?: Snippet
  };

  const { children, title, description, sideArea }: Props = $props();
</script>

<section>
  {#if title}
    <div class="heading">
      <div class="left">
        <h3 class="title">{title}</h3>
        {#if description}
          <p class="description">{description}</p>
        {/if}
      </div>
      {#if sideArea}
      <div class="right">
          {@render sideArea()}
      </div>
      {/if}
    </div>
  {/if}
  <div class="body">
    {@render children()}
  </div>
</section>

<style lang="scss">

  $header-padding: var(--padding, 1em);

  section {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    margin-top: var(--card-margin-top, 0.5em);
    margin-bottom: var(--card-margin-bottom, 0.5em);
  }
  .body {
    padding: var(--card-padding, 0);
  }
  .description {
    margin-top: 0.5em;
    color: $text_light_clr;
    font-size: 0.9rem;
  }
  .heading {
    border-bottom: 1px solid $gray-clr;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    padding: $header-padding;
  }
</style>
