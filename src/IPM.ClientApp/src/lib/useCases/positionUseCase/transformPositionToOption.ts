import transformToOption from "@useCases/common/transformToOption";
import type { OptionType, Position } from "@useCases/useCases.types";


export default function transformPositionToOption(positions: Position[]): OptionType[] {

  return transformToOption<Position>(positions, (position) =>
    [
      position.positionId,
      position.positionName
    ]);
}



