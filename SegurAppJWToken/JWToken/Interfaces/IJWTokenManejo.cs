﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurAppJWToken.JWToken.Interfaces
{
    public interface IJWTokenManejo
    {
        string GenerateToken(string usuario, string name, string rol);
    }
}
