using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL;
using DAL;

namespace FL
{
    public class FactoryKlantDAL
    {
        public static IKlantDAL CreateKlantDAL()
        {
            return new KlantDAL();
        }
        public static IKlantCollectionDAL CreateKlantCollectionDAL()
        {
            return new KlantDAL();
        }
    }
}
