<script lang="ts">
  import Badge from "@components/Badge/Badge.svelte";
  import Card from "@components/Card/Card.svelte";
  import Row from "@components/Row/Row.svelte";
  import Table from "@components/Table/Table.svelte";
  import type { Participation } from "@useCases/useCases.types";
  import projectRoleMapping from "@utils/projectRoleMapping";

  type Props = {
    participations: Participation[];
  };

  const { participations }: Props = $props();

  const transformParticipateToTable = (e: Participation) => {
    return [
      e.user?.lastName ?? "",
      e.user?.firstName ?? "",
      e.user?.email ?? "",
      projectRoleMapping(e.role),
    ];
  };
</script>

<Card
  --card-margin-top="1em"
  title={"Thành viên"}
  description="Danh sách thành viên"
>
  <Row></Row>
  <Table headers={["Họ lót", "Tên", "Email", "Vai trò"]}>
    {#each participations as member}
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

<style lang="scss">
  td {
    padding: 1em;
    width: max-content;
    max-width: 1000px;
    border-bottom: 1px solid $gray-clr;
  }
</style>
