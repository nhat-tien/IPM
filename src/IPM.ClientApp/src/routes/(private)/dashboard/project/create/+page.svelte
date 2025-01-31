<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import RowToRight from "@components/Row/RowToRight.svelte";
  import Select from "@components/Select/Select.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import StepProgressBar from "@components/UniqueComponents/StepProgressBar.svelte";
  let step: 1 | 2 | 3 = $state(1);
</script>

<TitleWebPage title="Tạo dự án mới" />
<BasicCenterLayout header="Tạo dự án mới" breadcrumb={["Dự án", "Tạo mới"]}>
  <StepProgressBar {step} />
  <div class="container">
    {#if step == 1}
      <h3>Thông tin dự án</h3>
      <PrimaryTextField
        id="projectNameVietnamese"
        label="Tên dự án Tiếng Việt"
        placeHolder=""
        type="text"
        name="projectNameVietnamese"
        --margin-top="1.5em"
        required
      />
      <PrimaryTextField
        id="projectNameEnglish"
        label="Tên dự án Tiếng Anh"
        placeHolder=""
        type="text"
        name="projectNameVietnamese"
        --margin-top="1em"
        required
      />
      <Select
        id="categoryId"
        items={[
          { value: "1", name: "Admin" },
          { value: "2", name: "Manager" },
          { value: "3", name: "User" },
        ]}
        label="Danh mục"
        placeHolder=""
        --margin-top="1em"
        name="categoryId"
      />
      <RowToRight>
        <PrimaryButton variant="orange" onclick={() => step++}
          >Tiếp theo</PrimaryButton
        >
      </RowToRight>
    {:else if step == 2}
      <h3>Thành viên</h3>
      <RowToRight>
        <SecondaryButton onclick={() => step--}>Trở lại</SecondaryButton>
        <PrimaryButton variant="orange" onclick={() => step++}
          >Tiếp theo</PrimaryButton
        >
      </RowToRight>
    {:else}
      <h3>File đính kèm</h3>
      <RowToRight>
        <SecondaryButton onclick={() => step--}>Trở lại</SecondaryButton>
        <PrimaryButton variant="orange" onclick={() => {}}
          >Hoàn tất</PrimaryButton
        >
      </RowToRight>
    {/if}
  </div>
</BasicCenterLayout>

<style lang="scss">
  .container {
    display: flex;
    flex-direction: column;
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
  }
</style>
