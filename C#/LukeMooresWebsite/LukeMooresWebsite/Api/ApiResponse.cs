using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LukeMooresWebsite.Entities;

namespace LukeMooresWebsite.Api
{
    [Serializable]
    public class ApiResponse
    {
        private string _exceptionString = Settings.APIErrorString();
        public ApiResponse(string originalRequest)
        {
            if (originalRequest == null)
            {
                OriginalRequest = "Please Submit a Request to see it here";
                ErrorMessage = "No Request Message was sent";
            }
            else if (originalRequest == _exceptionString)
            {
                ErrorMessage = _exceptionString;
                OriginalRequest = _exceptionString;
            }
            else if (originalRequest.Length > Settings.MaxRequestCharacters())
            {
                ErrorMessage = "Your Request Message was too long, it was trimmed down";
                OriginalRequest = originalRequest.Substring(0, Settings.MaxRequestCharacters());
            }
            else
            {
                OriginalRequest = originalRequest;
                ErrorMessage = "No Errors!";
            }
        }

        public string OriginalRequest { get; set; }
        public string DateOfRequest => DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        public string Message => "Thank you for your Request";

        public string ErrorMessage { get; set; }
    }
}
