import transformToOption, { type OptionType } from "@useCases/common/transformToOption";
import type {  FileType } from "@useCases/useCases.types";

export default function transformFileTypeToOption(fileType: FileType[]): OptionType {

  return transformToOption<FileType>(fileType, (model) =>
    [
      model.fileTypeId, 
      model.fileTypeName
    ]);
}



