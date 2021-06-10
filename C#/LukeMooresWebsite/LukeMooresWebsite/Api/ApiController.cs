using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using LukeMooresWebsite.Entities

namespace LukeMooresWebsite.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpPost]
        public string Post(ApiRequest request)
        {
            var JSONResponse = "";
            try
            {
                var response = new ApiResponse(request.RequestMessage);
                JSONResponse = JsonSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                JSONResponse = JsonSerializer.Serialize(new ApiResponse(Settings.APIErrorString()));
            }
            return JSONResponse;
        }
    }
}
