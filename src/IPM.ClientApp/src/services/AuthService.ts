import accessTokenStore from "@states/accessToken.svelte";

type LoginRequest = {
  email: string,
  password: string
}

export default class AuthService {
  constructor() {
  }

  login({ email, password }: LoginRequest) {
    const token = accessTokenStore();
  }
}
