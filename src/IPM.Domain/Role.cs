namespace IPM.Domain;

  public class Role
  {
    public string RoleId { get; set; }
    public string RoleName { get; set; }

    public Role(string roleId, string roleName)
    {
        RoleId = roleId;
        RoleName = roleName;
    }
}
 
