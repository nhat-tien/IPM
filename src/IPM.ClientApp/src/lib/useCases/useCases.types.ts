import type { ZodError } from "zod";

export type UseCaseResult = {
  isSuccess: boolean;
  error: ZodError | string | null
}

export type UseCaseResultWithData<T> = UseCaseResult & {
  data: T
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
  affilatedUnitId: number,
  categoryId: number,
  sponsorId: number,
  aidTypeId: number,
  approvingAgencyId: number,
  counterpartyId: number,
  currencyUnitId: number,
  ownerId: string,
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


