namespace Domain.Permissions.PermissionsCategories
{
    public sealed record UsersPermissions
    {
        public readonly string USER_VIEW = "Permissions.User.View";
        public readonly string USER_GET = "Permissions.User.Get";
        public readonly string USER_CREATE = "Permissions.User.Create";
        public readonly string USER_EDIT = "Permissions.User.Edit";
        public readonly string USER_DELETE = "Permissions.User.Delete";
    }
}
