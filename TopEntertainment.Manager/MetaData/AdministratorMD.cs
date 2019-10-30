using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopEntertainment.Manager.MetaData
{
    public class AdministratorMD
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Identity { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public int Role { get; set; }
    }
}
