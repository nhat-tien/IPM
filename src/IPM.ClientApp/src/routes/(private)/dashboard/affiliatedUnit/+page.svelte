<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import { closeModal, openModal } from "@stores/modal.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import FormRowButton from "@components/Form/FormRowButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import createAffiliatedUnit from "@useCases/affiliatedUnitUseCase/createAffiliatedUnit";
  import toast from "svelte-5-french-toast";

  import { ZodError, type ZodIssue } from "zod";
  import type { PageData } from "./$types";
  import type { EventSubmitElements } from "../../../../shared.types";

  let { data }: { data: PageData } = $props();
  import transformAffliatedUnitToTable from "@useCases/affiliatedUnitUseCase/transformAffliatedUnitToTable";

  let headers = ["Mã đơn vị trực thuộc", "Tên đơn vị trực thuộc"];
  let error: ZodIssue[] = $state([]);

  async function onSubmitAffiliatedUnit(e: EventSubmitElements) {
    e.preventDefault();
    const formData = new FormData(e.target as HTMLFormElement);
    const result = await createAffiliatedUnit({
      affiliatedUnitName: formData.get("affiliatedUnitName") as string,
    });
    if (result.isSuccess) {
      toast.success("Thêm đơn vị thành công");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }
</script>

<BasicCenterLayout
  header={"Đơn vị trực thuộc"}
  breadcrumb={["Đơn vị trực thuộc", "Danh sách"]}
>
  <PrimaryButton onclick={() => openModal(modal)} variant="orange"
    >Thêm</PrimaryButton
  >
  {#await data.affiliatedUnit}
    <div>Loading</div>
  {:then affiliatedUnit}
    <Table {headers} content={transformAffliatedUnitToTable(affiliatedUnit)} />
  {/await}
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
      <FormRowButton>
        <PrimaryButton variant="orange" type="submit">Thêm</PrimaryButton>
        <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
      </FormRowButton>
    </form>
  </div>
{/snippet}

<style lang="scss">
  form {
    display: flex;
    flex-direction: column;
  }
</style>
