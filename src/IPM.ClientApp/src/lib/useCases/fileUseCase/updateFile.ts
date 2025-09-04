import { fileEndPoint } from "@services/httpService";
import update from "@useCases/common/update";
import { z } from "zod";

const UpdateFileScheme = z.object({
  fileTypeId: z.string().nonempty({ message: "Loại file không để trống"}),
  fileId: z.number().gt(0, {message: "Không tìm thấy file"})
});

type UpdateFileRequest = z.infer<typeof UpdateFileScheme>;

export default async function updateFile(data: UpdateFileRequest) {

  return await update<UpdateFileRequest>({
    scheme: UpdateFileScheme,
    endpoint: fileEndPoint,
    formData: data,
    id: data.fileId + ""
  })
}
