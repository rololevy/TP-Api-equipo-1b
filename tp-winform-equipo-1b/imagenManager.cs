using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_winform_equipo_1b
{
    internal class imagenManager
    {
        public static void cargarImagen(PictureBox pb,string imagen)
        {
            try
            {
                pb.Load(imagen);
            }
            catch (Exception)
            {
               pb.Load("https://demofree.sirv.com/nope-not-here.jpg");
            }
        }
    }
}

    

