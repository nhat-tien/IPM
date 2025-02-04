import transformToTable from "@useCases/common/transformToTable";
import type { User } from "@useCases/useCases.types";

export default function transformUserToTable(users: User[]): any[][] {

  return transformToTable<User>(users, (model) =>
    [
      model.userId, 
      model.userName,
      model.email,
      model.lastName,
      model.firstName
    ]);
}


