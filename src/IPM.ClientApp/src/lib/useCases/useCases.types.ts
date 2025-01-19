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

export type Category  = {
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


