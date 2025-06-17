<script lang="ts">
import { scale } from 'svelte/transition';
</script>
<div class="wrapper">
  <span transition:scale={{duration: 500}} class="loader"></span>
</div>
<style lang="scss">
.wrapper {
  width: calc(var(--font-size, 12px)*5);
  display: flex;
  justify-content: center;
}
.loader {
  transform: translateX(calc(var(--font-size, 12px)*1));
  font-size: var(--font-size, 12px);
  width: 1em;
  height: 1em;
  border-radius: 50%;
  display: block;
  /* margin:15px auto; */
  position: relative;
  color: var(--color, #FFF);
  box-sizing: border-box;
  animation: animloader 1s linear infinite alternate;
}

@keyframes animloader {
  0% {
    box-shadow: -3em -0.5em,  -1.1em 0.5em,  1.1em -0.5em;
  }
  33% {
    box-shadow: -3em 0.5em, -1.1em -0.5em,  1.1em 0.5em;
  }
  66% {
    box-shadow: -3em -0.5em,  -1.1em 0.5em, 1.1em -0.5em;
  }
  100% {
    box-shadow: -3em 0.5em,  -1.1em -0.5em, 1.1em 0.5em;
  }
}
</style>
