import transformToOption, { type OptionType } from "@useCases/common/transformToOption";
import type {  ApprovingAgency } from "@useCases/useCases.types";


export default function transformApprovingAgencyToOption(approvingAgency: ApprovingAgency[]): OptionType {

  return transformToOption<ApprovingAgency>(approvingAgency, (model) =>
    [
      model.approvingAgencyId, 
      model.approvingAgencyName
    ]);
}

