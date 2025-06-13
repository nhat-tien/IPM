<script lang="ts">
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import Table from "@components/Table/Table.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import type { PageData } from "./$types";
  import type { Project } from "@useCases/useCases.types";
  import { goto } from "$app/navigation";
  import Row from "@components/Row/Row.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
    import Container from "@components/Container/Container.svelte";

  const { data }: { data: PageData } = $props();
  let header = "Dự án của tôi";
  let modelName = "Dự án";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Tên ${modelName.toLowerCase()}`,
  ];

  function transformParticipation(project: Project | null) {
    if (!project) {
      return ["", ""];
    }
    return [project.projectId + "", project.projectNameVietnamese];
  }
</script>

<TitleWebPage title={header} />
<BasicCenterLayout {header} breadcrumb={[header, "Danh sách"]}>
  <Row --justify-content="flex-end" >
    <PrimaryButton
      onclick={() => {
        goto("/dashboard/project/create");
      }}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </Row >
  <Container>
    <Row --padding="1em 1em 1em 1.5em"></Row>
  <Table {headers} hasAction>
    {#each data.user.participations as { project }}
      <TableRow
        row={transformParticipation(project)}
        onViewLabel="Chi tiết"
        onView={() => goto(`project/${project?.projectId}/view`)}
        onEdit={() => goto(`project/${project?.projectId}/edit`)}
      />
    {/each}
  </Table>
    <Row --padding="1em 1em 1em 1.5em"></Row>
  </Container>
</BasicCenterLayout>
