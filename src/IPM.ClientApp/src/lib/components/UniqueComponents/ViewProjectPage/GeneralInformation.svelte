<script lang="ts">
  import Badge from "@components/Badge/Badge.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import BoxRowButton from "@components/BoxRow/BoxRowButton.svelte";
  import Card from "@components/Card/Card.svelte";
  import MessageBoxConfirm from "@components/MessageBox/MessageBoxConfirm.svelte";
  import { closeModal, openModal } from "@stores/modal.svelte";
  import FieldDisplay from "@components/FieldDisplay/FieldDisplay.svelte";
  import Grid from "@components/Grid/Grid.svelte";
  import reportProject from "@useCases/projectUseCase/reportProject";
  import type { Project } from "@useCases/useCases.types";
  import { getDateOrNull } from "@utils/datetime";
  import { invalidateCache } from "@stores/cache.svelte";
  import { goto, invalidate } from "$app/navigation";
  import toast from "svelte-5-french-toast";
  import endProject from "@useCases/projectUseCase/endProject";
  import softDeleteProject from "@useCases/projectUseCase/softDeleteProject";
  import { page } from "$app/state";
  import restartProject from "@useCases/projectUseCase/restartProject";

  type Props = {
    project: Project;
    id: string;
  };

  const { project, id }: Props = $props();

  const isEnd = $derived(getDateOrNull(project.endDate) != null);

  let isLoadingReport = $state(false);

  const handleCancelReportProject = async () => {
    isLoadingReport = true;
    const result = await reportProject({
      id: id,
      isReport: false,
    });

    if (result.isSuccess) {
      isLoadingReport = false;
      invalidateCache(`project:${id}`);
      invalidate("project:view");
      toast.success("Đã hủy báo cáo dự án");
      closeModal();
    }
  };

  const handleReportProject = async () => {
    isLoadingReport = true;
    const result = await reportProject({
      id: id,
      isReport: true,
    });

    if (result.isSuccess) {
      isLoadingReport = false;
      invalidateCache(`project:${id}`);
      invalidate("project:view");
      toast.success("Đã gửi báo cáo dự án ");
      closeModal();
    }
  };

  const handleEndProject = async () => {
    const result = await endProject({
      id: id,
    });

    if (result.isSuccess) {
      invalidateCache(`project:${id}`);
      invalidate("project:view");
      toast.success("Cập nhật trạng thái dự án thành công");
      closeModal();
    }
  };

  const handleDeleteProject = async () => {
    const result = await softDeleteProject({
      id: id,
    });

    if (result.isSuccess) {
      invalidateCache(`project:${id}`);
      closeModal();
      toast.success("Đã xóa dự án");

      if (page.url.searchParams.get("redirect") == "all-project") {
        goto("/dashboard/all-project");
      } else {
        goto("/dashboard/project");
      }
      // invalidate("project:view");
    }
  };

  const handleRestartProject = async () => {
    const result = await restartProject({
      id: id,
    });

    if (result.isSuccess) {
      invalidateCache(`project:${id}`);
      invalidate("project:view");
      toast.success("Cập nhật trạng thái dự án thành công");
      closeModal();
    }
  };
</script>

<Card --card-margin-top="1em" --card-padding="1em" title={"Thông tin dự án"}>
  {#snippet sideArea()}
    {#if isEnd}
      <Badge variant="gray">Đã kết thúc</Badge>
    {:else}
      <Badge variant="blue">Đang tiến hành</Badge>
    {/if}
  {/snippet}
  <p class="project-name">{project.projectNameVietnamese}</p>
  <p class="project-name-en">{project.projectNameEnglish}</p>
  <Grid --grid-col="2">
    <FieldDisplay
      label="Đơn vị trực thuộc"
      content={project.affiliatedUnit?.affiliatedUnitName}
    />
    <FieldDisplay
      label="Cơ quan phê duyệt"
      content={project.approvingAgency?.approvingAgencyName}
    />
    <FieldDisplay label="Nhà tài trợ" content={project.sponsor?.sponsorName} />
    <FieldDisplay
      label="Loại viện trợ"
      content={project.aidType?.aidTypeName}
    />
    <FieldDisplay
      label="Đối tác"
      content={project.counterparty?.counterpartyName}
    />
    <FieldDisplay label="Danh mục" content={project.category?.categoryName} />
  </Grid>
  <FieldDisplay
    variant="textbox"
    label="Mục tiêu dự án"
    content={project.projectPurpose}
  />
  <FieldDisplay variant="html" label="Nội dung" content={project.content} />
  <FieldDisplay
    variant="textbox"
    label="Tiến độ dự án"
    content={project.projectProgress}
  />
  <FieldDisplay
    variant="textbox"
    label="Phần trăm tiến độ"
    content={project.percentageOfProgress}
  />
</Card>

<Card --card-margin-top="1em" title="Cài đặt">
  {#if project.isReported}
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
  .project-name {
    font-size: 2rem;
    font-weight: 600;
    text-align: left;
  }

  .project-name-en {
    text-align: left;
    font-size: 1.5rem;
    color: var(--text-400-clr);
    margin-bottom: 3em;
    font-style: italic;
  }
</style>
