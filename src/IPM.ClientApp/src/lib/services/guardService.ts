import { goto } from "$app/navigation"
import { getUserInfo } from "@stores/userInfo.svelte"
import { AppLog } from "@utils/log";

type UserInfo = {
  email: string;
  firstName: string; 
  lastName: string; 
  role: string;
  sub: string;
} | null

type HandlerProps = {
  isLoggedIn: boolean,
  isRoleMatch: boolean,
}

type Routes = {
  path: string[],
  roles?: string[],
  handler: (props: HandlerProps) => void
}

export type Options = {
  getUserInfo: () => Promise<UserInfo>
  routes: Routes[]
}

export async function isCurrentUserHasRole(roles: string[]): Promise<boolean> {
  let currentUser = await getUserInfo();
  for (let role of roles) {
    if (currentUser?.role === role) return true;
  }
  return false;
}


function guard(options: Options) {

  return async (pathname: string) => {

    AppLog.info("Guard work");

    for (const route of options.routes) {
      const matches = route.path.some(path => {
        if (path.endsWith("/*")) {
          const base = path.slice(0, -2);
          return pathname.startsWith(base);
        } else {
          return pathname === path;
        }
      });
      if (!matches) continue;

      const user = await options.getUserInfo();

      const isLoggedIn = user == null ? false : true;

      let isRoleMatch = false;

      if (route.roles) {
        isRoleMatch = route.roles.some(role => role == user?.role);
      }

      route.handler({
        isLoggedIn,
        isRoleMatch
      });

      break;
    }
  };
}

const options: Options = {
  getUserInfo: async () => {
    let currentUser = await getUserInfo();
    return currentUser;
  },
  routes: [
    {
      path: ["/login", "/register"],
      handler: ({ isLoggedIn }) => {
        if (isLoggedIn) {
          goto("/dashboard");
        }
      }
    },
    {
      path: ["/dashboard/admin/*"],
      roles: ["admin"],
      handler: ({ isRoleMatch }) => {
        if (!isRoleMatch) {
          goto("/dashboard");
        }
      }
    },
    {
      path: ["/dashboard/*"],
      handler: ({ isLoggedIn }) => {
        if (!isLoggedIn) {
          goto("/login?no_check_user=true");
        }
      }
    },
  ]
}
const guardHook = guard(options);
export default guardHook;
