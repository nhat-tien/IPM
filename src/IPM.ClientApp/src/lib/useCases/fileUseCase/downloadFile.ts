import { fileEndPoint } from "@services/httpService";
import get from "@useCases/common/get";

export default async function getUrlFile(fileId: number) {
  return await get<{ url: string, name: string }>(fileEndPoint, fileId.toString(), "/url");
}
