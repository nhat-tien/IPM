<script lang="ts">
  import CalendarIcon from "@components/Icons/CalendarIcon.svelte";
  import CloseCircleSolidIcon from "@components/Icons/CloseCircleSolidIcon.svelte";
  import { DateInput, type Locale } from "date-picker-svelte";

  let {
    label,
    id,
    required,
    value = $bindable(null),
  }: {
    label?: string;
    value?: Date | null | undefined;
    required?: boolean;
    id: string;
  } = $props();

  let locale: Locale = {
    months: [
      'Tháng 1',
      'Tháng 2',
      'Tháng 3',
      'Tháng 4',
      'Tháng 5',
      'Tháng 6',
      'Tháng 7',
      'Tháng 8',
      'Tháng 9',
      'Tháng 10',
      'Tháng 11',
      'Tháng 12',
    ]
  }

</script>

<div class="datepicker-container">
  {#if label}
    <label for={id}
      >{label}
      {#if required}
        <sup>*</sup>
      {/if}
    </label>
  {/if}
  <div class="datepicker-input-container">
    <DateInput
      --date-input-width="100%"
      format="dd/MM/yyyy"
      closeOnSelection={true}
      placeholder=""
      bind:value
      {locale}
    />
    {#if value != null}
      <button class="icon remove-icon" onclick={() => (value = null)}>
        <CloseCircleSolidIcon />
      </button>
    {/if}
    <div class="icon">
      <CalendarIcon --stroke="hsl(30, 0%, 30%)"/>
    </div>
  </div>
</div>

<style lang="scss">
  .datepicker-container {
    margin-top: var(--margin-top);
    margin-bottom: var(--margin-bottom);
    width: var(--width, 100%);
  }
  .datepicker-input-container {
    width: var(--width, 100%);
    position: relative;
    border-radius: 5px;
    border: 0.5px solid $gray-clr;
    margin-top: 0.2em;
  }
  :global(.date-time-field input) {
    border: none !important;
    background-color: transparent !important;
  }
  .icon {
    padding: 0.2em;
    width: 2rem;
    height: 100%;
    position: absolute;
    right: 0;
    top: 0;
    @include center;
  }
  .remove-icon {
    right: 2rem;
    width: 1.8em;
  }
</style>
