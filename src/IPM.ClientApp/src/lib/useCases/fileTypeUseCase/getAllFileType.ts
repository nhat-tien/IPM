import { fileTypeEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type {  FileType } from "@useCases/useCases.types";

export default async function getAllFileType() {
  return await getAll<FileType>(fileTypeEndPoint);
}

