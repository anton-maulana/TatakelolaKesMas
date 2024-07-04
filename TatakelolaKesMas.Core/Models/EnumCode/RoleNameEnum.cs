namespace TatakelolaKesMas.Core.Models.EnumCode;

public class RoleNameEnum : BaseEnumCode
{

    protected RoleNameEnum(string code) : base(code)
    {
    }

    public static RoleNameEnum Administrator => new("administrator");
    public static RoleNameEnum User => new("user");
    public static RoleNameEnum PpkUser => new("ppkuser");
    public static RoleNameEnum RegionUser => new("regionuser");
    public static RoleNameEnum CenterUser => new("centeruser");
}