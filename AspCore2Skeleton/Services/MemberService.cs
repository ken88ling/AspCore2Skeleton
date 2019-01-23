using AspCore2Skeleton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspCore2Skeleton.Services
{
    public class MemberService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly GlobalVars _globalVars;

        public MemberService(IHttpContextAccessor httpContextAccessor,  GlobalVars globalVars)
        {
            _httpContextAccessor = httpContextAccessor;
            _globalVars = globalVars;
        }

        public string LogOut(string token, string membercode)
        {
            var result = "result";
            return result;
        }
    }
}
