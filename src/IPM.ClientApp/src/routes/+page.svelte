<script lang="ts">
let count = $state(0);
</script>
<h1>Welcome to SvelteKit</h1>
<p>Visit <a href="https://svelte.dev/docs/kit">svelte.dev/docs/kit</a> to read the documentation</p>
<button onclick={() => count++}>{count}</button>
<a href="/about">About</a>
<style>
button {
  font-size: 20px;
  border: 1px solid #000; 
  padding: 1em 2em;
}
</style>
