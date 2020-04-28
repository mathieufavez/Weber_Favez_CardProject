using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IPrintTypeDB
    {
        List<PrintType> GetAllPrintType();

        PrintType GetPrintTypeById(int id);

    }
}
