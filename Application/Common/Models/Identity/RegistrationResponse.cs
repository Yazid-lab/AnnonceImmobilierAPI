﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAnnonce.Application.Common.Models.Identity
{
    public class RegistrationResponse
    {
        public string UserId { get; set; }
        public string EmailToken { get; set; }
    }
}
