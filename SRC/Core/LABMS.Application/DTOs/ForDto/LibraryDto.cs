﻿using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForDto
{
    public class LibraryDto
    {
        public int LibraryId { get; set; }

        public string? LibraryName { get; set; }

        public string? LibraryDetails { get; set; }
    }
}
