using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChikovMF.Application.Services.AdminService
{
    public class AdminService : IAdminService
    {
        public bool IsValidPassword(string password)
        {
            if (password != _configuration.Password)
            {
                return false;
            }
            return true;
        }

        private readonly AdminConfiguration _configuration;

        public AdminService(IOptions<AdminConfiguration> options)
        {
            _configuration = options.Value;
        }
    }
}
