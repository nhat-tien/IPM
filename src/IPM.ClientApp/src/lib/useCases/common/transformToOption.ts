export type OptionType =  Array<{value: string, name: string}>

export default function transformToOption<T>(models: T[], callback: (e: T) => any[]): Array<{value: string, name: string}> {

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


