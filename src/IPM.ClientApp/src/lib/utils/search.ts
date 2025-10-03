function removeVietnameseTones(str: string): string {
  return str
    .normalize("NFD")
    .replace(/[\u0300-\u036f]/g, "")
    .replace(/đ/g, "d")
    .replace(/Đ/g, "D");
}

export function isStringInlucde(source: string, search: string): boolean {
  let sourceNonTone = removeVietnameseTones(source).toLowerCase();
  let searchNonTone = removeVietnameseTones(search).toLowerCase();
  return sourceNonTone.includes(searchNonTone);
}
