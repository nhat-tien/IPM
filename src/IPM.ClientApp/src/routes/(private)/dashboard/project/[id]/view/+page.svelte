<script lang="ts">
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import type { PageData } from "./$types";
  import { goto } from "$app/navigation";
  import Row from "@components/Row/Row.svelte";
  import IconButton from "@components/Button/IconButton.svelte";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
  import FieldDisplay from "@components/FieldDisplay";
  import Table from "@components/Table/Table.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import type { Participation } from "@useCases/useCases.types";
  import RowSkeleton from "@components/Skeleton/RowSkeleton.svelte";
  import Card from "@components/Card/Card.svelte";
  import BoxRowButton from "@components/BoxRow/BoxRowButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import MessageBoxConfirm from "@components/MessageBox/MessageBoxConfirm.svelte";
  import { closeModal, openModal } from "@stores/modal.svelte";
  import Grid from "@components/Grid/Grid.svelte";
  import { invalidateCache } from "@stores/cache.svelte";
  import toast from "svelte-5-french-toast";
  import endProject from "@useCases/projectUseCase/endProject";
  const { data }: { data: PageData } = $props();

  const transformParticipateToTable = (e: Participation) => {
    return [
      e.user?.lastName ?? "",
      e.user?.firstName ?? "",
      e.user?.email ?? "",
    ];
  };

  const handleEndProject = async () => {
    const result = await endProject({
      id: data.id,
    });

    if (result.isSuccess) {
      invalidateCache(`project:${data.id}`);
      toast.success("Chỉnh sửa dự án thành công");
    }
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
  <Card --card-padding="1em" title={"Thông tin dự án"}>
    <Grid --grid-col="2">
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
    </Grid>
  </Card>
  <Card
    --card-margin-top="1em"
    title={"Thành viên"}
    description="Danh sách thành viên"
  >
    <Row></Row>
    <Table headers={["Họ lót", "Tên", "Email"]}>
      {#each data.project.participations as member}
        {@const row = transformParticipateToTable(member)}
        <TableRow {row} />
      {/each}
    </Table>
    <Row></Row>
  </Card>
  <Card --card-margin-top="1em" title={"File"}>
    <Row></Row>
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
  </Card>
  <Card --card-margin-top="1em" title="Cài đặt">
    <BoxRowButton
      title={"Báo cáo dự án"}
      description={"Gửi dự án báo cáo"}
      btnLabel={"Báo cáo"}
      onclick={() => {}}
      --border-bottom="none"
      --border-top="none"
    />
    <BoxRowButton
      title={"Kết thúc dự án"}
      description={"Dự án này sẽ kết thúc và không ai có thể chỉnh sửa"}
      btnLabel={"Kết thúc"}
      onclick={() => openModal(confirmEnd)}
      --border-bottom="none"
    />
    <BoxRowButton
      title={"Xóa"}
      description={"Xóa dự án"}
      --border-bottom="none"
      --box-row-button-color="hsl(0, 84%, 48%)"
    >
      {#snippet button()}
        <SecondaryButton
          onclick={() => openModal(confirmDelete)}
          --color="hsl(0, 84%, 48%)"
          --border-color="hsl(0, 84%, 48%)">Xóa</SecondaryButton
        >
      {/snippet}
    </BoxRowButton>
  </Card>
</BasicCenterLayout>

{#snippet confirmEnd()}
  <MessageBoxConfirm
    title="Bạn có chắc muốn kết thúc?"
    description="Dự án sẽ kết thúc và không ai có thể chỉnh sửa"
    onYes={() => handleEndProject()}
    onNo={() => closeModal()}
  />
{/snippet}

{#snippet confirmDelete()}
  <MessageBoxConfirm
    title="Bạn có chắc muốn xóa?"
    onYes={() => {}}
    onNo={() => closeModal()}
  />
{/snippet}
