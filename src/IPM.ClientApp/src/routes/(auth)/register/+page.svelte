<script>
  import Select from "@components/Select/Select.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";

  let chucVu = [
    { value: "nam", name: "Chao" },
    { value: "cdj", name: "Chao gi do" },
    { value: "nm", name: "Chao cdks" },
  ];
  let selectedValue = $state("");
</script>

<h2>Đăng kí</h2>
<h3>{selectedValue}</h3>
<form>
  <PrimaryTextField
    id="email"
    label="Email"
    type="email"
    placeHolder="Nhập email"
  />
  <Select bind:value={selectedValue} items={chucVu} />
</form>
<p>Đã có tài khoản <a href="/login">Đăng nhập</a></p>

<style lang="scss" scoped>
  form {
    width: 70%;
    display: flex;
    flex-direction: column;
  }
  p {
    a {
      font-family: "Inter Bold";
      color: $text-second-clr;
    }
  }
</style>
