import transformToOption from "@useCases/common/transformToOption";
import type {  Category } from "@useCases/useCases.types";

export default function transformCategoryToOption(category: Category[]): Array<{value: string, name: string}> {

  return transformToOption<Category>(category, (model) =>
    [
      model.categoryId,
      model.categoryName
    ]);
}

