<script lang="ts">
  import { goto } from "$app/navigation";
  import login from "$lib/useCases/AuthUseCases/loginUseCase";
  import LoadingButton from "@components/Button/LoadingButton.svelte";
  import PasswordTextField from "@components/TextField/PasswordTextField.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import toast from "svelte-5-french-toast";
  import { ZodError } from "zod";

  let isLoading = $state(false);
  let error: string | null = $state(null);

  async function onSubmit(e: EventSubmitElements) {
    e.preventDefault();
    isLoading = true;
    const formData = new FormData(e.target as HTMLFormElement);
    const result = await login({
      email: formData.get("email") as string,
      password: formData.get("password") as string,
    });
    isLoading = false;
    if (result.isSuccess) {
      toast.success("Đăng nhập thành công");
      goto("/dashboard");
    } else {
      if (result.error === "Unauthorized") {
        error = "Email hoặc mật khẩu không chính xác";
      } else {
        let zodError = result.error as ZodError;
        error = zodError.issues[0].message;
      }
    }
  }

  function clearError() {
    error = null;
  }
</script>

<h1>Welcome Back</h1>
<form onsubmit={onSubmit}>
  <PrimaryTextField
    id="email"
    placeHolder="anh@gmail.com"
    label="Email"
    type="email"
    name="email"
    --margin-bottom="1.5em"
    onfocus={clearError}
    required
  />
  <PasswordTextField
    id="password"
    label="Password"
    name="password"
    onfocus={clearError}
    required
  />
  <a class="forgot-password" href="/">Quên mật khẩu</a>
  <div class="error">
    {#if error != null}
      {error}
    {/if}
  </div>
  <LoadingButton {isLoading} type="submit">Đăng nhập</LoadingButton>
</form>
<p class="register">Chưa có tài khoản? <a href="/register">Đăng kí</a></p>

<style lang="scss">
  h1 {
    margin-bottom: 1.5em;
    font-size: 2rem;
  }
  form {
    width: 70%;
    display: flex;
    flex-direction: column;
    .forgot-password {
      width: max-content;
      margin-top: 0.5em;
      margin-bottom: 0.8em;
      font-size: 0.9rem;
      align-self: flex-end;
    }
  }
  .register {
    position: absolute;
    bottom: 2em;
    font-size: 0.9rem;
    a {
      font-family: "Inter Bold";
      color: $text-second-clr;
    }
  }
  .error {
    height: 1.4rem;
    font-size: 1rem;
    color: $red-clr;
  }
</style>
