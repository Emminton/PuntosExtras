using PuntosExtra.BLL;
using PuntosExtra.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PuntosExtra.UI.Consultas
{
    /// <summary>
    /// Interaction logic for Consultas.xaml
    /// </summary>
    public partial class Consultas : Window
    {
        

        public Consultas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Personas>();

            if (CriterioTex.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = PersonaBLL.GetLis(prop => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriterioTex.Text);
                        listado = PersonaBLL.GetLis(p => p.PersonaId == id);
                        break;
                    default:
                        MessageBox.Show("No existe esa opción en el Filtro");
                        break;

                }
               // listado = listado.Where(c => c.Fecha.Date >= DesdeDateTimePcker.SelectedDate.Value && c.PersonaId.ToString <= HastaDateTimePicker.SelectedDate.Value).ToList();

            }
            else
            {
                listado = PersonaBLL.GetLis(p => true);

            }

            ConsultaDateGridView.ItemsSource = null;
            ConsultaDateGridView.ItemsSource = listado;
        }
    }
}
