<script lang="ts">
  import type { Snippet } from "svelte";

  const { children }: { children: Snippet } = $props();
</script>

<div class="modal-backdrop">
  <div class="modal">
    <div class="content">
      {@render children()}
    </div>
  </div>
</div>

<style lang="scss">
.modal-backdrop {
  position: absolute;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgba(0,0,0,0.5)
}
.modal {
  background-color: $white-clr;
  display: flex;
  flex-direction: column;
  border-radius: 10px;
}

.content {
  padding: 1rem 1rem 1rem 1rem;
}

</style>
