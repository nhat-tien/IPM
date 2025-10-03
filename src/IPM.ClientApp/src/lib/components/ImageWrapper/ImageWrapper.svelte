<script lang="ts">


interface Props {
  url: string;
  alt: string;
  width: number;
  height: number;
}

const props: Props = $props();

</script>

<div class="img-wrapper" style={`width: ${props.width}px; height: ${props.height}px`}>
  <div class="loader" style={`--size: ${props.width}px`}></div>
  <img src={props.url} alt={props.alt} />
</div>

<style lang="scss">

.img-wrapper {
  width: 50px;
  height: 50px;
  display: flex;
  justify-content: center;
  align-items: center;
  overflow: hidden;
  position: relative;
  img {
    height: 100%;
    object-fit: cover;
    position: absolute;
  }
}
.loader {
    width: calc(var(--size) / 2);
    height: calc(var(--size) / 2);
    border: 5px solid var(--text-300-clr);
    border-bottom-color: transparent;
    border-radius: 50%;
    display: inline-block;
    box-sizing: border-box;
    animation: rotation 1s linear infinite;
     position: absolute;
    }

    @keyframes rotation {
    0% {
        transform: rotate(0deg);
    }
    100% {
        transform: rotate(360deg);
    }
    } 

</style>
