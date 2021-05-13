using System;
using System.Collections.Generic;
using System.Text;
using CL;
using DAL;

namespace FL
{
    public class FactoryDagDAL
    {
        public static IDagDAL CreateDagDAL()
        {
            return new DagDAL();
        }
        public static IDagCollectionDAL CreateDagCollectionDAL()
        {
            return new DagDAL();
        }
    }
}
