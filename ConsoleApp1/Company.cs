using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2016
{
    [Serializable]
    public class Company
    {
        public string CompanyName { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return CompanyName;
        }
        public Company(string com)
        {
            CompanyName = com;
        }
    }
}
