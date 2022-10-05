namespace BlazorApp1.Server.Services.Infrastructure
{
    public interface IValidationService
    {
        public bool IsAdmin(int UserId);

        public bool HasPermissionToChange(int UserId);

        public bool HasPermission(int UserId);
    }
}
