import transformToTable from "@useCases/common/transformToTable";
import type {  FileType } from "@useCases/useCases.types";

export default function transformFileTypeToTable(fileType: FileType[]): any[][] {

  return transformToTable<FileType>(fileType, (model) =>
    [
      model.fileTypeId, 
      model.fileTypeName
    ]);
}


