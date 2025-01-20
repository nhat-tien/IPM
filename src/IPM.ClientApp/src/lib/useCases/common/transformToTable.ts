
export default function transformToTable<T>(models: T[], callback: (e: T) => any[]): any[][] {
  let table = [];
  for(let model of models) {
    table.push(callback(model));
  }
  return table;
}

