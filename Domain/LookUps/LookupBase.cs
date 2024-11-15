using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Domain.LookUps
{
    public class LookupBase
    {
        int ID AUTO_INCREMENT PRIMARY KEY;
        string NameEn UNIQUE NOT NULL;
	    string NameAr VARCHAR(10) UNIQUE NOT NULL;
    }
}
