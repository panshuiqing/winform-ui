using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models.Admin;

namespace Tlw.ZPG.Services.Admin
{
    public class UserLoginResult : ServiceResult
    {
        public User User { get; set; }
    }
}
