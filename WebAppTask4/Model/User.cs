using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebAppTask4.Areas.Identity.Data;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    
    public DateTime RegistrationTime { get; set; }

    public DateTime LastLoginTime { get; set; }

    public bool IsActive { get; set; } = true;
}

