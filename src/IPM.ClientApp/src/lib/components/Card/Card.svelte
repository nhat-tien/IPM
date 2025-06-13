<script lang="ts">
  import type { Snippet } from "svelte";

  type Props = {
    children: Snippet;
    title?: string;
    description?: string;
  };

  const { children, title, description }: Props = $props();
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
    </div>
    <hr class="divider" />
  {/if}
  <div class="body">
    {@render children()}
  </div>
</section>

<style lang="scss">
  section {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    margin-top: var(--margin-top, 0.5em);
    margin-bottom: var(--margin-bottom, 0.5em);
  }
  .divider {
    border: 1px solid $gray-clr;
  }
  .body {
    padding: var(--card-padding, 0);
  }
  .left {
    padding: var(--padding, 1em);
  }
  .description {
    margin-top: 0.5em;
    color: $text-light-clr;
    font-size: 0.9rem;
  }
</style>
