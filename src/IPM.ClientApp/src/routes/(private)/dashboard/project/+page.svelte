<script lang="ts">
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import Table from "@components/Table/Table.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import type { PageData } from "./$types";
  import type { Project } from "@useCases/useCases.types";
  import { goto } from "$app/navigation";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";

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
  <RowToRight>
    <PrimaryButton
      onclick={() => {
        goto("/dashboard/project/create");
      }}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </RowToRight>
  <Table {headers} hasAction>
    {#each data.user.participations as { project }}
      <TableRow
        row={transformParticipation(project)}
        onView={() => goto(`project/${project?.projectId}/view`)}
        onEdit={() => goto(`project/${project?.projectId}/edit`)}
      />
    {/each}
  </Table>
</BasicCenterLayout>
