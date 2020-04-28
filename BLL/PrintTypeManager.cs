using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weber_Favez_CardProject
{
    public class PrintTypeManager : IPrintTypeManager
    {
        private IPrintTypeDB PrintTypeDb { get; }

        public PrintTypeManager(IPrintTypeDB printTypeDB)
        {
            PrintTypeDb = printTypeDB;
        }

        public List<PrintType> GetAllPrintType() 
        {
            return PrintTypeDb.GetAllPrintType();
        }

        public PrintType GetPrintTypeById(int id) 
        {
            return PrintTypeDb.GetPrintTypeById(id);
        }

    }
}
