using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mosing2.Models
{
    public interface ITravelDataProvider
    {
        Traveling GetTravel();
    }
}
