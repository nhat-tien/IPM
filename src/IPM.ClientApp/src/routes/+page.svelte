<script lang="ts">
import userInfoStore from "@stores/userInfo.svelte";
const { userName, role }= userInfoStore();
let count = $state(0);

</script>
<h1>Welcome to SvelteKit</h1>
<p>Visit <a href="https://svelte.dev/docs/kit">svelte.dev/docs/kit</a> to read the documentation</p>
<button onclick={() => count++}>{count}</button>
<a href="/about">About</a>
<div>
  { userName }
</div>
<div>
  { role }
</div>
<style lang="scss">
</style>
