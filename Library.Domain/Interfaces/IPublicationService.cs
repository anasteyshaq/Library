﻿using Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IPublicationService
    {
        bool CheckIfAvailable(Publication publication);
    }
}
