<script lang="ts">
  import Table from "@components/Table/Table.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import TableRow from "@components/Table/TableRow.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import { closeModal, openModal } from "@stores/modal.svelte";
  import toast from "svelte-5-french-toast";
  import { ZodError, type ZodIssue } from "zod";
  import type { PageData } from "./$types";
  import type { EventSubmitElements } from "@/shared.types";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import { invalidate } from "$app/navigation";
  import RowToLeft from "@components/Row/RowToLeft.svelte";
  import transformSponsorToTable from "@useCases/sponsorUseCase/transformSponsorToTable";
  import createSponsor from "@useCases/sponsorUseCase/createSponsor";
    import type { Sponsor } from "@useCases/useCases.types";
    import updateSponsor from "@useCases/sponsorUseCase/updateSponsor";
    import deleteSponsor from "@useCases/sponsorUseCase/deleteSponsor";
    import MessageBoxConfirm from "@components/MessageBox/MessageBoxConfirm.svelte";

  type SponsorUpdateDto = Omit<Sponsor, "createdAt" | "updatedAt">;
  let { data }: { data: PageData } = $props();
  let selectedModel: SponsorUpdateDto | null = $state(null);

  let modelName = "Nhà tài trợ";
  let headers = [
    `Mã ${modelName.toLowerCase()}`,
    `Tên ${modelName.toLowerCase()}`,
  ];
  let error: ZodIssue[] = $state([]);

  function resetError() {
    error = [];
  } 

  function selectModel(model: any[]) {
    selectedModel = {
      sponsorId: model[0],
      sponsorName: model[1],
    };
  }

  function openUpdateModal(model: any[]) {
    selectModel(model);
    openModal(updateModal);
  }

  function openConfirmDelete(model: any[]) {
    selectModel(model);
    openModal(confirmDelete);
  }



  async function onCreate(e: EventSubmitElements) {
    e.preventDefault();

    const formData = new FormData(e.target as HTMLFormElement);
    const result = await createSponsor(formData);

    if (result.isSuccess) {
      toast.success("Thêm thành công");
      invalidate("sponsor:getAll");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  async function onUpdate(e: EventSubmitElements) {
    e.preventDefault();

    if (selectedModel == null) return;

    const formData = new FormData(e.target as HTMLFormElement);
    const result = await updateSponsor(formData, selectedModel?.sponsorId);

    if (result.isSuccess) {
      toast.success("Cập nhật thành công");
      invalidate("sponsor:getAll");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  async function onDelete() {
    if (selectedModel == null) return;

    const result = await deleteSponsor(selectedModel.sponsorId);

    if (result.isSuccess) {
      toast.success("Xóa thành công");
      invalidate("sponsor:getAll");
      closeModal();
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }
</script>

<TitleWebPage title={modelName} />
<BasicCenterLayout header={modelName} breadcrumb={[modelName, "Danh sách"]}>
  <RowToRight>
    <PrimaryButton
      onclick={() => {
        resetError();
        openModal(createModal);
      }}
      variant="orange"
      --margin-bottom="0.5em">Thêm</PrimaryButton
    >
  </RowToRight>
  <Table hasAction {headers}>
    {#await data.sponsor}
      <div>Loading</div>
    {:then sponsors}
      {#each transformSponsorToTable(sponsors) as sponsor}
        <TableRow
          row={sponsor}
          onDelete={() => openConfirmDelete(sponsor)}
          onEdit={() => openUpdateModal(sponsor)}
        />
      {/each}
    {/await}
  </Table>
</BasicCenterLayout>

{#snippet createModal()}
  <div class="modal">
    <h4>Thêm {modelName.toLowerCase()}</h4>
    <form onsubmit={onCreate}>
      <PrimaryTextField
        id="sponsorName"
        name="sponsorName"
        type="text"
        placeHolder=""
        label={`Tên ${modelName.toLowerCase()}`}
        --margin-top="1em"
        --margin-bottom="1em"
        {error}
        errorId="sponsorName"
        onfocus={resetError}
      ></PrimaryTextField>
      <RowToLeft>
        <PrimaryButton variant="orange" type="submit">Thêm</PrimaryButton>
        <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
      </RowToLeft>
    </form>
  </div>
{/snippet}

{#snippet updateModal()}
  <div class="modal">
    <h4>Chỉnh sửa {modelName.toLowerCase()}</h4>
    <form onsubmit={onUpdate}>
      <PrimaryTextField
        id="sponsorName"
        name="sponsorName"
        type="text"
        placeHolder=""
        label={`Tên ${modelName.toLowerCase()}`}
        --margin-top="1em"
        --margin-bottom="1em"
        required
        value={selectedModel?.sponsorName}
        {error}
        errorId="sponsorName"
        onfocus={resetError}
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
