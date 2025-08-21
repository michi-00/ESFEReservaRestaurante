using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ESFE.ReservaRestaurante
{
    /// <summary>
    /// Lógica de interacción para InicioEmpleado.xaml
    /// </summary>
    public partial class InicioEmpleado : Window
    {
        public InicioEmpleado()
        {
            InitializeComponent();
        }

        private void btnCliemte(object sender, RoutedEventArgs e)
        {
            CRUDCliente cRUDCliente = new CRUDCliente();
            cRUDCliente.Show();
        }

        private void btnLugar_Click(object sender, RoutedEventArgs e)
        {

            CRUDLugar cRUDLugar = new CRUDLugar();
            cRUDLugar.Show();
        }

        private void btnReserva_Click(object sender, RoutedEventArgs e)
        {
            CRUDReserva cRUDReserva = new CRUDReserva();
            cRUDReserva.Show();
        }

        private void btnCobro_Click(object sender, RoutedEventArgs e)
        {
            CRUDCobro cRUDobro = new CRUDCobro();
            cRUDobro.Show();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            CRUDMenu cRUDMenu = new CRUDMenu();
            cRUDMenu.Show();
        }

        private void btnMesa_Click(object sender, RoutedEventArgs e)
        {
            CRUDMesa cRUDMesa = new CRUDMesa();
            cRUDMesa.Show();
        }
    }
}
