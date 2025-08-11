<script lang="ts">
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import type { PageData } from "./$types";
  import { goto } from "$app/navigation";
  import Row from "@components/Row/Row.svelte";
  import IconButton from "@components/Button/IconButton.svelte";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
  import GeneralInformation from "@components/UniqueComponents/ViewProjectPage/GeneralInformation.svelte";
  import Members from "@components/UniqueComponents/ViewProjectPage/Members.svelte";
  import AttachedFiles from "@components/UniqueComponents/ViewProjectPage/AttachedFiles.svelte";
  import Tabs from "@components/Tabs/Tabs.svelte";
  import TabItem from "@components/Tabs/TabItem.svelte";

  const { data }: { data: PageData } = $props();

  let pageState: 1 | 2 | 3 = $state(1);

</script>

<TitleWebPage title="Dự án • Xem chi tiết" />
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
    <GeneralInformation id={data.id} project={data.project} />
  {:else if pageState == 2}
    <Members participations={data.project.participations} />
  {:else}
    <AttachedFiles files={data.files} />
  {/if}
</BasicCenterLayout>

