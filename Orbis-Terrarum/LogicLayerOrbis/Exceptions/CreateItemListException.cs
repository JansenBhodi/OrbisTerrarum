﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerOrbis.Exceptions
{
    public class CreateItemListException : Exception
    {
        public CreateItemListException() { }
        public CreateItemListException(string message) : base(message) { }
    }
}
