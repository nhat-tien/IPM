<script lang="ts">
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import type { PageData } from "./$types";
  import { goto } from "$app/navigation";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import IconButton from "@components/Button/IconButton.svelte";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
  const { data }: { data: PageData } = $props();
</script>

<TitleWebPage title="Dự án - Xem chi tiết" />
<BasicCenterLayout
  header={"Dự án"}
  breadcrumbWithCallback={[
    {
      name: "Dự án",
      callback: () => {
        goto("/dashboard/all-project");
      },
    },
    {
      name: "Xem chi tiết",
      callback: () => {},
    },
  ]}
>
  <RowToRight>
    <IconButton
      onclick={() => {
        goto(`/dashboard/project/${data.id}/edit`);
      }}
      variant="orange"
      --margin-bottom="0.5em"
    >
      {#snippet icon()}
        <PencilIcon --stroke="hsl(0, 0%, 97%)" />
      {/snippet}
      Chỉnh sửa
    </IconButton>
  </RowToRight>
  <div class="container">
    <h2>Thông tin dự án</h2>
    <h3>Tên dự án (Tiếng Việt)</h3>
    <p>{data.project.projectNameVietnamese}</p>
    <h3>Tên dự án (Tiếng Anh)</h3>
    <p>{data.project.projectNameEnglish}</p>
    <h3>Mục tiêu dự án</h3>
    <p>{data.project.projectPurpose}</p>
    <h3>Nội dung</h3>
    <p>{data.project.content}</p>
    <h3>Tiến độ dự án</h3>
    <p>{data.project.projectProgress}</p>
    <h3>Phần trăm tiến độ</h3>
    <p>{data.project.percentageOfProgress}</p>
    <h3>Đơn vị trực thuộc</h3>
    <p>{data.project.affiliatedUnit?.affiliatedUnitName}</p>
    <h3>Cơ quan phê duyệt</h3>
    <p>{data.project.approvingAgency?.approvingAgencyName}</p>
    <h3>Nhà tài trợ</h3>
    <p>{data.project.sponsor?.sponsorName}</p>
    <h3>Loại viện trợ</h3>
    <p>{data.project.aidType?.aidTypeName}</p>
    <h3>Đối tác</h3>
    <p>{data.project.counterparty?.counterpartyName}</p>
    <h3>Danh mục</h3>
    <p>{data.project.category?.categoryName}</p>
  </div>
  <div class="container">
    <h2>Thành viên</h2>
  </div>
  <div class="container">
    <h2>File đính kèm</h2>
  </div>
</BasicCenterLayout>

<style lang="scss">
  .container {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
  }
  h2 {
    margin-bottom: 1em;
  }
  h3 {
    font-size: 0.95rem;
    font-weight: 600;
    margin: 1.5em 0 0.5em 0;
  }
</style>
