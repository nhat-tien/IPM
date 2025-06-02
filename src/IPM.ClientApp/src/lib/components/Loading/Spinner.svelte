<span class="loader"></span>

<style lang="scss">
  .loader {
    font-size: var(--font-size, 24px);
    box-sizing: border-box;
    position: relative;
    width: 2em;
    height: 2em;
    animation: spin 1s linear infinite;
    display: block;
  }
  .loader:after,
  .loader:before {
    content: "";
    width: 1em;
    height: 1em;
    position: absolute;
    border-radius: 50%;
    background: var(--color1, #ff722b);
    animation: spin 1s linear infinite;
    transform-origin: 0px 100%;
  }
  .loader:before {
    transform-origin: 0 50%;
    background: var(--color2, hsl(0, 0%, 97%));
  }
  @keyframes spin {
    to {
      transform: rotate(360deg);
    }
  }
</style>
