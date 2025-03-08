import { fileEndPoint } from "@services/httpService";
import deleteApi from "@useCases/common/delete";


export default async function deleteFile(fileId: number) {
  return await deleteApi(fileEndPoint, fileId.toString());
}
