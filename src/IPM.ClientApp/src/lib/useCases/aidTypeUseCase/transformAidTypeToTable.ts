import transformToTable from "@useCases/common/transformToTable";
import type { AidType } from "@useCases/useCases.types";


export default function transformAidTypeToTable(aidTypes: AidType[]): any[][] {

  return transformToTable<AidType>(aidTypes, (aidType) =>
    [
      aidType.aidTypeId,
      aidType.aidTypeName
    ]);
}
