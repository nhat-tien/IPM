<script lang="ts">
  import type {
    EditProjectDataPage,
    EditState,
    ParticipationReduce,
    User,
  } from "@useCases/useCases.types";
  import UserSuggestSelectTextField from "../UserSuggestSelectTextField.svelte";
  import SquareSkeleton from "@components/Skeleton/SquareSkeleton.svelte";
  import TrashIcon from "@components/Icons/TrashIcon.svelte";
  import { getUserInfo } from "@stores/userInfo.svelte";
    import RowToRight from "@components/Row/RowToRight.svelte";
    import SecondaryButton from "@components/Button/SecondaryButton.svelte";
    import PrimaryButton from "@components/Button/PrimaryButton.svelte";

  let {
    modelState = $bindable(),
    data,
  }: { modelState: EditState; data: EditProjectDataPage } = $props();

  const info = getUserInfo();

  function addUserHandler(user: User) {
    const userPayload = {
      userId: user.userId,
      lastName: user.lastName,
      firstName: user.firstName,
      email: user.email,
      owner: info?.email == user.email,
    };

    modelState.members.push(userPayload);

    if (
      modelState.participationDiff.find(
        (e) => e.type == "delete" && e.payload.email == userPayload.email,
      )
    ) {
      modelState.participationDiff = modelState.participationDiff.filter(
        (e) => !(e.payload.email == userPayload.email),
      );
    } else {
      modelState.participationDiff.push({ type: "add", payload: userPayload});
    }
  }

  function removeUserHandler(user: ParticipationReduce) {
    modelState.members = modelState.members.filter(
      (e) => !(e.email == user.email),
    );

    if (
      modelState.participationDiff.find(
        (e) => e.type == "add" && e.payload.email == user.email,
      )
    ) {
      modelState.participationDiff = modelState.participationDiff.filter(
        (e) => !(e.payload.email == user.email),
      );
    } else {
      modelState.participationDiff.push({ type: "delete", payload: user });
    }
  }


  function handleCancel() {
    //TODO:
  }

  function handleSave() {
    //TODO:
  }
</script>

<div class="container">
  <h2>Thành viên</h2>
  {#await data.users}
    <SquareSkeleton --width="100%" --height="2em" --radius="5px" />
  {:then users}
    <UserSuggestSelectTextField
      label="Thêm thành viên"
      placeHolder=""
      --margin-top="1.5em"
      selectionCallback={(e) => addUserHandler(e)}
      excludeUsers={modelState.members}
      {users}
    />
  {/await}
  <h3 class="member-list-title">Danh sách thành viên</h3>
  <div class="member-list">
    {#each modelState.members as member}
      <div class="member">
        <div class="member__info">
          <p class="member__name">
            {`${member.lastName} ${member.firstName}`}
          </p>
          <p class="member__email">{member.email}</p>
        </div>
        <button class="delete-btn" onclick={() => removeUserHandler(member)}>
          <div class="icon">
            <TrashIcon --stroke=" hsl(0, 84%, 48%)" />
          </div>
        </button>
      </div>
    {/each}
  </div>
  <RowToRight --padding-right="1em" --margin-top="1.5em">
    <SecondaryButton onclick={() => handleCancel()}
      >Hủy bỏ thay đổi</SecondaryButton
    >
    <PrimaryButton variant="orange" onclick={() => handleSave()}
      >Lưu</PrimaryButton
    >
  </RowToRight>
</div>

<style lang="scss">
  .container {
    background-color: $white-clr;
    border: 1px solid $gray-clr;
    border-radius: 15px;
    padding: 1em;
    margin-top: 1em;
  }
  h2 {
    margin-bottom: 1em;
  }

  .member-list-title {
    margin: 1em 0 0.3em 0;
  }
  .member {
    margin: 0.5em 0;
    padding: 0.5em;
    border-radius: 5px;
    border: 0.5px solid $gray-clr;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
  }
  .member__name {
    font-family: "Inter SemiBold";
  }
  .member__email {
    font-size: 0.9rem;
  }
  .icon {
    width: 1.4em;
    @include center;
  }
</style>
