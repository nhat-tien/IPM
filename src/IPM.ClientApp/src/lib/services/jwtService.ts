
export function saveAccessToken(token: string) {
  localStorage.setItem("access-token", token);
}

export function getAccessToken(): string | null {
  return localStorage.getItem("access-token");
}
