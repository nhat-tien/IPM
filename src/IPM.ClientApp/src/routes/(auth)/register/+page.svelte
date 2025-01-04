<script>
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import Select from "@components/Select/Select.svelte";
  import PasswordTextField from "@components/TextField/PasswordTextField.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";

  let chucVu = [
    { value: "nam", name: "Chao" },
    { value: "cdj", name: "Chao gi do" },
    { value: "nm", name: "Chao cdks" },
  ];
  let donVi = [
    { value: "nam", name: "Chao" },
    { value: "cdj", name: "Chao gi do" },
    { value: "nm", name: "Chao cdks" },
  ];
  let selectedValue = $state("");
  let selectedDonVi = $state("");
</script>

<h2>Đăng kí</h2>
<form>
  <Select
    id="donVi"
    bind:value={selectedDonVi}
    items={donVi}
    label="Đơn vị"
    placeHolder="Chọn đơn vị"
  />
  <Select
    id="chucVu"
    bind:value={selectedValue}
    items={chucVu}
    label="Chức vụ"
    placeHolder="Chọn chức vụ"
  />
  <PrimaryTextField
    name="email"
    id="email"
    label="Email"
    type="email"
    placeHolder=""
  />
  <div class="name-input">
      <PrimaryTextField
        id="lastName"
        name="lastName"
        label="Họ lót"
        type="text"
        placeHolder="VD: Nguyễn Văn"
        --width="60%"
      />
      <PrimaryTextField
        id="firstName"
        name="firstName"
        label="Tên"
        type="text"
        placeHolder="VD: An"
      --width="40%"
      />
  </div>

  <PasswordTextField
    id="password"
    name="password"
    label="Mật khẩu"
    placeHolder=""
  />
  <PasswordTextField
    id="retypePassword"
    name="retypePassword"
    label="Nhập lại mật khẩu"
    placeHolder=""
  />
  <PrimaryButton --margin-top="1em">Đăng kí</PrimaryButton>
</form>
<p>Đã có tài khoản <a href="/login">Đăng nhập</a></p>

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
      font-family: "Inter Bold";
      color: $text-second-clr;
    }
  }
  .name-input {
    display: flex;
    flex-direction: row;
  }
</style>
