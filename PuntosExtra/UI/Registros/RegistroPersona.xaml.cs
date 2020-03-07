using PuntosExtra.BLL;
using PuntosExtra.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PuntosExtra.UI.Registros
{
    /// <summary>
    /// Interaction logic for RegistroPersona.xaml
    /// </summary>
    public partial class RegistroPersona : Window
    {
        public RegistroPersona()
        {
            InitializeComponent();
            PersonaIdTex.Text = "0";
        }
        public void Limpiar()
        {
            PersonaIdTex.Text = string.Empty;         
            NombreTex.Text = string.Empty;
            PersonaIdTex.Text = "0";
        }

        private Personas LlenaClase()
        {
            Personas personas = new Personas();
            personas.PersonaId = Convert.ToInt32(PersonaIdTex.Text);
            personas.Nombre = NombreTex.Text;
            return personas;
        }
        private void LlenaCampo(Personas personas)
        {
            PersonaIdTex.Text = Convert.ToString(personas.PersonaId);           
            NombreTex.Text = personas.Nombre;
            
        }
        private void NuevoButtton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Personas prestamo = PersonaBLL.Buscar(Convert.ToInt32(PersonaIdTex.Text));
            return (prestamo != null);
        }

        private bool Validar()
        {
            bool paso = true;
            if (NombreTex.Text == "")
            {
                MessageBox.Show("El nombre no puede estar Vacio");
                NombreTex.Focus();
                paso = false;
            }           
            return paso;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas personas;
            bool paso = false;
            if (!Validar())
                return;
            personas = LlenaClase();

            if (Convert.ToInt32(PersonaIdTex.Text) == 0)
                paso = PersonaBLL.Guardar(personas);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificaruna persona queno existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                paso = PersonaBLL.Modificar(personas);
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue poasible Guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(PersonaIdTex.Text, out id);

            Limpiar();
            if (PersonaBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas personas = new Personas();
            int.TryParse(PersonaIdTex.Text, out id);

            Limpiar();
            personas = PersonaBLL.Buscar(id);
            if (personas != null)
            {
                LlenaCampo(personas);
            }
            else
            {
                MessageBox.Show("Persona No Encontrada...");
            }
        }
    }
}
