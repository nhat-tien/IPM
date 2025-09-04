import { fileEndPoint } from "@services/httpService";
import get from "@useCases/common/get";

export async function getUrlFile(fileId: number) {
  return await get<{ url: string, name: string, extension: string }>(fileEndPoint, fileId.toString(), "/url");
}

export async function handleDownload(fileId: number) {
  const result = await getUrlFile(fileId);
  var link = document.createElement("a");

  if (!result) return;

  link.setAttribute("download", `${result.name}.${result.extension}`);
  link.href = result?.url;
  document.body.appendChild(link);
  link.click();
  link.remove();
}

