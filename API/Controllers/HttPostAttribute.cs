using System;

namespace API.Controllers
{
    internal class HttPostAttribute : Attribute
    {
        public HttPostAttribute(string v)
        {
            V = v;
        }

        public string V { get; }
    }
}