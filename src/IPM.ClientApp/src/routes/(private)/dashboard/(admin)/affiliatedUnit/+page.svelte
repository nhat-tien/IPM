<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import RowToLeft from "@components/Row/RowToLeft.svelte";
  import { closeModal, openModal } from "@stores/modal.svelte";
  import createAffiliatedUnit from "@useCases/affiliatedUnitUseCase/createAffiliatedUnit";
  import toast from "svelte-5-french-toast";
  import transformAffliatedUnitToTable from "@useCases/affiliatedUnitUseCase/transformAffliatedUnitToTable";
  import { invalidate } from "$app/navigation";
  import deleteAffiliatedUnit from "@useCases/affiliatedUnitUseCase/deleteAffiliatedUnit";
  import updateAffiliatedUnit from "@useCases/affiliatedUnitUseCase/updateAffiliatedUnit";
  import MessageBoxConfirm from "@components/MessageBox/MessageBoxConfirm.svelte";

  import { ZodError, type ZodIssue } from "zod";
  import type { PageData } from "./$types";
  import type { EventSubmitElements } from "@/shared.types";
  import type { AffiliatedUnit } from "@useCases/useCases.types";
  import SingleFieldCreateModal from "@components/Modal/CreateModal/SingleFieldCreateModal.svelte";
    import TableSkeleton from "@components/Skeleton/TableSkeleton.svelte";

  type AffiliatedUnitUpdateDto = Omit<
    AffiliatedUnit,
    "createdAt" | "updatedAt"
  >;
  let modelName = "Đơn vị trực thuộc";
  let headers = ["Mã đơn vị trực thuộc", "Tên đơn vị trực thuộc"];

  let { data }: { data: PageData } = $props();
  let error: ZodIssue[] = $state([]);
  let selectedModel: AffiliatedUnitUpdateDto | null = $state(null);

  function selectModel(model: any[]) {
    selectedModel = {
      affiliatedUnitId: model[0],
      affiliatedUnitName: model[1],
    };
  }

  function openUpdateModal(model: any[]) {
    selectModel(model);
    openModal(updateModal);
  }

  async function onUpdate(e: EventSubmitElements) {
    e.preventDefault();

    if (selectedModel == null) return;

    const formData = new FormData(e.target as HTMLFormElement);
    const result = await updateAffiliatedUnit(
      formData,
      selectedModel?.affiliatedUnitId,
    );

    if (result.isSuccess) {
      toast.success("Cập nhật đơn vị thành công");
      invalidate("affiliatedUnit:getAll");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  async function onDelete() {
    if (selectedModel == null) return;

    const result = await deleteAffiliatedUnit(selectedModel.affiliatedUnitId);

    if (result.isSuccess) {
      toast.success("Xóa đơn vị thành công");
      invalidate("affiliatedUnit:getAll");
      closeModal();
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  function openConfirmDelete(model: any[]) {
    selectModel(model);
    openModal(confirmDelete);
  }
</script>

<TitleWebPage title="Đơn vị trực thuộc" />
<BasicCenterLayout
  header={"Đơn vị trực thuộc"}
  breadcrumb={["Đơn vị trực thuộc", "Danh sách"]}
>
  <RowToRight>
    <PrimaryButton
      onclick={() => openModal(createModal)}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </RowToRight>
  <Table {headers} hasAction>
    {#await data.affiliatedUnit}
      <TableSkeleton {headers} />
    {:then affiliatedUnits}
      {#each transformAffliatedUnitToTable(affiliatedUnits) as affiliatedUnit}
        <TableRow
          row={affiliatedUnit}
          onDelete={() => openConfirmDelete(affiliatedUnit)}
          onEdit={() => openUpdateModal(affiliatedUnit)}
        />
      {/each}
    {/await}
  </Table>
</BasicCenterLayout>

{#snippet createModal()}
  <SingleFieldCreateModal
    title={`Thêm ${modelName.toLowerCase()}`}
    label={`Tên ${modelName.toLowerCase()}`}
    placeHolder={`Vui lòng nhập tên ${modelName.toLowerCase()}`}
    fieldName="affiliatedUnitName"
    invalidateStr="affiliatedUnit:getAll"
    successMessage="Thêm thành công"
    createFn={createAffiliatedUnit}
  />
{/snippet}

{#snippet updateModal()}
  <div class="modal">
    <h4>Chỉnh sửa đơn vị trực thuộc</h4>
    <form onsubmit={onUpdate}>
      <PrimaryTextField
        id="affiliatedUnitName"
        name="affiliatedUnitName"
        type="text"
        placeHolder=""
        label="Tên đơn vị trực thuộc"
        required
        --margin-top="1em"
        --margin-bottom="1em"
        {error}
        errorId="affiliatedUnitName"
        value={selectedModel?.affiliatedUnitName}
      ></PrimaryTextField>
      <RowToLeft>
        <PrimaryButton variant="orange" type="submit">Lưu</PrimaryButton>
        <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
      </RowToLeft>
    </form>
  </div>
{/snippet}

{#snippet confirmDelete()}
  <MessageBoxConfirm
    title="Bạn có chắc muốn xóa?"
    onYes={() => onDelete()}
    onNo={() => closeModal()}
  />
{/snippet}

<style lang="scss">
  form {
    display: flex;
    flex-direction: column;
  }
</style>
