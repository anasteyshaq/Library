﻿using Library.Data;
using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class CreateApplicationModel
    {
        public List<Publication> SelectedPublications { get; set; }
        public List<CopyInForm> CopiesInForm { get; set; }
    }
}