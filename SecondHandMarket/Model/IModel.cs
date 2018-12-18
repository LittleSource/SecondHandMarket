using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandMarket.Model
{
    interface IModel
    {
        bool add();
        bool del();
        bool edit();
        bool findByName(string name);
    }
}
