using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    [Table("passport")]
    public class Passport
    {
        private string type;
        private string number;
        public string Type { get => type; set => type = value; }
        public string Number { get => number; set => number = value; }
    }
}
