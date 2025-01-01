<script lang="ts">
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import PasswordTextField from "@components/TextField/PasswordTextField.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
</script>

<h1>Welcome Back</h1>
<form>
  <div class="text-field">
    <PrimaryTextField
      id="email"
      placeHolder="anh@gmail.com"
      label="Email"
      type="email"
    />
  </div>
  <div class="text-field">
    <PasswordTextField id="password" placeHolder="••••••••" label="Password" />
  </div>
  <a class="forgot-password" href="/">Quên mật khẩu</a>
  <PrimaryButton>Đăng nhập</PrimaryButton>
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
    .text-field:first-of-type {
      margin-bottom: 1.5em;
    }
    .forgot-password {
      text-align: right;
      margin-top: 0.5em;
      margin-bottom: 1.5em;
      font-size: 0.9rem;
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
