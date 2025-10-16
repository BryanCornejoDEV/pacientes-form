using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Desafio01.Arbol;

namespace Desafio01
{
    public partial class ListadoPacientes : Form
    {

        private FormMenu formMenu;
        public ListadoPacientes(FormMenu menu)
        {
            InitializeComponent();
            this.formMenu = menu;  // Guardamos la referencia del FormMenu original
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string genero = cmbGenero.SelectedItem?.ToString();
            string tipoSangre = cmbSangre.SelectedItem?.ToString();
            string presion = cmbPresion.SelectedItem?.ToString();

            // Si ningún filtro ha sido seleccionado, mostramos un mensaje
            if (string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(tipoSangre) && string.IsNullOrEmpty(presion))
            {
                MessageBox.Show("Por favor, selecciona al menos un filtro.");
                return;
            }

            // Obtener pacientes con los filtros seleccionados (pueden ser uno, dos o tres)
            List<string> pacientes = GestorPacientes.Arbol.ObtenerPacientes(genero, tipoSangre, presion);

            lstPacientes.Items.Clear();

            if (pacientes.Count > 0)
            {
                lstPacientes.Items.AddRange(pacientes.ToArray());
            }
            else
            {
                MessageBox.Show("No se encontraron pacientes con los criterios seleccionados.");
            }
        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            VistaDatosArbol vistaDatosArbol = new VistaDatosArbol(formMenu);
            vistaDatosArbol.Show();
            this.Hide();
        }

        private void ListadoPacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMenu.Show();
        }

        private void btnCaracteristicas_Click(object sender, EventArgs e)
        {
            string genero = cmbGenero.SelectedItem?.ToString();
            string tipoSangre = cmbSangre.SelectedItem?.ToString();
            string presion = cmbPresion.SelectedItem?.ToString();
            string caracteristicas = genero + " - " + tipoSangre + " - " + presion;
            bool ninguncaso = false;
            string mensaje = "";
            switch (caracteristicas)
            {
                case "Hombre - O - Media":
                    mensaje = $"El paciente con género {genero}, tipo de sangre {tipoSangre} y presión {presion} se encuentra estable de salud.";
                    break;
                default:
                    ninguncaso = true;
                    MessageBox.Show("Por favor, seleccione todas las características.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

            }
            if (!ninguncaso)
            {
                MessageBox.Show(mensaje, "Estado del Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
