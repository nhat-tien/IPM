<script lang="ts">
</script>
<main>
  <section class="img-container">
    <img alt="illustration" src="/images/business-businessman-giving-a-lecture-ted-talk.svg"/>
  </section>
  <section class="form-area">
    <h2>Welcome</h2>
    <form>
      <label for="email">Email</label>
      <input id="email" type="text"/>
      <label for="password">Password</label>
      <input id="password" type="password"/>
      <a href="/">Quên mật khẩu</a>
      <input type="submit" />
    </form>
  </section>
</main>
<style lang="scss" scoped>
main {
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: row;
}
.img-container {
  width: 60%;
  background-color: $primary-clr;
  display: flex;
  justify-content: center;
  align-items: center;
}
.form-area {
  flex: 1;
  display: flex;
  flex-direction: column;
}
</style>
