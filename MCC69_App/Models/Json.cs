﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Json<T>
    {
        public int result { get; set; }
        public List<T> data { get; set; }
    }
}
