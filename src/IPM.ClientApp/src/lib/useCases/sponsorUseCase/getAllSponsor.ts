import { sponsorEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type {  Sponsor } from "@useCases/useCases.types";

export default async function getAllSponsor(): Promise<Sponsor[]> {
  return await getAll<Sponsor>(sponsorEndPoint);
}

