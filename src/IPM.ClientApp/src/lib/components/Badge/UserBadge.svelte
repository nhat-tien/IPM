<script lang="ts">
    import CircleAvatar from "@components/Avatar/CircleAvatar.svelte";
  import type { User } from "@useCases/useCases.types";

  type Props = {
    user: User | undefined
  };

  const { user }: Props = $props();
</script>

{#if user}
<div class="badge">
  <div class="badge__img">
      <CircleAvatar --radius="30px"
        >{user?.firstName.charAt(0)}</CircleAvatar
      >
  </div>
  <div class="badge__info">
    <div class="badge__name">{user.lastName}{" "}{user.firstName}</div>
    <div class="badge__email">{user.email}</div>
  </div>
</div>
{/if}

<style lang="scss">
.badge {
  display: flex;
  flex-direction: row;
  align-items: center;
  padding: 0.3em;
  border-radius: 10px;
  border: 1px solid $gray-clr;
  gap: 10px;
}
.badge__info {
  display: flex;
  flex-direction: column;
}
.badge__name {
  font-weight: 600;
}
</style>
