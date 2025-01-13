<script lang="ts">
  import ClosedEyeIcon from "@components/Icons/ClosedEyeIcon.svelte";
  import EyeIcon from "@components/Icons/EyeIcon.svelte";

  type PasswordTextFieldProps = {
    label?: string;
    id: string;
    placeHolder?: string;
    name: string;
    required?: boolean;
    onfocus?: () => void;
  };
  const {
    id,
    label,
    placeHolder = "••••••••",
    name,
    required,
    onfocus,
  }: PasswordTextFieldProps = $props();
  let isHidden = $state(true);
</script>

{#if label != null}
  <label for={id}
    >{label}
    {#if required}
      <sup>*</sup>
    {/if}
  </label>
{/if}
<div class="input-container">
  <input
    {required}
    type={isHidden ? "password" : "text"}
    {name}
    {id}
    placeholder={placeHolder}
    {onfocus}
  />
  <button
    type="button"
    onclick={() => (isHidden = !isHidden)}
    class="toggle"
  >
    {#if isHidden}
      <ClosedEyeIcon />
    {:else}
      <EyeIcon />
    {/if}
  </button>
</div>

<style lang="scss">
  input {
    padding: 0.4em 0.5em;
    border: 0.5px solid $gray-clr;
    border-radius: 5px;
    width: 100%;
  }
  input:focus {
    border: 1px solid $secondary-clr;
  }
  .input-container {
    position: relative;
    margin-top: 0.2em;
    .toggle {
      position: absolute;
      right: 0.2em;
      bottom: calc(100% / 2 - 14px);
      width: 28px;
      height: 28px;
      padding: 5px;
      border-radius: 3px;
      transition: all 0.1s ease-in-out;
      &:hover {
        background-color: $gray-clr;
      }
    }
  }
  sup {
    color: $red-clr;
  }
</style>
