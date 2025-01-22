import ky, { HTTPError } from "ky";
import { getAccessToken, saveAccessToken } from "./jwtService";
import refreshToken from "@useCases/authUseCases/refreshTokenUseCase";
import logout from "@useCases/authUseCases/logoutUseCase";

const api = ky.create({
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
        request.headers.set('Accept', 'application/json');
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

export const affiliatedUnitEndPoint = apiWithBearerToken.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/affiliatedUnits`,
}));

export const aidTypeEndPoint = apiWithBearerToken.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/aidTypes`,
}));

export const approvingAgencyEndPoint = apiWithBearerToken.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/approvingAgencies`,
}));

export const currencyUnitEndPoint = apiWithBearerToken.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/currencyUnits`,
}));

export const categoryEndPoint = apiWithBearerToken.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/categories`,
}));

export const counterpartyEndPoint = apiWithBearerToken.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/counterparties`,
}));

export const positionEndPoint = apiWithBearerToken.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/positions`,
}));

export const sponsorEndPoint = apiWithBearerToken.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/sponsors`,
}));





