using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uml_workshop_2
{
    class Controller
    {
        public  void controller()
        {
            View view = new View();
            view.introText();
            view.viewText();
        }
    }
}
