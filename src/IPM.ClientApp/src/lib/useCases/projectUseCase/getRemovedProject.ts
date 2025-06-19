import { projectEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type { Project } from "@useCases/useCases.types";

export default function getRemovedProject() {
  return getAll<Project>(projectEndPoint, "?sortBy=ProjectId&sortOrd=asc&include=Category&filter=IsDeleted[=]true");
}

