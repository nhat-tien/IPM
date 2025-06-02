import ky, { HTTPError } from "ky";
import { getAccessToken, saveAccessToken } from "./accessTokenService";
import refreshToken from "@useCases/authUseCases/refreshTokenUseCase";
import logout from "@useCases/authUseCases/logoutUseCase";

const api = ky.create({
  prefixUrl: 'http://localhost:5286/api/v1',
});

const apiWithBearerToken = api.extend({
  retry: {
    limit: 3,
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
    ],
  }
});

const apiEndPointFactory = (endpoint: string) => apiWithBearerToken.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/${endpoint}`,
}));

export const authEndPoint = api.extend((option) => ({
  prefixUrl: `${option.prefixUrl}/auth`,
}));

export const affiliatedUnitEndPoint = apiEndPointFactory("affiliatedUnits");

export const aidTypeEndPoint = apiEndPointFactory("aidTypes");

export const approvingAgencyEndPoint = apiEndPointFactory("approvingAgencies");

export const currencyUnitEndPoint = apiEndPointFactory("currencyUnits");

export const categoryEndPoint = apiEndPointFactory("categories");

export const counterpartyEndPoint = apiEndPointFactory("counterparties");

export const positionEndPoint = apiEndPointFactory("positions");

export const sponsorEndPoint = apiEndPointFactory("sponsors");

export const projectEndPoint = apiEndPointFactory("projects");

export const assignEndPoint = apiEndPointFactory("projects/assignment");

export const userEndPoint = apiEndPointFactory("users");

export const fileTypeEndPoint = apiEndPointFactory("fileTypes");

export const fileEndPoint = apiEndPointFactory("file");

export const profileEndPoint = apiEndPointFactory("users/profile");


