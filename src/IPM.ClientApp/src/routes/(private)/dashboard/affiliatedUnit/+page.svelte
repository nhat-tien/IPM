<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import type { PageData } from "../project/$types";
  import { openModal } from "@stores/modal.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import FormRowButton from "@components/Form/FormRowButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";

  let headers = ["Mã đơn vị trực thuộc", "Tên đơn vị trực thuộc"];
  let { data }: { data: PageData & { affiliatedUnit: string[][] } } = $props();

  function onSubmitAffiliatedUnit(e: EventSubmitElements) {
  }
</script>

<BasicCenterLayout
  header={"Đơn vị trực thuộc"}
  breadcrumb={["Đơn vị trực thuộc", "Danh sách"]}
>
  <PrimaryButton onclick={() => openModal(modal)} variant="orange"
    >Thêm</PrimaryButton
  >
  <Table {headers} content={data.affiliatedUnit} />
</BasicCenterLayout>

{#snippet modal()}
  <div class="modal">
    <h4>Thêm đơn vị trực thuộc</h4>
    <form>
      <PrimaryTextField
        id="affiliatedUnitName"
        name="affiliatedUnitName"
        type="text"
        placeHolder=""
        label="Tên đơn vị trực thuộc"
        required
        --margin-top="1em"
        --margin-bottom="1em"
      ></PrimaryTextField>
      <FormRowButton>
        <PrimaryButton variant="orange"
          >Thêm</PrimaryButton
        >
        <SecondaryButton
        >
          Hủy
        </SecondaryButton>
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
