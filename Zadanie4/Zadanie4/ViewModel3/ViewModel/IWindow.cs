using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModel
{
    public interface IWindow
    {
        void Show();
        void Close();
        void DisplayPopup(string popoutM);
    }
}
