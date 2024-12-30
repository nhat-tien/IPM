export default function accessTokenStore() {
  let token: string = $state("");
  return {
  get () {
    return token;
  },
  set (value: string) {
    token = value;
  }
}
}
