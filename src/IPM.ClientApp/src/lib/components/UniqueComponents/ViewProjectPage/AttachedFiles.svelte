<script lang="ts">
    import UserBadge from "@components/Badge/UserBadge.svelte";
  import Card from "@components/Card/Card.svelte";
  import FloatMenu from "@components/FloatMenu/FloatMenu.svelte";
  import FloatMenuItem from "@components/FloatMenu/FloatMenuItem.svelte";
  import ArrowPathIcon from "@components/Icons/ArrowPathIcon.svelte";
  import ArrowTopRightOnSquare from "@components/Icons/ArrowTopRightOnSquare.svelte";
  import DownloadIcon from "@components/Icons/DownloadIcon.svelte";
  import PencilIcon from "@components/Icons/PencilIcon.svelte";
  import Row from "@components/Row/Row.svelte";
    import SideDrawer from "@components/SideDrawer/SideDrawer.svelte";
  import RowSkeleton from "@components/Skeleton/RowSkeleton.svelte";
  import Table from "@components/Table/Table.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import type { FileApp } from "@useCases/useCases.types";
  import { formatDate, getDateOrNull } from "@utils/datetime";
  import { getFileSizeFormat } from "@utils/fileSize";

  type Props = {
    files: Promise<FileApp[]>;
  };

  const { files }: Props = $props();

  let isOpenDetailFile = $state(false);
  let selectedFile: FileApp | undefined = $state();
</script>

<Card --card-margin-top="1em" title={"File"}>
  <Row></Row>
  <Table hasAction headers={["Tên File", "Size", "Phân loại", "Ngày tải lên"]}>
    {#await files}
      <RowSkeleton col={1} />
    {:then files}
      {#each files as file}
        <TableRow
          row={[
            file.fileName + "." + file.extension,
            getFileSizeFormat(file.size),
            file.fileType.fileTypeName,
            formatDate("H:M d/m/Y", getDateOrNull(file.createdAt)),
          ]}
        >
          {#snippet menu()}
            <FloatMenu>
              <FloatMenuItem>
                <button class="float-menu" onclick={() => {}}>
                  <div class="icon">
                    <DownloadIcon />
                  </div>
                  Tải xuống
                </button>
              </FloatMenuItem>
              <FloatMenuItem>
                <button class="float-menu" onclick={() => {
                  isOpenDetailFile = true;
                  selectedFile = file;
                }}>
                  <div class="icon">
                    <ArrowTopRightOnSquare />
                  </div>
                  Chi tiết
                </button>
              </FloatMenuItem>
              <FloatMenuItem>
                <button class="float-menu" onclick={() => {}}>
                  <div class="icon">
                    <PencilIcon />
                  </div>
                  Chỉnh sửa
                </button>
              </FloatMenuItem>
            </FloatMenu>
          {/snippet}
        </TableRow>
      {/each}
    {/await}
  </Table>
  <Row></Row>
</Card>

<SideDrawer bind:isOpen={isOpenDetailFile}>
  <h3>{selectedFile?.fileName}</h3>
  <table class="file-detail">
    <tbody>
      <tr>
        <td>Loại file</td>
        <td>{selectedFile?.fileType.fileTypeName}</td>
      </tr>
      <tr>
        <td>Người tải lên</td>
        <td>
          <UserBadge user={selectedFile?.user} />
        </td>
      </tr>
      <tr>
        <td>Thời gian</td>
        <td
          >{formatDate(
            "H:M:s d/m/Y",
            getDateOrNull(selectedFile?.createdAt ?? ""),
          )}</td
        >
      </tr>
    </tbody>
  </table>
</SideDrawer>

<style lang="scss">

  .float-menu {
    @include float-menu-item;
  }

  .file-detail {
    width: 100%;
    margin-top: 10px;
    td {
      padding: 10px 0;
    }
  }
</style>
