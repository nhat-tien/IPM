import transformToOption from "@useCases/common/transformToOption";
import type { AidType, OptionType } from "@useCases/useCases.types";


export default function transformAidTypeToOption(aidTypes: AidType[]): OptionType[] {

  return transformToOption<AidType>(aidTypes, (aidType) =>
    [
      aidType.aidTypeId,
      aidType.aidTypeName
    ]);
}

