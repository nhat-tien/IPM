<script lang="ts">
    import RowToRight from "@components/Row/RowToRight.svelte";
    import IconButton from "@components/Button/IconButton.svelte";
    import { goto } from "$app/navigation";
    import PencilIcon from "@components/Icons/PencilIcon.svelte";
    import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
    import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
</script>

<TitleWebPage title="Dự án - Xem chi tiết" />
<BasicCenterLayout
  header={"Profile"}
  breadcrumbWithCallback={[
    {
      name: "Profile",
      callback: () => {
        goto("/dashboard/profile");
      },
    },
    {
      name: "Chỉnh sửa",
      callback: () => {},
    },
  ]}
>
  <RowToRight>
    <IconButton
      onclick={() => {
        goto(`edit`);
      }}
      variant="orange"
      --margin-bottom="0.5em"
      --icon-size="1.3em"
    >
      {#snippet icon()}
        <PencilIcon --stroke="hsl(0, 0%, 97%)" />
      {/snippet}
      Chỉnh sửa
    </IconButton>
  </RowToRight>
<section class="container">
  <h2>Thông tin cá nhân</h2>
  <h3>Họ lót</h3>
</section>
</BasicCenterLayout>

<style lang="scss">
  .container {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
  }
</style>
