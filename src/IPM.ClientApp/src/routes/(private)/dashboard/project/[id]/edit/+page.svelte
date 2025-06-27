<script lang="ts">
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import type { PageData } from "./$types";
  import type {
    EditState,
    ParticipationReduce,
  } from "@useCases/useCases.types";
  import Tabs from "@components/Tabs/Tabs.svelte";
  import TabItem from "@components/Tabs/TabItem.svelte";
  import GeneralInformation from "@components/UniqueComponents/EditProjectPage/GeneralInformation.svelte";
  import Members from "@components/UniqueComponents/EditProjectPage/Members.svelte";
  import AttachedFiles from "@components/UniqueComponents/EditProjectPage/AttachedFiles.svelte";
  import { getDateOrNull } from "@utils/datetime";
  import IconButton from "@components/Button/IconButton.svelte";
  import Row from "@components/Row/Row.svelte";
  import ArrowLeftIcon from "@components/Icons/ArrowLeftIcon.svelte";
  const { data }: { data: PageData } = $props();

  let pageState: 1 | 2 | 3 = $state(1);

  let modelState: EditState = $state({
    projectNameVietnamese: data.project.projectNameVietnamese,
    projectNameEnglish: data.project.projectNameEnglish,
    projectProgress: data.project.projectProgress,
    content: data.project.content,
    projectPurpose: data.project.projectPurpose,
    percentageOfProgress: data.project.percentageOfProgress,
    startDate: getDateOrNull(data.project.startDate),
    endDate: getDateOrNull(data.project.endDate),
    fundedEquipment: data.project.fundedEquipment,
    projectBudget: data.project.projectBudget,
    categoryId: data.project.categoryId,
    affiliatedUnitId: data.project.affiliatedUnitId,
    sponsorId: data.project.sponsorId,
    aidTypeId: data.project.aidTypeId,
    approvingAgencyId: data.project.approvingAgencyId,
    counterPartyId: data.project.counterpartyId,
    members: data.project.participations.map(
      (e) =>
        ({
          userId: e.userId,
          role: e.role,
          lastName: e.user?.lastName,
          firstName: e.user?.firstName,
          email: e.user?.email,
        }) as ParticipationReduce,
    ),
    participationDiff: [],
    fileUpload: [],
  });
</script>

<TitleWebPage title="Dự án - Chỉnh sửa" />
<BasicCenterLayout
  header={"Cập nhật dự án #" + data.project.projectId}
  breadcrumbWithCallback={[
    {
      name: "Dự án",
      callback: () => {},
    },
    {
      name: "Chỉnh sửa",
      callback: () => {},
    },
  ]}
>
  <Row --justify-content="flex-start">
    <IconButton
      onclick={() => {
        history.back();
      }}
      variant="orange"
      --margin-bottom="0.5em"
      --icon-size="1.3em"
    >
      {#snippet icon()}
        <ArrowLeftIcon --stroke="hsl(0, 0%, 97%)" />
      {/snippet}
      Trở về
    </IconButton>
  </Row>
  <Tabs>
    <TabItem isSelected={pageState == 1} onclick={() => (pageState = 1)}
      >Chung</TabItem
    >
    <TabItem isSelected={pageState == 2} onclick={() => (pageState = 2)}
      >Thành viên</TabItem
    >
    <TabItem isSelected={pageState == 3} onclick={() => (pageState = 3)}
      >File</TabItem
    >
  </Tabs>
  {#if pageState == 1}
    <GeneralInformation {data} bind:modelState />
  {:else if pageState == 2}
    <Members {data} bind:modelState />
  {:else}
    <AttachedFiles {data} />
  {/if}
</BasicCenterLayout>
