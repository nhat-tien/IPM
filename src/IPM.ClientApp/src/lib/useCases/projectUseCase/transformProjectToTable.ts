import transformToTable from "@useCases/common/transformToTable";
import type { Project } from "@useCases/useCases.types";

export default function transformProjectToTable(project: Project[]): any[][] {

  return transformToTable<Project>(project, (model) =>
    [
      model.projectId, 
      model.projectNameVietnamese,
      model.category?.categoryName ?? ""
    ]);
}

