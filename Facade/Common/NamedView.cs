﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facade.Common
{
    public abstract class NamedView
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Code")]
        public string Code { get; set; }
    }
}
