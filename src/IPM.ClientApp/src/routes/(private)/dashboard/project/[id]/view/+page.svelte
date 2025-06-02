<script lang="ts">
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import type { PageData } from "./$types";
  import { goto } from "$app/navigation";
  import Row from "@components/Row/Row.svelte";
  import IconButton from "@components/Button/IconButton.svelte";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
  import Col2 from "@components/Col/Col2.svelte";
  import FieldDisplay from "@components/FieldDisplay";
  import Table from "@components/Table/Table.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import type { Participation } from "@useCases/useCases.types";
  import Container from "@components/Container/Container.svelte";
  import Title from "@components/Title/Title.svelte";
  import TitleRow from "@components/Row/TitleRow.svelte";
  import RowSkeleton from "@components/Skeleton/RowSkeleton.svelte";
  const { data }: { data: PageData } = $props();

  const transformParticipateToTable = (e: Participation) => {
    return [
      e.user?.lastName ?? "",
      e.user?.firstName ?? "",
      e.user?.email ?? "",
    ];
  };
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
  <Row --justify-content="flex-end">
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
  </Row>
  <div class="container">
    <h2>Thông tin dự án</h2>
    <Col2>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Tên dự án (Tiếng Việt)</FieldDisplay.Label>
        <FieldDisplay.Content>
          {data.project.projectNameVietnamese}
        </FieldDisplay.Content>
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Tên dự án (Tiếng Anh)</FieldDisplay.Label>
        <FieldDisplay.Content>
          {data.project.projectNameEnglish}
        </FieldDisplay.Content>
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Mục tiêu dự án</FieldDisplay.Label>
        <FieldDisplay.Content>
          {data.project.projectPurpose}
        </FieldDisplay.Content>
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Nội dung</FieldDisplay.Label>
        <FieldDisplay.Content>{data.project.content}</FieldDisplay.Content>
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Tiến độ dự án</FieldDisplay.Label>
        <FieldDisplay.Content
          >{data.project.projectProgress}</FieldDisplay.Content
        >
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Phần trăm tiến độ</FieldDisplay.Label>
        <FieldDisplay.Content
          >{data.project.percentageOfProgress}</FieldDisplay.Content
        >
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Đơn vị trực thuộc</FieldDisplay.Label>
        <FieldDisplay.Content
          >{data.project.affiliatedUnit
            ?.affiliatedUnitName}</FieldDisplay.Content
        >
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Cơ quan phê duyệt</FieldDisplay.Label>
        <FieldDisplay.Content
          >{data.project.approvingAgency
            ?.approvingAgencyName}</FieldDisplay.Content
        >
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Nhà tài trợ</FieldDisplay.Label>
        <FieldDisplay.Content
          >{data.project.sponsor?.sponsorName}</FieldDisplay.Content
        >
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Loại viện trợ</FieldDisplay.Label>
        <FieldDisplay.Content
          >{data.project.aidType?.aidTypeName}</FieldDisplay.Content
        >
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Đối tác</FieldDisplay.Label>
        <FieldDisplay.Content
          >{data.project.counterparty?.counterpartyName}</FieldDisplay.Content
        >
      </FieldDisplay.Root>
      <FieldDisplay.Root>
        <FieldDisplay.Label>Danh mục</FieldDisplay.Label>
        <FieldDisplay.Content
          >{data.project.category?.categoryName}</FieldDisplay.Content
        >
      </FieldDisplay.Root>
    </Col2>
  </div>
  <Container --margin-top="1em">
    <TitleRow --margin-bottom="1em" --margin-top="0">
      <Title>Thành viên</Title>
    </TitleRow>
    <Table headers={["Họ lót", "Tên", "Email"]}>
      {#each data.project.participations as member}
        {@const row = transformParticipateToTable(member)}
        <TableRow {row} />
      {/each}
    </Table>
    <Row></Row>
  </Container>
  <Container --margin-top="1em">
    <TitleRow --margin-bottom="1em" --margin-top="0">
      <Title>File</Title>
    </TitleRow>
    <Table headers={["Tên File"]}>
      {#await data.files}
        <RowSkeleton col={1} />
      {:then files}
        {#each files as file}
          <TableRow row={[file.fileName]} />
        {/each}
      {/await}
    </Table>
    <Row></Row>
  </Container>
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
</style>
