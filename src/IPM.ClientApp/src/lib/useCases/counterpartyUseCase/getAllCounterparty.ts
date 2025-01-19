import { counterpartyEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type {  Counterparty } from "@useCases/useCases.types";

export default async function getAllCounterparty() {
  return await getAll<Counterparty>(counterpartyEndPoint);
}
