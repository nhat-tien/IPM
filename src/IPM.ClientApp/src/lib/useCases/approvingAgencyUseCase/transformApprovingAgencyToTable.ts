import transformToTable from "@useCases/common/transformToTable";
import type {  ApprovingAgency } from "@useCases/useCases.types";


export default function transformApprovingAgencyToTable(approvingAgency: ApprovingAgency[]): any[][] {

  return transformToTable<ApprovingAgency>(approvingAgency, (model) =>
    [
      model.approvingAgencyId, 
      model.approvingAgencyName
    ]);
}
