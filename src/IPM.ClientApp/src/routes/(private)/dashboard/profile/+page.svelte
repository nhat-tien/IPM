<script lang="ts">
  import Row from "@components/Row/Row.svelte";
  import type { PageData } from "./$types";
  import IconButton from "@components/Button/IconButton.svelte";
  import { goto } from "$app/navigation";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import { Gender } from "@utils/getGenderFromNumber";
  import UserCircle from "@components/Icons/UserCircle.svelte";
  import getAvatar from "@utils/getAvatarUrl";
  import { openModal } from "@stores/modal.svelte";
  import UploadAvatar from "@components/UniqueComponents/Profile/UploadAvatar.svelte";
  const { data }: { data: PageData } = $props();

  const gender = (): 0 | 1 | 2 => {
    if(data.user.sex === 1 || data.user.sex === 2) {
      return data.user.sex;
    }
    return 0;
  }
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
  <Row --justify-content="flex-end" >
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
  </Row >
  <section class="container">
    <section class="avatar-container">
      {#if data.user.avatarUrl}
        <img src={getAvatar(data.user.avatarUrl)} alt="avatar" />
      {:else}
        <UserCircle --fill="hsl(30, 0%, 30%)" />
      {/if}
      <button class="update-avatar-btn" onclick={() => openModal(uploadAvatar)}>
        <PencilIcon />
      </button>
    </section>
    <section class="info-container">
      <h2>Thông tin cá nhân</h2>
      <h3>Họ và tên</h3>
      <p>{`${data.user.lastName} ${data.user.firstName}`}</p>
      <h3>Email</h3>
      <p>{data.user.email}</p>
      <h3>Giới tính</h3>
      <p>{Gender[gender()].vietnamese}</p>
      <h3>Địa chỉ</h3>
      <p>{data.user.address}</p>
      <h3>Số điện thoại</h3>
      <p>{data.user.phoneNumber}</p>
      <h3>Vai trò</h3>
      <p>{data.user.role?.roleName}</p>
      <h3>Chức vụ</h3>
      <p>{data.user.position?.positionName}</p>
      <h3>Đơn vị trực thuộc</h3>
      <p>{data.user.affiliatedUnit?.affiliatedUnitName}</p>
    </section>
  </section>
</BasicCenterLayout>

{#snippet uploadAvatar()}
  <UploadAvatar />
{/snippet}

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
    position: relative;
    height: max-content;
    img {
      width: 100%;
    }
    .update-avatar-btn {
      border: 2px solid $edit-clr;
      background-color: $white-clr;
      border-radius: 90%;
      position: absolute;
      width: 40px;
      height: 40px;
      bottom: 2px;
      right: 2px;
      padding: 7px;
    }
  }
  .info-container {
    margin-left: 1.5em;
    flex: 1;
    h2 {
      margin-bottom: 0.5em;
    }
    h3 {
      margin-top: 0.3em;
    }
  }
</style>
