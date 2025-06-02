<script lang="ts">
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import type { PageData } from "./$types";
  import { goto } from "$app/navigation";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import IconButton from "@components/Button/IconButton.svelte";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
  import SquareSkeleton from "@components/Skeleton/SquareSkeleton.svelte";
  import Col2 from "@components/Col/Col2.svelte";
  import FieldDisplay from "@components/FieldDisplay";
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
      --icon-size="1.3em"
    >
      {#snippet icon()}
        <PencilIcon --stroke="hsl(0, 0%, 97%)" />
      {/snippet}
      Chỉnh sửa
    </IconButton>
  </RowToRight>
  <div class="container">
    <h2>Thông tin dự án</h2>
    <Col2>
      <FieldDisplay.Root>
        <FieldDisplay.Label>
          Tên dự án (Tiếng Việt)
        </FieldDisplay.Label>
        <FieldDisplay.Content>
          {data.project.projectNameVietnamese}
        </FieldDisplay.Content>
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>
          Tên dự án (Tiếng Anh)
        </FieldDisplay.Label>
        <FieldDisplay.Content>
          {data.project.projectNameEnglish}
        </FieldDisplay.Content>
      </FieldDisplay.Root>
        Mục tiêu dự án
      <p>{data.project.projectPurpose}</p>
    </Col2>
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
    {#each data.project.participations as member}
      <div>
        <p>
          <span>{member.user?.lastName} {member.user?.firstName}</span>
          <span>
            {member.user?.email}
          </span>
        </p>
      </div>
    {/each}
  </div>
  <div class="container">
    <h2>File đính kèm</h2>
    {#await data.files}
      <SquareSkeleton />
    {:then files}
      <ul>
        {#each files as file}
          <li>{file.fileName}</li>
        {/each}
      </ul>
    {/await}
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
