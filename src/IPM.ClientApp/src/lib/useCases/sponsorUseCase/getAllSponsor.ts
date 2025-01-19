import { sponsorEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type {  Sponsor } from "@useCases/useCases.types";

export default async function getAllSponsor() {
  return await getAll<Sponsor>(sponsorEndPoint);
}

