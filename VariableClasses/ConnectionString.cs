using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VariableClasses
{
    public class ConnectionString
    {

        public string connectionString { get;} = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Plock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    }
}
