import { userEndPoint } from "@services/httpService"
import { getUserInfo } from "@stores/userInfo.svelte"
import type { UseCaseResult, User } from "@useCases/useCases.types";
import { z } from "zod";

const UpdateProfileReqScheme = z.object({
  firstName: z.string(),
  lastName: z.string(),
  phoneNumber: z.string()
    .length(10, { message: "Chưa đúng định dạng số điện thoại" })
    .startsWith("0", { message: "Chưa đúng định dạng số điện thoại" }),
  sex: z.number().min(0).max(2),
  address: z.string(),
  positionId: z.number().gt(0),
  affiliatedUnitId: z.number().gt(0),
});

type UpdateProfileReq = z.infer<typeof UpdateProfileReqScheme>;

type UpdateProfileReqPartial = Partial<UpdateProfileReq>;

export default async function updateProfile(formData: UpdateProfileReq, data: User): Promise<UseCaseResult> {
  try {
    const info = getUserInfo();

    UpdateProfileReqScheme.parse(formData);

    let req: UpdateProfileReqPartial = {};

    if (checkTextField(formData.firstName, data.firstName)) {
      req.firstName = formData.firstName;
    }

    if (checkTextField(formData.lastName, data.lastName)) {
      req.lastName = formData.lastName;
    }

    if (checkTextField(formData.address, data.address)) {
      req.address = formData.address;
    }

    if (checkTextField(formData.phoneNumber, data.phoneNumber)) {
      req.phoneNumber = formData.phoneNumber;
    }

    if (checkTextField(formData.lastName, data.lastName)) {
      req.lastName = formData.lastName;
    }

    if (formData.sex !== data.sex) {
      req.sex = formData.sex;
    }

    if (checkOption(formData.affiliatedUnitId, data.affiliatedUnitId)) {
      req.affiliatedUnitId = formData.affiliatedUnitId;
    }

    if (checkOption(formData.positionId, data.positionId)) {
      req.positionId = formData.positionId;
    }

    await userEndPoint.patch(`${info?.sub}`, {
      json: req,
      credentials: "include"
    });

    return {
      isSuccess: true,
      error: null,
    }

  } catch (e: any) {

    return {
      isSuccess: false,
      error: e,
    }
  }
}


function checkTextField(updateProperty: string, oldValue: string): boolean {
  return updateProperty !== oldValue && updateProperty !== "";
}

function checkOption(updateProperty: number | null, oldValue: number): boolean {
  return updateProperty != null && updateProperty > 0 && updateProperty != oldValue;
}

