﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Data.Common
{
    public abstract class PeriodData
    {
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
