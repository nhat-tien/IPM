import transformToOption, { type OptionType } from "@useCases/common/transformToOption";
import type { AidType } from "@useCases/useCases.types";


export default function transformAidTypeToOption(aidTypes: AidType[]): OptionType {

  return transformToOption<AidType>(aidTypes, (aidType) =>
    [
      aidType.aidTypeId,
      aidType.aidTypeName
    ]);
}

