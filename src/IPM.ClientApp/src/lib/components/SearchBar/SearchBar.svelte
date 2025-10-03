<script lang="ts">
  let {
    type,
    id,
    placeHolder,
    name,
    required,
    onfocus,
    onenter,
    value = $bindable(""),
  }: {
    id?: string;
    type?: string;
    placeHolder?: string;
    required?: boolean;
    name?: string;
    onfocus?: () => void;
    onenter?: () => void;
    value?: string;
  } = $props();

  function handleKeypress(event: KeyboardEvent) {
    if (event.key === "Enter") {
      onenter?.();
    }
  }
</script>

<div class="text-field">
  <input
    {required}
    {type}
    {id}
    placeholder={placeHolder}
    {name}
    bind:value
    {onfocus}
    onkeypress={handleKeypress}
  />
  <div class="icon">
<svg viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
    <g id="SVGRepo_iconCarrier"> 
      <g clip-path="url(#clip0_15_152)"> 
        <circle cx="10.5" cy="10.5" r="6.5" stroke="var(--text-300-clr)" stroke-linejoin="round"></circle> 
        <path d="M19.6464 20.3536C19.8417 20.5488 20.1583 20.5488 20.3536 20.3536C20.5488 20.1583 20.5488 19.8417 20.3536 19.6464L19.6464 20.3536ZM20.3536 19.6464L15.3536 14.6464L14.6464 15.3536L19.6464 20.3536L20.3536 19.6464Z" fill="var(--text-300-clr)"></path> </g> 
      <defs> <clipPath id="clip0_15_152"> <rect width="24" height="24" fill="white"></rect> </clipPath> </defs> 
      </g>
  </svg>
  </div>
</div>

<style lang="scss">
  .text-field {
    margin-top: var(--margin-top);
    margin-bottom: var(--margin-bottom);
    width: var(--width, 100%);
    position: relative;
  }
  input {
    padding: 0.4em 2em 0.4em 0.5em;
    border: 0.5px solid $gray-clr;
    border-radius: 5px;
    width: 100%;
    margin-top: 0.2em;
  }
  input:focus {
    box-shadow: var(--primary-500-clr) 0px 0px 0px 2px;
  }
  .icon {
    width: 2rem;
    position: absolute;
    top: 3px;
    right: 0;
  }
</style>
