
export default function projectRoleMapping(role: string): string {
  switch(role) {
    case "OWNER": 
      return "Chủ dự án";
    case "MEMBER":
      return "Thành viên";
    default:
      return "Không xác định";
  }
}
