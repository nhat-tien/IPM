import transformToTable from "@useCases/common/transformToTable";
import type {  Sponsor } from "@useCases/useCases.types";

export default function transformSponsorToTable(sponsor: Sponsor[]): string[][] {

  return transformToTable<Sponsor>(sponsor, (model) =>
    [
      model.sponsorId + "",
      model.sponsorName
    ]);
}

