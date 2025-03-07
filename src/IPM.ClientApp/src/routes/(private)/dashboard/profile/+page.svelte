<script lang="ts">
  import RowToRight from "@components/Row/RowToRight.svelte";
  import type { PageData } from "./$types";
  import IconButton from "@components/Button/IconButton.svelte";
  import { goto } from "$app/navigation";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import { Gender } from "@utils/getGenderFromNumber";
  import UserCircle from "@components/Icons/UserCircle.svelte";
  const { data }: { data: PageData } = $props();
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
      name: "Xem ",
      callback: () => {},
    },
  ]}
>
  <RowToRight>
    <IconButton
      onclick={() => {
        goto(`profile/edit`);
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
    <section class="avatar-container">
      <UserCircle --fill="hsl(30, 0%, 30%)" />
    </section>
    <section class="info-container">
      <h2>Thông tin cá nhân</h2>
      <h3>Họ và tên</h3>
      <p>{`${data.user.lastName} ${data.user.firstName}`}</p>
      <h3>Email</h3>
      <p>{data.user.email}</p>
      <h3>Giới tính</h3>
      <p>{Gender[data.user.sex].vietnamese}</p>
      <h3>Địa chỉ</h3>
      <p>{data.user.address}</p>
      <h3>Vai trò</h3>
      <p>{data.user.role.roleName}</p>
    </section>
  </section>
</BasicCenterLayout>

<style lang="scss">
  .container {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
    display: flex;
    flex-direction: row;
  }
  .avatar-container {
    width: 15em;
  }
  .info-container {
    flex: 1;
  }
</style>
