import { myProjectEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type { Project } from "@useCases/useCases.types";

export default function getOwnProject() {
  return getAll<Project>(myProjectEndPoint);
}
