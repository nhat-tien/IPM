import { projectEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type { Project } from "@useCases/useCases.types";

export default async function getAllProject() {
  return await getAll<Project>(projectEndPoint);
}
