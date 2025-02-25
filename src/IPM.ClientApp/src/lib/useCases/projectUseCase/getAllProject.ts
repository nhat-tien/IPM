import { projectEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type { Project } from "@useCases/useCases.types";

export default function getAllProject() {
  return getAll<Project>(projectEndPoint, "?include=Category");
}
