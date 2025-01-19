import transformToTable from "@useCases/common/transformToTable";
import type {  Category } from "@useCases/useCases.types";

export default function transformCategoryToTable(category: Category[]): string[][] {

  return transformToTable<Category>(category, (model) =>
    [
      model.categoryId+ "",
      model.categoryName
    ]);
}
