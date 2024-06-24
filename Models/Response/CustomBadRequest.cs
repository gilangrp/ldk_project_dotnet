using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Net;
using System.Text;
using LDKProject.Constants;
namespace LDKProject.Models.Response
{
    public class CustomBadRequest : Response
    {
        public CustomBadRequest(ActionContext context)
        {
            Code = (int)HttpStatusCode.BadRequest;
            Status = Constants.Status.BadRequestErr;
            ConstructErrorMessages(context);
        }

        private void ConstructErrorMessages(ActionContext context)
        {
            var sb = new StringBuilder();
            foreach (var keyModelStatePair in context.ModelState)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    if (errors.Count == 1)
                    {
                        var errorMessage = GetErrorMessage(errors[0]);
                        sb.Append(string.Format("[{0}]: {1} ", key, errorMessage));
                    }
                    else
                    {
                        var sb2 = new StringBuilder();
                        for (var i = 0; i < errors.Count; i++)
                        {
                            sb2.Append(GetErrorMessage(errors[i]));
                            sb2.Append(';');
                        }
                        sb.Append(string.Format("[{0}]: {1} ", key, sb2.ToString()));
                    }
                }
            }

            Message = sb.ToString()[..(sb.Length - 1)];
        }

        string GetErrorMessage(ModelError error)
        {
            return string.IsNullOrEmpty(error.ErrorMessage) ?
                "The input was not valid." :
                error.ErrorMessage;
        }
    }
}
