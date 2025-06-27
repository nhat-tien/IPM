<script lang="ts">
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import type { PageData } from "./$types";
  import { goto, invalidate } from "$app/navigation";
  import Row from "@components/Row/Row.svelte";
  import IconButton from "@components/Button/IconButton.svelte";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
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
  import Badge from "@components/Badge/Badge.svelte";
  import { getDateOrNull } from "@utils/datetime";
  import restartProject from "@useCases/projectUseCase/restartProject";
  import reportProject from "@useCases/projectUseCase/reportProject";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import softDeleteProject from "@useCases/projectUseCase/softDeleteProject";
  import FieldDisplay from "@components/FieldDisplay/FieldDisplay.svelte";
  const { data }: { data: PageData } = $props();

  const transformParticipateToTable = (e: Participation) => {
    return [
      e.user?.lastName ?? "",
      e.user?.firstName ?? "",
      e.user?.email ?? "",
      e.role == "OWNER" ? "Chủ dự án" : "Thành viên",
    ];
  };

  let isLoadingReport = $state(false);

  const handleCancelReportProject = async () => {
    isLoadingReport = true;
    const result = await reportProject({
      id: data.id,
      isReport: false,
    });

    if (result.isSuccess) {
      isLoadingReport = false;
      invalidateCache(`project:${data.id}`);
      invalidate("project:view");
      toast.success("Đã hủy báo cáo dự án");
      closeModal();
    }
  };

  const handleReportProject = async () => {
    isLoadingReport = true;
    const result = await reportProject({
      id: data.id,
      isReport: true,
    });

    if (result.isSuccess) {
      isLoadingReport = false;
      invalidateCache(`project:${data.id}`);
      invalidate("project:view");
      toast.success("Đã gửi báo cáo dự án ");
      closeModal();
    }
  };

  const handleEndProject = async () => {
    const result = await endProject({
      id: data.id,
    });

    if (result.isSuccess) {
      invalidateCache(`project:${data.id}`);
      invalidate("project:view");
      toast.success("Cập nhật trạng thái dự án thành công");
      closeModal();
    }
  };

  const handleDeleteProject = async () => {
    const result = await softDeleteProject({
      id: data.id,
    });

    if (result.isSuccess) {
      invalidateCache(`project:${data.id}`);
      closeModal();
      toast.success("Đã xóa dự án");
      goto("/dashboard/project");
      // invalidate("project:view");
    }
  };

  const handleRestartProject = async () => {
    const result = await restartProject({
      id: data.id,
    });

    if (result.isSuccess) {
      invalidateCache(`project:${data.id}`);
      invalidate("project:view");
      toast.success("Cập nhật trạng thái dự án thành công");
      closeModal();
    }
  };

  const isEnd = $derived(getDateOrNull(data.project.endDate) != null);

  $inspect(data.project);
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
    {#snippet sideArea()}
      {#if isEnd}
        <Badge variant="gray">Đã kết thúc</Badge>
      {:else}
        <Badge variant="blue">Đang tiến hành</Badge>
      {/if}
    {/snippet}
    <Grid --grid-col="2">
      <FieldDisplay
        label="Tên dự án (Tiếng Việt)"
        content={data.project.projectNameVietnamese}
      />
      <FieldDisplay
        label="Tên dự án (Tiếng Anh)"
        content={data.project.projectNameEnglish}
      />
    </Grid>
    <FieldDisplay
      variant="textbox"
      label="Mục tiêu dự án"
      content={data.project.projectPurpose}
    />
    <FieldDisplay
      variant="textbox"
      label="Nội dung"
      content={data.project.content}
    />
    <FieldDisplay
      variant="textbox"
      label="Tiến độ dự án"
      content={data.project.projectProgress}
    />
    <FieldDisplay
      variant="textbox"
      label="Phần trăm tiến độ"
      content={data.project.percentageOfProgress}
    />
    <Grid --grid-col="2">
      <FieldDisplay
        label="Đơn vị trực thuộc"
        content={data.project.affiliatedUnit?.affiliatedUnitName}
      />
      <FieldDisplay
        label="Cơ quan phê duyệt"
        content={data.project.approvingAgency?.approvingAgencyName}
      />
      <FieldDisplay
        label="Nhà tài trợ"
        content={data.project.sponsor?.sponsorName}
      />
      <FieldDisplay
        label="Loại viện trợ"
        content={data.project.aidType?.aidTypeName}
      />
      <FieldDisplay
        label="Đối tác"
        content={data.project.counterparty?.counterpartyName}
      />
      <FieldDisplay
        label="Danh mục"
        content={data.project.category?.categoryName}
      />
    </Grid>
  </Card>
  <Card
    --card-margin-top="1em"
    title={"Thành viên"}
    description="Danh sách thành viên"
  >
    <Row></Row>
    <Table headers={["Họ lót", "Tên", "Email", "Vai trò"]}>
      {#each data.project.participations as member}
        {@const row = transformParticipateToTable(member)}
        <tr>
          <td>{row[0]}</td>
          <td>{row[1]}</td>
          <td>{row[2]}</td>
          <td>
            <Badge isHasDot={false} variant="green">{row[3]}</Badge>
          </td>
        </tr>
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
    {#if data.project.isReported}
      <BoxRowButton
        title={"Thu hồi báo cáo"}
        description={"Hủy báo cáo dự án"}
        --border-bottom="none"
        --border-top="none"
      >
        {#snippet button()}
          <PrimaryButton
            variant="orange"
            onclick={() => handleCancelReportProject()}
            isLoading={isLoadingReport}>Thu hồi</PrimaryButton
          >
        {/snippet}
      </BoxRowButton>
    {:else}
      <BoxRowButton
        title={"Báo cáo dự án"}
        description={"Gửi dự án báo cáo"}
        --border-bottom="none"
        --border-top="none"
      >
        {#snippet button()}
          <PrimaryButton
            variant="orange"
            onclick={() => handleReportProject()}
            isLoading={isLoadingReport}>Báo cáo</PrimaryButton
          >
        {/snippet}
      </BoxRowButton>
    {/if}
    {#if isEnd}
      <BoxRowButton
        title={"Khởi động lại dự án"}
        description={"Khởi động lại dự án này"}
        btnLabel={"Restart"}
        onclick={() => openModal(confirmRestart)}
        --border-bottom="none"
      />
    {:else}
      <BoxRowButton
        title={"Kết thúc dự án"}
        description={"Dự án này sẽ kết thúc và không ai có thể chỉnh sửa"}
        btnLabel={"Kết thúc"}
        onclick={() => openModal(confirmEnd)}
        --border-bottom="none"
      />
    {/if}
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

{#snippet confirmRestart()}
  <MessageBoxConfirm
    title="Bạn có chắc muốn thực hiện khởi động lại dự án?"
    description="Dự án sẽ chuyển sang trạng thái đang tiến hành"
    onYes={() => handleRestartProject()}
    onNo={() => closeModal()}
  />
{/snippet}

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
    onYes={() => handleDeleteProject()}
    onNo={() => closeModal()}
  />
{/snippet}

<style lang="scss">
  td {
    padding: 1em;
    width: max-content;
    max-width: 1000px;
    border-bottom: 1px solid $gray-clr;
  }
</style>
