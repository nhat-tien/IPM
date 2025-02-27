import type { ZodError } from "zod";

export type UseCaseResult = {
  isSuccess: boolean;
  error: ZodError | string | null
}

export type UseCaseResultWithData<T> = UseCaseResult & {
  data: T
}

export type OptionType = {
  value: string;
  name: string;
}

export type FileUpload = {
  fileTypeId: number,
  file: File | null
}

export type ApprovingAgency = {
  approvingAgencyId: number,
  approvingAgencyName: string,
  createdAt: string,
  updatedAt: string
}

export type AffiliatedUnit = {
  affiliatedUnitId: number,
  affiliatedUnitName: string,
  createdAt: string,
  updatedAt: string,
}

export type AidType = {
  aidTypeId: number,
  aidTypeName: string,
  createdAt: string,
  updatedAt: string,
}

export type CurrencyUnit = {
  currencyUnitId: number,
  currencyUnitName: string,
  createdAt: string,
  updatedAt: string,
}

export type Category = {
  categoryId: number,
  categoryName: string,
  createdAt: string,
  updatedAt: string,
}

export type Counterparty = {
  counterpartyId: number,
  counterpartyName: string,
  createdAt: string,
  updatedAt: string,
}

export type Position = {
  positionId: number,
  positionName: string,
  createdAt: string,
  updatedAt: string,
}

export type Sponsor = {
  sponsorId: number,
  sponsorName: string,
  createdAt: string,
  updatedAt: string,
}

export type FileType = {
  fileTypeId: number,
  fileTypeName: string,
  createdAt: string,
  updatedAt: string
}

export type Project = {
  projectId: number,
  projectNameEnglish: string,
  projectNameVietnamese: string,
  projectPurpose: string,
  content: string,
  createdAt: string
  updatedAt: string,
  fundedEquipment: string,
  projectBudget: string,
  startDate: string,
  endDate: string,
  projectProgress: string,
  percentageOfProgress: string,
  affiliatedUnitId: number,
  affiliatedUnit: AffiliatedUnit | null,
  categoryId: number,
  category: Category | null,
  sponsorId: number,
  sponsor: Sponsor | null,
  aidTypeId: number,
  aidType: AidType | null,
  approvingAgencyId: number,
  approvingAgency: ApprovingAgency | null,
  counterpartyId: number,
  counterparty: Counterparty | null,
  currencyUnitId: number,
  currencyUnit: CurrencyUnit | null
  participations: Participation[]
}

export type Role = {
  roleId: string,
  roleName: string
}

export type User = {
  userId: string,
  userName: string,
  firstName: string,
  lastName: string,
  positionId: number,
  affilatedUnitId: number,
  roleId: number,
  phoneNumber: string,
  address: string,
  email: string,
  status: number,
  createdAt: string,
  updatedAt: string,
  role: Role
  position: Position
  verifiedCodeEmail: number,
  verifiedStatus: number,
  verificationValidTime: string
}

export type Participation = {
  projectId: number,
  userId: string,
  joinDate: string,
  status: string,
  note: string,
  owner: true,
  createdAt: string,
  updatedAt: string,
  user: User | null
  project: Project | null
}

export type ParticipationReduce = {
  owner: boolean,
  lastName: string,
  firstName: string,
  email: string,
  userId: string,
}

export type ParticipationDiff = {
  type: "delete" | "add",
  payload: ParticipationReduce
}

export type EditState = {
  projectNameVietnamese: string;
  projectNameEnglish: string;
  projectProgress: string;
  content: string;
  projectPurpose: string;
  percentageOfProgress: string;
  categoryId: string;
  affiliatedUnitId: string;
  sponsorId: string;
  aidTypeId: string;
  approvingAgencyId: string;
  counterPartyId: string;
  members: ParticipationReduce[];
  participationDiff: ParticipationDiff[],
  fileUpload: FileUpload[];
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
  id: string;
};

