import type { OptionType } from "@useCases/useCases.types";

export default function transformToOption<T>(models: T[], callback: (e: T) => any[]): OptionType[] {

  let options = [];
  for(let model of models) {
    let option = callback(model);
    options.push({
      value: option[0],
      name: option[1],
    });
  }
  return options;
}


