using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weber_Favez_CardProject
{
    public interface IPrintTypeManager
    {
        List<PrintType> GetAllPrintType();
        PrintType GetPrintTypeById(int id);

    }
}
