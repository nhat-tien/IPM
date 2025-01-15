
export default function transformToTable<T>(models: T[], callback: (e: T) => string[]): string[][] {
  let table = [];
  for(let model of models) {
    table.push(callback(model));
  }
  return table;
}
