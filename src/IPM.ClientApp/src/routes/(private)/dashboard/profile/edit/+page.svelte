<script lang="ts">
  import { goto, invalidate } from "$app/navigation";
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import PrimaryTextFieldBindable from "@components/TextField/PrimaryTextFieldBindable.svelte";
  import Row from "@components/Row/Row.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import Select from "@components/Select/Select.svelte";
  import type { OptionType } from "@useCases/useCases.types";
  import { Gender } from "@utils/getGenderFromNumber";
  import SquareSkeleton from "@components/Skeleton/SquareSkeleton.svelte";
  import SelectCustom from "@components/Select/SelectCustom.svelte";
  import transformAffliatedUnitToOption from "@useCases/affiliatedUnitUseCase/transformAffliatedUnitToOption";
  import type { PageData } from "./$types";
  import transformPositionToOption from "@useCases/positionUseCase/transformPositionToOption";
  import updateProfile from "@useCases/userUseCase/updateProfile";
  import toast from "svelte-5-french-toast";
  import { invalidateCache } from "@stores/cache.svelte";
  import { ZodError, type ZodIssue } from "zod";

  const { data }: { data: PageData } = $props();

  let error: ZodIssue[] = $state([]);

  let formState = $state({
    firstName: data.user.firstName,
    lastName: data.user.lastName,
    phoneNumber: data.user.phoneNumber,
    sex: data.user.sex + "",
    address: data.user.address,
    positionId: data.user.positionId,
    affiliatedUnitId: data.user.affiliatedUnitId,
  });

  let sex: OptionType[] = [
    { value: "0", name: Gender[0].vietnamese },
    { value: "1", name: Gender[1].vietnamese },
    { value: "2", name: Gender[2].vietnamese },
  ];

  function handleCancel(): void {
    throw new Error("Function not implemented.");
  }

  async function handleSave() {
    const req = {
      firstName: formState.firstName,
      lastName: formState.lastName,
      phoneNumber: formState.phoneNumber,
      sex: parseInt(formState.sex),
      address: formState.address,
      positionId: formState.positionId,
      affiliatedUnitId: formState.affiliatedUnitId,
    };

    const result = await updateProfile(req, data.user);

    if (result.isSuccess) {
      invalidateCache("profile");
      invalidate("user:profile");
      toast.success("Cập nhật thành công");
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  function clearError() {
    error = [];
  }
</script>

<TitleWebPage title="Dự án - Xem chi tiết" />
<BasicCenterLayout
  header={"Profile"}
  breadcrumbWithCallback={[
    {
      name: "Profile",
      callback: () => {
        goto("/dashboard/profile");
      },
    },
    {
      name: "Chỉnh sửa",
      callback: () => {},
    },
  ]}
>
  <section class="container">
    <h2>Thông tin cá nhân</h2>
    <div class="name-input">
      <PrimaryTextFieldBindable
        id="lastName"
        label="Họ lót"
        placeHolder=""
        type="text"
        name="lastName"
        bind:value={formState.lastName}
        {error}
        errorId="lastName"
        onfocus={clearError}
        --margin-top="1.5em"
        --width="60%"
      />
      <PrimaryTextFieldBindable
        id="firstName"
        label="Tên"
        placeHolder=""
        type="text"
        name="firstName"
        {error}
        errorId="firstName"
      onfocus={clearError}
        bind:value={formState.firstName}
        --margin-top="1.5em"
        --width="38%"
      />
    </div>
    <PrimaryTextFieldBindable
      id="phoneNumber"
      label="Số điện thoại"
      placeHolder=""
      type="text"
      name="phoneNumber"
      {error}
      errorId="phoneNumber"
      onfocus={clearError}
      bind:value={formState.phoneNumber}
      --margin-top="1.5em"
    />
    <PrimaryTextFieldBindable
      id="address"
      label="Địa chỉ"
      placeHolder=""
      type="text"
      name="address"
      {error}
      errorId="address"
      onfocus={clearError}
      bind:value={formState.address}
      --margin-top="1.5em"
    />
    <Select
      bind:value={formState.sex}
      id="sex"
      name="sex"
      items={sex}
      label="Giới tính"
      placeHolder=""
      --margin-top="1.5em"
    />
    {#await data.affiliatedUnit}
      <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
    {:then affiliatedUnit}
      <SelectCustom
        label="Đơn vị trực thuộc"
        required
        value={data.user.affiliatedUnit?.affiliatedUnitName}
        items={transformAffliatedUnitToOption(affiliatedUnit)}
        placeHolder="Chọn đơn vị trực thuộc"
        selectFn={(e) => (formState.affiliatedUnitId = parseInt(e.value))}
        --margin-top="1.5em"
      />
    {/await}
    {#await data.position}
      <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
    {:then position}
      <SelectCustom
        label="Chức vụ"
        required
        value={data.user.position?.positionName}
        items={transformPositionToOption(position)}
        placeHolder="Chọn chức vụ"
        selectFn={(e) => (formState.positionId = parseInt(e.value))}
        --margin-top="1.5em"
      />
    {/await}
    <Row --justify-content="flex-end"  --padding-right="1em" --margin-top="1.5em">
      <SecondaryButton onclick={() => handleCancel()}
        >Hủy bỏ thay đổi</SecondaryButton
      >
      <PrimaryButton variant="orange" onclick={() => handleSave()}
        >Lưu</PrimaryButton
      >
    </Row>
  </section>
</BasicCenterLayout>

<style lang="scss">
  .container {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
  }

  .name-input {
    display: flex;
    flex-direction: row;
    gap: 5px;
  }
</style>
