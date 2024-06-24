namespace LDKProject.Constants;

public class Status
{
    public const string BadRequestErr = "BAD_REQUEST";
    public const string NotFoundErr = "NOT_FOUND";
    public const string StatusOK = "OK";
    public const string InternalServerErr = "INTERNAL_SERVER_ERROR";
    public const string StatusCreated = "CREATED";
    public const string Unauthorized = "UNAUTHORIZE";
    public const string Forbidden = "FORBIDDEN";
    public const string Conflict = "CONFLICT";
}

public class Roles
{
    public const string RoleAdmin = "Admin";
    public const string RoleUser = "User";
    public const string RoleAuthor = "Author";
    public const string RoleAdminN = "ADMIN";
    public const string RoleUserN = "USER";
    public const string RoleAuthorN = "AUTHOR";
}

public enum StatusOnsite
{
    WFO,
    WFH,
    LIBUR
}