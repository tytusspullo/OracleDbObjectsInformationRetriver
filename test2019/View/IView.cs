using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2019
{
    public interface IView<T>
    {
        void SetControler(Controller controler);
        string User { get; set; }
        string Password { get; set; }

        
        void LoadDataToGrid(IList<T> list);
        void ShowMessage(string message);
        void ShowLoadDataButton();
    }
}
