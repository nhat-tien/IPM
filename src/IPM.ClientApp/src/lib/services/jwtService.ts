
export function saveAccessToken(token: string) {
  sessionStorage.setItem("access-token", token);
}

export function getAccessToken(): string | null {
  return sessionStorage.getItem("access-token");
}
