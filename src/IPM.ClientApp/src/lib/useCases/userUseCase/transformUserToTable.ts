import transformToTable from "@useCases/common/transformToTable";
import type { User } from "@useCases/useCases.types";

type Options = {
  excludeFields: Array<keyof User> 
}

const fields = ["userId", "userName", "email", "lastName", "firstName", "role"] as const;

export default function transformUserToTable(users: User[], options?: Options): string[][] {
  return transformToTable<User>(users, (model) => {
    return fields.filter(field => !options?.excludeFields?.includes(field))
      .map(field => {
        switch (field) {
          case "userId": return model.userId;
          case "userName": return model.userName;
          case "email": return model.email;
          case "lastName": return model.lastName;
          case "firstName": return model.firstName;
          case "role": return model.role?.roleName;
          default: return null;
        }
      });
  });
}

