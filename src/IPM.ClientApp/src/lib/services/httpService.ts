import ky, { HTTPError } from "ky";
import { getAccessToken, saveAccessToken } from "./jwtService";
import refreshToken from "@useCases/authUseCases/refreshTokenUseCase";
import logout from "@useCases/authUseCases/logoutUseCase";

export const api = ky.create({
  prefixUrl: 'http://localhost:5286/api/v1',
});

const apiWithBearerToken = api.extend({
  retry: {
    limit: 2,
    statusCodes: [401]
  },
  hooks: {
    beforeRequest: [
      request => {
        request.headers.set('Authorization', 'Bearer ' + getAccessToken());
      }
    ],
    beforeRetry: [
      async ({ error }) => {
        if (error instanceof HTTPError && error.response.status == 401) {
            const res = await refreshToken();
            if (res.isSuccess && res.accessToken) {
              saveAccessToken(res.accessToken)
            } else {
              logout();
            }
        }
      }
    ]
  }
});

export const authEndPoint = api.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/auth`,
}));

export const affiliatedEndPoint = apiWithBearerToken.extend((option) => ({ prefixUrl: `${option.prefixUrl}/affiliatedUnit` }));


