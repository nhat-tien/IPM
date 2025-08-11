<script lang="ts">
  import { goto } from "$app/navigation";
  import register from "$lib/useCases/authUseCases/registerUseCase";
  import LoadingButton from "@components/Button/LoadingButton.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import Select from "@components/Select/Select.svelte";
  import PasswordTextField from "@components/TextField/PasswordTextField.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import toast from "svelte-5-french-toast";
  import { ZodError } from "zod";
  import type { EventSubmitElements } from "../../../shared.types";

  let roles = [
    { value: "2", name: "Manager" },
    { value: "3", name: "User" },
  ];

  let isLoading = $state(false);
  let error: string | null = $state(null);

  async function onSubmit(e: EventSubmitElements) {
    e.preventDefault();
    isLoading = true;
    const formData = new FormData(e.target as HTMLFormElement);
    const result = await register({
      email: formData.get("email") as string,
      lastName: formData.get("lastName") as string,
      firstName: formData.get("firstName") as string,
      password: formData.get("password") as string,
      confirmPassword: formData.get("confirmPassword") as string,
      roleId: formData.get("role") as "2" | "3",
    });
    isLoading = false;
    if (result.isSuccess) {
      toast.success("Đăng kí thành công");
      goto("/login?no_check_user=true");
    } else {
      let zodError = result.error as ZodError;
      error = zodError.issues[0].message;
    }
  }

  function clearError() {
    error = null;
  }
</script>

<TitleWebPage title="Đăng kí" />
<h2>Đăng kí</h2>
<form onsubmit={onSubmit}>
  <Select
    id="role"
    items={roles}
    label="Vai trò"
    placeHolder="Chọn vai trò"
    name="role"
  />
  <PrimaryTextField
    name="email"
    id="email"
    label="Email"
    type="email"
    placeHolder=""
    onfocus={clearError}
  />
  <div class="name-input">
    <PrimaryTextField
      id="lastName"
      name="lastName"
      label="Họ lót"
      type="text"
      placeHolder="VD: Nguyễn Văn"
      --width="60%"
      onfocus={clearError}
    />
    <PrimaryTextField
      id="firstName"
      name="firstName"
      label="Tên"
      type="text"
      placeHolder="VD: An"
      --width="40%"
      onfocus={clearError}
    />
  </div>

  <PasswordTextField
    id="password"
    name="password"
    label="Mật khẩu"
    placeHolder=""
    onfocus={clearError}
  />
  <PasswordTextField
    id="retypePassword"
    name="confirmPassword"
    label="Nhập lại mật khẩu"
    placeHolder=""
    onfocus={clearError}
  />
  <div class="error">
    {#if error != null}
      {error}
    {/if}
  </div>
  <LoadingButton --margin-top="1em" {isLoading}>Đăng kí</LoadingButton>
</form>
<p>Đã có tài khoản <a href="/login?no_check_user=true">Đăng nhập</a></p>

<style lang="scss">
  form {
    width: 70%;
    display: flex;
    flex-direction: column;
    gap: 0.2em;
  }
  p {
    position: absolute;
    bottom: 2em;
    font-size: 0.9rem;
    a {
      font-weight: 600;
      color: $text-second-clr;
    }
  }
  .name-input {
    display: flex;
    flex-direction: row;
    gap: 2px;
  }
  .error {
    height: 1.2rem;
    font-size: 0.9rem;
    color: $red-clr;
  }
</style>
