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
using ReservaRestauranteBL;
using ReservaRestauranteEN;
namespace ESFE.ReservaRestaurante
{
    /// <summary>
    /// Lógica de interacción para CRUDCobro.xaml
    /// </summary>
    public partial class CRUDCobro : Window
    {
        CobroEN _cobroEN = new CobroEN();
        CobroBL _cobroBL = new CobroBL();
        public CRUDCobro()
        {
            InitializeComponent();
            CargarGrid();
        }
        public void CargarGrid()
        {
            dgMostrarCobro.ItemsSource = _cobroBL.MostrarCobro(new CobroEN());
        }
        private bool EsSoloLetras(string texto)
        {
            return texto.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
        private bool EsSoloDecimal(string texto)
        {
            return decimal.TryParse(texto, out _);
        }
        private bool EsByteValido(string texto)
        {
            return byte.TryParse(texto, out _);
        }
        private bool EsSoloNumeros(string texto)
        {
            return texto.All(char.IsDigit);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {


            string montoTotal = txtMontoTotal.Text;
            if (string.IsNullOrEmpty(montoTotal))
            {
                MessageBox.Show("El campo 'Monto total a pagar' no puede estar vacío.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string metodoPago = txtMetodoPago.Text;
            if (!EsSoloLetras(metodoPago))
            {
                MessageBox.Show("El campo 'Métedo a pagar' no puede estar vacío.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                _cobroEN.Fecha = DateTime.Parse(dateFecha.Text);
                _cobroEN.MontoTotal = Convert.ToDecimal(txtMontoTotal);
                _cobroEN.MetodoPago = txtMetodoPago.Text;
                _cobroEN.IdReserva = Convert.ToInt32(txtIdReserva.Text);
                _cobroBL.GuardarCobro(_cobroEN);
                CargarGrid();

                MessageBox.Show("Registro de cobro guardado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

