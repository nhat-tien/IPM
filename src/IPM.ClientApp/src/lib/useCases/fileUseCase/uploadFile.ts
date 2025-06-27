import { fileEndPoint } from "@services/httpService";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

// const MAX_FILE_SIZE = 500000;

export const uploadFileScheme = z.object({
  file: z.any(),
  // .refine(
  //   (files) => files?.[0]?.size <= MAX_FILE_SIZE,
  //     `Max file size is 5MB.`
  // ),
  fileTypeId: z.string({ message: "filetype phai la string"}).nonempty({ message: "Loại file không để trống"}),
  projectId:  z.string({ message: "projectId phai la string"}).nonempty({ message: "Thiếu project id"}),
});

type Params = {
  file: File;
  fileTypeId: string;
  projectId: string;
  userId: string;
}

export default async function uploadFile(
  {
    file,
    fileTypeId,
    projectId,
    userId,
  }: Params ): Promise<UseCaseResult> {
  try {

  const formData = new FormData();

  formData.append("fileTypeId", fileTypeId);
  formData.append("projectId", projectId);
  formData.append("userId", userId);
  formData.append("file", file, file.name);



  await fileEndPoint.post("", {
    body: formData,
    credentials: "include",
  });

    return {
      isSuccess: true,
      error: null
    }

  } catch(e: any) {
    return {
      isSuccess: false,
      error: e
    }
  }

}
