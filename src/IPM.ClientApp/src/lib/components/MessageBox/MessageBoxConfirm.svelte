<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import WarningIcon from "@components/Icons/WarningIcon.svelte";
  import Row from "@components/Row/Row.svelte";

  const {
    title,
    onYes,
    onNo,
  }: { title: string; onYes: () => void; onNo: () => void } = $props();
</script>

<div class="message-box">
  <div class="icon">
    <WarningIcon />
  </div>
  <p class="title">{title}</p>
  <Row --justify-content="center">
    <PrimaryButton variant="orange" onclick={onYes}>Xác nhận</PrimaryButton>
    <SecondaryButton onclick={onNo}>Hủy</SecondaryButton>
  </Row>
</div>

<style lang="scss">
.message-box {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 0.5em;
  width: 40ch;
}

.icon {
  width: 8em;
}

.title {
  font-size: 1.2rem;
}
</style>
