<div></div>

<style lang="scss">
  div {
    margin-top: var(--margin-top, 0);
    margin-bottom: var(--margin-bottom, 0);
    margin-left: var(--margin-left, 0);
    margin-right: var(--margin-right, 0);
    width: var(--width, 100%);
    height: var(--height, 100%);
    border-radius: var(--radius, 0);
    animation: pulse 2s ease-in-out infinite;
    background-color: $gray-clr;
  }
  @keyframes pulse {
    50% {
      opacity: 0.5;
    }
  }
</style>
