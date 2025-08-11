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
  import Card from "@components/Card/Card.svelte";
  const { data }: { data: PageData } = $props();
</script>

<TitleWebPage title="Profile" />
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
  <Row --justify-content="flex-end">
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
  </Row>
  <Card title="Thông tin cá nhân" --card-padding="1em">
    <Row>
      <section class="avatar-container">
        {#if data.user.avatarUrl}
          <img src={getAvatar(data.user.avatarUrl)} alt="avatar" />
        {:else}
          <div class="icon">
            <UserCircle --fill="hsl(30, 0%, 30%)" />
          </div>
        {/if}
        <button class="update-avatar-btn" onclick={() => openModal(uploadAvatar)}>
          <PencilIcon />
        </button>
      </section>
      <section class="info-container">
        <table>
          <tbody>
            <tr>
              <td><p class="label">Họ và tên</p></td>
              <td><p class="data">{`${data.user.lastName} ${data.user.firstName}`}</p></td>
            </tr>
            <tr>
              <td><p class="label">Email</p></td>
              <td><p class="data">{data.user.email}</p></td>
            </tr>
            <tr>
              <td><p class="label">Giới tính</p></td>
              <td><p class="data">{Gender[data.user.sex].vietnamese}</p></td>
            </tr>
            <tr>
              <td><p class="label">Địa chỉ</p></td>
              <td><p class="data">{data.user.address}</p></td>
            </tr>
            <tr>
              <td><p class="label">Số điện thoại</p></td>
              <td><p class="data">{data.user.phoneNumber}</p></td>
            </tr>
            <tr>
              <td><p class="label">Vai trò</p></td>
              <td><p class="data">{data.user.role?.roleName}</p></td>
            </tr>
            <tr>
              <td><p class="label">Chức vụ</p></td>
              <td><p class="data">{data.user.position?.positionName}</p></td>
            </tr>
            <tr>
              <td><p class="label">Đơn vị trực thuộc</p></td>
              <td><p class="data">{data.user.affiliatedUnit?.affiliatedUnitName}</p></td>
            </tr>
          </tbody>
        </table>
      </section>
    </Row>
  </Card>
</BasicCenterLayout>

{#snippet uploadAvatar()}
  <UploadAvatar />
{/snippet}

<style lang="scss">
  .avatar-container {
    width: max-content; 
    position: relative;
    height: max-content;
    img {
      width: 15em;
      height: 15em;
      object-fit: cover;
      border-radius: 100%;
    }
    .update-avatar-btn {
      border: 2px solid $edit-clr;
      background-color: $white-clr;
      border-radius: 90%;
      position: absolute;
      width: 40px;
      height: 40px;
      top: 2px;
      right: 2px;
      padding: 7px;
    }
    .icon {
      width: 15em;
      height: 15em;
    }
  }
  .info-container {
    margin-left: 1.5em;
    flex: 1;
    td {
      padding: 3px 0;
    }
    .label {
      font-weight: 600;
    }
    .data {
      padding-left: 1em;
    }
  }
</style>
