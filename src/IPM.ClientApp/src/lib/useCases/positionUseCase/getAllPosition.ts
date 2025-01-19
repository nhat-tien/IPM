import { positionEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type {  Position } from "@useCases/useCases.types";

export default async function getAllPosition() {
  return await getAll<Position>(positionEndPoint);
}
