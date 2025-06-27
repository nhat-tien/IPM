import type { ZodError } from "zod";

export type UseCaseResult = {
  isSuccess: boolean;
  error: ZodError | string | null | ServerError
}

export type UseCaseResultWithData<T> = UseCaseResult & {
  data: T;
}

export type OptionType = {
  value: string;
  name: string;
}

export type FileUpload = {
  fileTypeId: number;
  file: File | null
}

export type ApprovingAgency = {
  approvingAgencyId: number;
  approvingAgencyName: string;
  createdAt: string;
  updatedAt: string
}

export type AffiliatedUnit = {
  affiliatedUnitId: number;
  affiliatedUnitName: string;
  createdAt: string;
  updatedAt: string;
}

export type AidType = {
  aidTypeId: number;
  aidTypeName: string;
  createdAt: string;
  updatedAt: string;
}

export type CurrencyUnit = {
  currencyUnitId: number;
  currencyUnitName: string;
  createdAt: string;
  updatedAt: string;
}

export type Category = {
  categoryId: number;
  categoryName: string;
  createdAt: string;
  updatedAt: string;
}

export type Counterparty = {
  counterpartyId: number;
  counterpartyName: string;
  createdAt: string;
  updatedAt: string;
}

export type Position = {
  positionId: number;
  positionName: string;
  createdAt: string;
  updatedAt: string;
}

export type Sponsor = {
  sponsorId: number;
  sponsorName: string;
  createdAt: string;
  updatedAt: string;
}

export type FileType = {
  fileTypeId: number;
  fileTypeName: string;
  createdAt: string;
  updatedAt: string
}

export type FileApp = {
  fileId: number;
  fileName: string;
  fileType: FileType;
  fileTypeId: number;
  objectName: string;
  projectId: number;
  createdAt: string;
  updatedAt: string;
  user: User;
  url: string | null;
}

export type Project = {
  projectId: number;
  projectNameEnglish: string;
  projectNameVietnamese: string;
  projectPurpose: string;
  content: string;
  createdAt: string
  updatedAt: string;
  fundedEquipment: string;
  projectBudget: string;
  startDate: string;
  endDate: string;
  projectProgress: string;
  percentageOfProgress: string;
  affiliatedUnitId: number;
  affiliatedUnit: AffiliatedUnit | null;
  categoryId: number | null;
  category: Category | null;
  sponsorId: number | null;
  sponsor: Sponsor | null;
  aidTypeId: number | null;
  aidType: AidType | null;
  approvingAgencyId: number | null;
  approvingAgency: ApprovingAgency | null;
  counterpartyId: number | null;
  counterparty: Counterparty | null;
  currencyUnitId: number | null;
  currencyUnit: CurrencyUnit | null;
  participations: Participation[];
  isDeleted: boolean;
  isReported: boolean;
}

export type Role = {
  roleId: string;
  roleName: string;
}

export type User = {
  userId: string;
  userName: string;
  firstName: string;
  lastName: string;
  positionId: number;
  affiliatedUnitId: number;
  roleId: number;
  phoneNumber: string;
  avatarUrl: string;
  sex: number;
  address: string;
  email: string;
  status: number;
  createdAt: string;
  updatedAt: string;
  role: Role;
  position: Position;
  affiliatedUnit: AffiliatedUnit;
  verifiedCodeEmail: number;
  verifiedStatus: number;
  verificationValidTime: string;
  participations: Participation[];
}

export type Participation = {
  projectId: number;
  userId: string;
  joinDate: string;
  status: string;
  note: string;
  role: string;
  createdAt: string;
  updatedAt: string;
  user: User | null;
  project: Project | null;
}

export type ParticipationReduce = {
  role: string;
  lastName: string;
  firstName: string;
  email: string;
  userId: string;
}

export type ParticipationDiff = {
  type: "delete" | "add";
  payload: ParticipationReduce;
}

export type EditState = {
  projectNameVietnamese: string;
  projectNameEnglish: string;
  projectProgress: string;
  content: string;
  projectPurpose: string;
  projectBudget: string;
  percentageOfProgress: string;
  fundedEquipment: string;
  startDate: Date | null;
  endDate: Date | null;
  categoryId: number | null;
  affiliatedUnitId: number | null;
  sponsorId: number | null;
  aidTypeId: number | null;
  approvingAgencyId: number | null;
  counterPartyId: number | null;
  members: ParticipationReduce[];
  participationDiff: ParticipationDiff[];
};


export type EditProjectDataPage = {
  project: Project;
  affiliatedUnit: Promise<AffiliatedUnit[]>;
  category: Promise<Category[]>;
  aidType: Promise<AidType[]>;
  approvingAgency: Promise<ApprovingAgency[]>;
  sponsor: Promise<Sponsor[]>;
  counterparty: Promise<Counterparty[]>;
  users: Promise<User[]>;
  fileType: Promise<FileType[]>;
  files: Promise<FileApp[]>;
  id: string;
};

export type ServerError = {
  detail: string;
  status: number;
  title: string;
  type: string;
}

