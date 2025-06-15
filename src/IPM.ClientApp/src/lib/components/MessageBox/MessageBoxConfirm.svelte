<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import Col from "@components/Col/Col.svelte";
  import WarningIcon from "@components/Icons/ConfirmIcons/WarningIcon.svelte";

  interface Props {
    title: string;
    description?: string;
    onYes: () => void;
    onNo: () => void;
  }

  const { title, description, onYes, onNo }: Props = $props();
</script>

<div class="message-box">
  <div class="icon-box">
    <div class="icon">
      <WarningIcon />
    </div>
  </div>
  <p class="title">{title}</p>
  {#if description != null}
    <p class="description">{description}</p>
  {/if}
  <Col --justify-content="center">
    <PrimaryButton --width="100%"  variant="orange" onclick={onYes}
      >Xác nhận</PrimaryButton
    >
    <SecondaryButton --width="100%" onclick={onNo}>Hủy</SecondaryButton>
  </Col>
</div>

<style lang="scss">
  .message-box {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0.5em;
    width: 40ch;
  }

  .icon-box {
    background-color: $warning_icon_bg_clr;
    padding: 0.7em;
    border-radius: 10px;
  }

  .icon {
    width: 2em;
    fill: $warning_icon_stroke_clr;
  }

  .title {
    font-size: 1.4rem;
    font-weight: 700;
    margin: 0.1em 0;
  }
  .description {
    font-size: 1rem;
    font-weight: 300;
    color: $text_light_clr;
    margin-bottom: 1.5em;
  }
</style>
