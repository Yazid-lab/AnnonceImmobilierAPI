﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAnnonce.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name) : base($"No user with the email '{name}' was found") { }
    }
}
