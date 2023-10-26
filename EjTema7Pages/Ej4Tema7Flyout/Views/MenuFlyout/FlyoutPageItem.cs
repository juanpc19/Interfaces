using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4Tema7Flyout.Views.MenuFlyout
{
 //la hago public para quitar futuros dolores de cabeza,
 //contiene metodos para obtener y asignar los iconos a las paginas que conforman el flyout
    public class FlyoutPageItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
    }
}
