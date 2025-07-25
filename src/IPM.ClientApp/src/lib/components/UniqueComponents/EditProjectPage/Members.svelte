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
  import Row from "@components/Row/Row.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import assignMember from "@useCases/projectUseCase/assignMember";
  import removeMember from "@useCases/projectUseCase/removeMember";
  import toast from "svelte-5-french-toast";
  import { invalidateCache } from "@stores/cache.svelte";
  import Card from "@components/Card/Card.svelte";
  import Badge from "@components/Badge/Badge.svelte";
  import projectRoleMapping from "@utils/projectRoleMapping";
  import { useUserInfo } from "@lib/stores/userInfo.svelte";

  let {
    modelState = $bindable(),
    data,
  }: { modelState: EditState; data: EditProjectDataPage } = $props();

  function addUserHandler(user: User) {
    const userPayload = {
      userId: user.userId,
      lastName: user.lastName,
      firstName: user.firstName,
      email: user.email,
      role: "MEMBER",
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
      modelState.participationDiff.push({ type: "add", payload: userPayload });
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

  async function handleSave() {
    let addMember = [];
    let deleteMember = [];

    for (let participation of modelState.participationDiff) {
      if (participation.type == "add") {
        addMember.push({
          userId: participation.payload.userId,
          projectId: parseInt(data.id),
          role: participation.payload.role,
        });
      }
      if (participation.type == "delete") {
        deleteMember.push({
          userId: participation.payload.userId,
          projectId: parseInt(data.id),
        });
      }
    }

    const result = await Promise.all([
      assignMember({ assignments: addMember }),
      removeMember({ assignments: deleteMember }),
    ]);

    if (result[0].isSuccess && result[1].isSuccess) {
      toast.success("Thay đổi thành viên thành công");
      invalidateCache(`project:${data.id}`);
    }
  }

  const userInfo = useUserInfo();
</script>

<Card
  --card-margin-top="1em"
  --card-margin-bottom="5em"
  --card-padding="1em"
  title="Thành viên"
>
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
        {#if $userInfo && $userInfo.email == member.email}
          <div>(Bạn)</div>
        {/if}
        <Badge isHasDot={false} variant="green"
          >{projectRoleMapping(member.role)}</Badge
        >
        <div>
          {#if member.role !== "OWNER"}
            <button
              class="delete-btn"
              onclick={() => removeUserHandler(member)}
            >
              <div class="icon">
                <TrashIcon --stroke=" hsl(0, 84%, 48%)" />
              </div>
            </button>
          {/if}
        </div>
      </div>
    {/each}
  </div>
  <Row --justify-content="flex-end" --padding-right="1em" --margin-top="1.5em">
    <SecondaryButton onclick={() => handleCancel()}
      >Hủy bỏ thay đổi</SecondaryButton
    >
    <PrimaryButton variant="orange" onclick={() => handleSave()}
      >Lưu</PrimaryButton
    >
  </Row>
</Card>

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
    border-bottom: 0.5px solid $gray-clr;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
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
  .owner-label {
    @include center;
  }
</style>
