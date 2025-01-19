<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import { closeModal, openModal } from "@stores/modal.svelte";
  import createAffiliatedUnit from "@useCases/affiliatedUnitUseCase/createAffiliatedUnit";
  import toast from "svelte-5-french-toast";
  import transformAffliatedUnitToTable from "@useCases/affiliatedUnitUseCase/transformAffliatedUnitToTable";

  import { ZodError, type ZodIssue } from "zod";
  import type { PageData } from "./$types";
  import type { EventSubmitElements } from "../../../../shared.types";
  import { invalidate } from "$app/navigation";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import RowToLeft from "@components/Row/RowToLeft.svelte";

  let { data }: { data: PageData } = $props();

  let headers = ["Mã đơn vị trực thuộc", "Tên đơn vị trực thuộc"];
  let error: ZodIssue[] = $state([]);

  async function onSubmitAffiliatedUnit(e: EventSubmitElements) {
    e.preventDefault();

    const formData = new FormData(e.target as HTMLFormElement);
    const result = await createAffiliatedUnit(formData);

    if (result.isSuccess) {
      toast.success("Thêm đơn vị thành công");
      invalidate("affiliatedUnit:getAll");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }
</script>

<TitleWebPage title="Đơn vị trực thuộc" />
<BasicCenterLayout
  header={"Đơn vị trực thuộc"}
  breadcrumb={["Đơn vị trực thuộc", "Danh sách"]}
>
  <RowToRight>
    <PrimaryButton
      onclick={() => openModal(modal)}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </RowToRight>
  <Table {headers}>
    {#await data.affiliatedUnit}
      <div>Loading</div>
    {:then affiliatedUnits}
      {#each transformAffliatedUnitToTable(affiliatedUnits) as affiliatedUnit}
        <TableRow row={affiliatedUnit} />
      {/each}
    {/await}
  </Table>
</BasicCenterLayout>

{#snippet modal()}
  <div class="modal">
    <h4>Thêm đơn vị trực thuộc</h4>
    <form onsubmit={onSubmitAffiliatedUnit}>
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
      ></PrimaryTextField>
      <RowToLeft>
        <PrimaryButton variant="orange" type="submit">Thêm</PrimaryButton>
        <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
      </RowToLeft>
    </form>
  </div>
{/snippet}

<style lang="scss">
  form {
    display: flex;
    flex-direction: column;
  }
</style>
