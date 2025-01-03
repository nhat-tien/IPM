<script lang="ts">
  import login, { testrefresh } from "$lib/useCases/AuthUseCases/loginUseCase";
  import LoadingButton from "@components/Button/LoadingButton.svelte";
  import PasswordTextField from "@components/TextField/PasswordTextField.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";

  let isLoading = $state(false);

  async function onSubmit(e: EventSubmitElements) {
    e.preventDefault();
    isLoading = true;
    const formData = new FormData(e.target as HTMLFormElement);
    const result = await login({
      email: formData.get("email") as string,
      password: formData.get("password") as string
    });
    if(result.isSuccess) {
      isLoading = false;
      console.log(result);
    }
  }

  async function testapi() {
    await testrefresh();
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
  />
  <PasswordTextField id="password" label="Password" name="password" />
  <a class="forgot-password" href="/">Quên mật khẩu</a>
  <LoadingButton {isLoading} type="submit">Đăng nhập</LoadingButton>
</form>
  <LoadingButton {isLoading} onclick={testapi} >Test</LoadingButton>
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
      margin-bottom: 1.5em;
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
</style>
