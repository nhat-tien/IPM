import transformToTable from "@useCases/common/transformToTable";
import type {  Position } from "@useCases/useCases.types";

export default function transformPositionToTable(position: Position[]): string[][] {

  return transformToTable<Position>(position, (model) =>
    [
      model.positionId + "",
      model.positionName
    ]);
}
