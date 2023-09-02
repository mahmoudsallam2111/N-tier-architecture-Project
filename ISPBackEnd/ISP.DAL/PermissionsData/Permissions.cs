namespace ISP.DAL.PermissionsData;

public static class Permissions
{
    public enum PermissionsModuleName
    {
        //Controllers Permissins
        Bill,
        Branch,
        Central,
        Client,
        Governorate,
        Offer,
        Package,
        Provider,
        Role,
        User,

    }
    public static List<string> GeneratePermissionsOfModule(string module)
    {
        return new List<string>
            {
                $"Permission.{module}.View",
                $"Permission.{module}.Create",
                $"Permission.{module}.Edit",
                $"Permission.{module}.Delete",
            };
    }

    public static List<string> PermissionsList()
    {
        var allPermissions = new List<string>();
        foreach (var module in Enum.GetValues(typeof(PermissionsModuleName)))
        {
            allPermissions.AddRange(GeneratePermissionsOfModule(module.ToString()));
        }
        return allPermissions;
    }
}
