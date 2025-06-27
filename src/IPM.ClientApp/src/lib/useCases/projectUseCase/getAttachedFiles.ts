import { fileEndPoint } from "@services/httpService";
import type { File } from "@useCases/useCases.types";
import { AppLog } from "@utils/log";


export default async function getAttachedFiles(projectId: string) {
  try {
    let data: File[] = await fileEndPoint.get("project/" + projectId + "?include=FileType,User", {
      credentials: "include",
    }).json();

    return data;

  } catch(e: any) {

    AppLog.error("Error when fetch API GET");

    return [];
  }
}
