import transformToOption, { type OptionType } from "@useCases/common/transformToOption";
import type {  Sponsor } from "@useCases/useCases.types";

export default function transformSponsorToOption(sponsor: Sponsor[]): OptionType {

  return transformToOption<Sponsor>(sponsor, (model) =>
    [
      model.sponsorId, 
      model.sponsorName
    ]);
}


