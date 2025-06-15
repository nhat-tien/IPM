import { projectEndPoint } from "@services/httpService";
import type { Project, UseCaseResult } from "@useCases/useCases.types";
import { dateToString } from "@utils/datetime";
import { HTTPError } from "ky";
import { ZodError } from "zod";

// const UpdateProjectScheme = z.object({
//   projectNameVietnamese: z.string(),
//   projectNameEnglish: z.string(),
//   projectProgress: z.string(),
//   content: z.string(),
//   projectPurpose: z.string(),
//   projectBudget: z.string(),
//   percentageOfProgress: z.string(),
//   fundedEquipment: z.string(),
//   startDate: z.string(),
//   endDate: z.string(),
//   categoryId: z.number().gt(0),
//   affiliatedUnitId: z.number().gt(0),
//   sponsorId: z.number().gt(0),
//   aidTypeId: z.number().gt(0),
//   approvingAgencyId: z.number().gt(0),
//   counterPartyId: z.number().gt(0),
// });

// type UpdateProjectRequest = z.infer<typeof UpdateProjectScheme>;
type UpdateProjectData = {
  projectNameVietnamese: string,
  projectNameEnglish: string,
  projectProgress: string,
  content: string,
  projectPurpose: string,
  projectBudget: string,
  percentageOfProgress: string,
  fundedEquipment: string,
  startDate: Date | null,
  endDate: Date | null,
  categoryId: number | null,
  affiliatedUnitId: number | null,
  sponsorId: number | null,
  aidTypeId: number | null,
  approvingAgencyId: number | null,
  counterPartyId: number | null,
}

export type UpdateProjectRequest = Omit<Partial<UpdateProjectData>, 'startDate' | 'endDate'> & {
  startDate?: string,
  endDate?: string,
  setValueProperties: string[],
};

export default async function updateProject({ formData, id, project }: { formData: UpdateProjectData, id: string, project: Project }): Promise<UseCaseResult> {
  try {
    let request: UpdateProjectRequest = {
      setValueProperties: []
    }

    if (checkTextField(formData.projectNameVietnamese, project.projectNameVietnamese)) {
      request.projectNameVietnamese = formData.projectNameVietnamese;
    }

    if (checkTextField(formData.projectNameEnglish, project.projectNameEnglish)) {
      request.projectNameEnglish = formData.projectNameEnglish;
    }

    if (checkTextField(formData.projectProgress, project.projectProgress)) {
      request.projectProgress = formData.projectProgress;
    }

    if (checkTextField(formData.content, project.content)) {
      request.content = formData.content;
    }

    if (checkTextField(formData.projectPurpose, project.projectPurpose)) {
      request.projectPurpose = formData.projectPurpose;
    }

    if (checkTextField(formData.projectBudget, project.projectBudget)) {
      request.projectBudget = formData.projectBudget;
    }

    if (checkTextField(formData.projectBudget, project.projectBudget)) {
      request.projectBudget = formData.projectBudget;
    }

    if (checkTextField(formData.fundedEquipment, project.fundedEquipment)) {
      request.fundedEquipment = formData.fundedEquipment;
    }

    if (checkTextField(formData.percentageOfProgress, project.percentageOfProgress)) {
      request.percentageOfProgress = formData.percentageOfProgress;
    }

    if (checkDate(formData.startDate, project.startDate)) {
      request.startDate = dateToString(formData.startDate);
    }

    if (checkDate(formData.endDate, project.endDate)) {
      request.endDate = dateToString(formData.endDate);
    }

    if (checkOption(formData.affiliatedUnitId, project.affiliatedUnitId)) {
      request.affiliatedUnitId = formData.affiliatedUnitId;
      request.setValueProperties.push("AffiliatedUnitId");
    }

    if (checkOption(formData.categoryId, project.categoryId)) {
      request.categoryId = formData.categoryId;
      request.setValueProperties.push("CategoryId");
    }

    if (checkOption(formData.sponsorId, project.sponsorId)) {
      request.sponsorId = formData.sponsorId;
      request.setValueProperties.push("SponsorId");
    }

    if (checkOption(formData.aidTypeId, project.aidTypeId)) {
      request.aidTypeId = formData.aidTypeId;
      request.setValueProperties.push("AidTypeId");
    }

    if (checkOption(formData.approvingAgencyId, project.approvingAgencyId)) {
      request.approvingAgencyId = formData.approvingAgencyId;
      request.setValueProperties.push("ApprovingAgencyId");
    }

    if (checkOption(formData.counterPartyId, project.counterpartyId)) {
      request.counterPartyId = formData.counterPartyId;
      request.setValueProperties.push("CounterPartyId");
    }

    await projectEndPoint.patch(id, {
      json: request,
      credentials: "include",
    }).json();

    return {
      isSuccess: true,
      error: null,
    }

  } catch (e: ZodError | HTTPError | any) {
    if (e instanceof HTTPError && e.response.status == 401) {
      return {
        isSuccess: false,
        error: "Unauthorized",
      }
    }
    return {
      isSuccess: false,
      error: e,
    }
  }
}

function checkTextField(updateProperty: string, oldValue: string): boolean {
  return updateProperty !== oldValue && updateProperty !== "";
}

function checkDate(updateProperty: Date | null, oldValue: string): boolean {
  return dateToString(updateProperty) != oldValue
}

function checkOption(updateProperty: number | null, oldValue: number | null): boolean {
  return updateProperty !== oldValue;
}

