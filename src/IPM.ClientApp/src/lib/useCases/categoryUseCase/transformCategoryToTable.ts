import transformToTable from "@useCases/common/transformToTable";
import type {  Category } from "@useCases/useCases.types";

export default function transformCategoryToTable(category: Category[]): any[][] {

  return transformToTable<Category>(category, (model) =>
    [
      model.categoryId,
      model.categoryName
    ]);
}
