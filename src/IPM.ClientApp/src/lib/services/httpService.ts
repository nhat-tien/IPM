import ky from "ky";

export const api = ky.create({prefixUrl: 'http://localhost:5286/api/v1'});

export const authEndPoint = api.extend((option) => ({ prefixUrl: `${option.prefixUrl}/auth` }));


