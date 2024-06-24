using LDKProject.Entities;
using LDKProject.Models.Response;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace LDKProject.Utils;
public class Utils
{
    public static Response NewSuccessResponse(Object? data, Pagination? pagination, string? message)
    {
        return new Response
        {
            Data = data,
            Success = true,
            Message = message,
            Status = Constants.Status.StatusOK,
            Code = (int)HttpStatusCode.OK,
            Pagination = pagination,
        };
    }

    public static Response NewSuccessCreateResponse(Object? data, Pagination? pagination, string? message)
    {
        return new Response
        {
            Data = data,
            Success = true,
            Message = message,
            Status = Constants.Status.StatusCreated,
            Code = (int)HttpStatusCode.Created,
            Pagination = pagination,
        };
    }

    public static Response NewErrorResponse(Object? data, string? message, string status, int code)
    {
        return new Response
        {
            Data = data,
            Success = false,
            Message = message,
            Status = status,
            Code = code,
        };
    }

    public static Response NewErrorResponse(Object? data, string? message, string status, HttpStatusCode code)
    {
        return new Response
        {
            Data = data,
            Success = false,
            Message = message,
            Status = status,
            Code = (int)code,
        };
    }
}

public class Roles
{
    public static string? GetUserId(HttpContext? context)
    {
        if (context == null || context.User == null)
        {
            return null;
        }

        string? userEmail = context.User.FindFirst(ClaimTypes.Email)?.Value;
        if (userEmail == null)
        {
            return userEmail;
        }

        return context.User.FindFirst(userEmail)?.Value;
    }

    public static User? GetUserFromContext(HttpContext? context)
    {
        if (context == null || context.User == null)
        {
            return null;
        }

        var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
        var role = context.User.FindFirst(ClaimTypes.Role)?.Value;
        var pin = context.User.FindFirst("pin")?.Value;
        var id = "";
        if (email != null)
        {
            id = context.User.FindFirst(email)?.Value;
        }

        if (email == null || role == null || id == null)
        {
            return null;
        }

        return new User { Id = id, Email = email, Role = role };
    }

    public static bool IsAdmin(string role)
    {
        return role == Constants.Roles.RoleAdmin;
    }

    public static bool IsInRole(HttpContext? context, string role, out User? user)
    {
        if (context == null || context.User == null)
        {
            throw new UnauthorizedAccessException();
        }

        var isTrue = context.User.IsInRole(role);
        if (isTrue)
        {
            user = GetUserFromContext(context);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            return isTrue;
        }

        user = null;
        return false;
    }
}

public class Errors
{
    public static bool IsDuplicateError(Exception e)
    {
        if (e.InnerException is SqlException sqlException)
        {
            return sqlException.Number == 2627 || sqlException.Number == 2601 || sqlException.Number == 547;
        }

        return false;
    }

    //public static void WrapDuplicateError(Exception e, string message)
    //{
    //    if (e.InnerException is SqlException sqlException)
    //    {
    //        if (sqlException.Number == 2627 || sqlException.Number == 2601)
    //        {
    //            throw new DuplicateRecordException($"{message}: {ExtractValue(sqlException)}");
    //        }
    //        throw e;
    //    }
    //}

    public static string? ExtractValue(Exception? e)
    {
        if (e == null)
        {
            return null;
        }

        string pattern = @"\(([^)]*)\)";

        Regex regex = new Regex(pattern);
        Match match = regex.Match(e.Message);
        if (match.Success)
        {
            return match.Value;
        }

        return null;
    }
}
