using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionSeguridad.Formularios
{
    public partial class FormBase : Form
    {
        public long? EntidadId { get; set; }

        public FormBase()
        {
            InitializeComponent();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Metodo para Limpiar el contenido los controles
        /// </summary>
        /// <param name="obj">Objeto contenedor</param>
        public virtual void LimpiarDatos(object obj)
        {
            if (obj is Form)
            {
                foreach (var item in ((Form)obj).Controls)
                {
                    if (item is TextBox)
                    {
                        ((TextBox)item).Clear();
                    }

                    if (item is RichTextBox)
                    {
                        ((RichTextBox)item).Clear();
                    }

                    if (item is ComboBox)
                    {
                        if (((ComboBox)item).Items.Count > 0)
                        {
                            ((ComboBox)item).SelectedIndex = 0;
                        }
                    }

                    if (item is CheckBox)
                    {
                        ((CheckBox)item).Checked = false;
                    }

                    if (item is PictureBox)
                    {
                       // ((PictureBox)item).Image = Constante.ImagenControl.ImagenFondo;
                    }

                    if (item is Panel)
                    {
                        LimpiarDatos(item);
                    }

                    if (item is Control)
                    {
                        LimpiarDatos(item);
                    }
                }
            }
            else if (obj is Panel)
            {
                foreach (var item in ((Panel)obj).Controls)
                {
                    if (item is TextBox)
                    {
                        ((TextBox)item).Clear();
                    }

                    if (item is RichTextBox)
                    {
                        ((RichTextBox)item).Clear();
                    }

                    if (item is ComboBox)
                    {
                        if (((ComboBox)item).Items.Count > 0)
                        {
                            ((ComboBox)item).SelectedIndex = 0;
                        }
                    }

                    if (item is CheckBox)
                    {
                        ((CheckBox)item).Checked = false;
                    }

                    if (item is PictureBox)
                    {
                       // ((PictureBox)item).Image = Constante.ImagenControl.ImagenFondo;
                    }

                    if (item is Panel)
                    {
                        LimpiarDatos(item);
                    }

                    if (item is Control)
                    {
                        LimpiarDatos(item);
                    }
                }
            }
            else if (obj is Control)
            {
                foreach (var item in ((Control)obj).Controls)
                {
                    if (item is TextBox)
                    {
                        ((TextBox)item).Clear();
                    }

                    if (item is RichTextBox)
                    {
                        ((RichTextBox)item).Clear();
                    }

                    if (item is ComboBox)
                    {
                        if (((ComboBox)item).Items.Count > 0)
                        {
                            ((ComboBox)item).SelectedIndex = 0;
                        }
                    }

                    if (item is CheckBox)
                    {
                        ((CheckBox)item).Checked = false;
                    }

                    if (item is PictureBox)
                    {
                      //  ((PictureBox)item).Image = Constante.ImagenControl.ImagenFondo;
                    }

                    if (item is Panel)
                    {
                        LimpiarDatos(item);
                    }

                    if (item is Control)
                    {
                        LimpiarDatos(item);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo para Activar o Desactivar los controles
        /// </summary>
        /// <param name="obj">objeto contenedor</param>
        /// <param name="estado">Estado del Control: True o False</param>
        public void ActivarControles(object obj, bool estado)
        {
            if (obj is Form)
            {
                foreach (var item in ((Form)obj).Controls)
                {
                    if (item is Button)
                    {
                        ((Button)item).Enabled = estado;
                    }

                    if (item is DateTimePicker)
                    {
                        ((DateTimePicker)item).Enabled = estado;
                    }

                    if (item is TextBox)
                    {
                        ((TextBox)item).Enabled = estado;
                    }

                    if (item is RichTextBox)
                    {
                        ((RichTextBox)item).Enabled = estado;
                    }

                    if (item is ComboBox)
                    {
                        ((ComboBox)item).Enabled = estado;
                    }

                    if (item is CheckBox)
                    {
                        ((CheckBox)item).Enabled = estado;
                    }

                    if (item is Panel)
                    {
                        ActivarControles(item, estado);
                    }

                    if (item is Control)
                    {
                        ActivarControles(item, estado);
                    }
                }
            }
            else if (obj is Panel)
            {
                foreach (var item in ((Panel)obj).Controls)
                {
                    if (item is DateTimePicker)
                    {
                        ((DateTimePicker)item).Enabled = estado;
                    }

                    if (item is Button)
                    {
                        ((Button)item).Enabled = estado;
                    }

                    if (item is TextBox)
                    {
                        ((TextBox)item).Enabled = estado;
                    }

                    if (item is RichTextBox)
                    {
                        ((RichTextBox)item).Enabled = estado;
                    }

                    if (item is ComboBox)
                    {
                        ((ComboBox)item).Enabled = estado;
                    }

                    if (item is CheckBox)
                    {
                        ((CheckBox)item).Enabled = estado;
                    }

                    if (item is Panel)
                    {
                        ActivarControles(item, estado);
                    }

                    if (item is Control)
                    {
                        ActivarControles(item, estado);
                    }
                }
            }
            else if (obj is Control)
            {
                foreach (var item in ((Control)obj).Controls)
                {
                    if (item is DateTimePicker)
                    {
                        ((DateTimePicker)item).Enabled = estado;
                    }

                    if (item is Button)
                    {
                        ((Button)item).Enabled = estado;
                    }

                    if (item is TextBox)
                    {
                        ((TextBox)item).Enabled = estado;
                    }

                    if (item is RichTextBox)
                    {
                        ((RichTextBox)item).Enabled = estado;
                    }

                    if (item is ComboBox)
                    {
                        ((ComboBox)item).Enabled = estado;
                    }

                    if (item is CheckBox)
                    {
                        ((CheckBox)item).Enabled = estado;
                    }

                    if (item is Panel)
                    {
                        ActivarControles(item, estado);
                    }

                    if (item is Control)
                    {
                        ActivarControles(item, estado);
                    }
                }
            }
        }

        public void txt_Leave(object sender, EventArgs e)
        {
            //((TextBox)sender).BackColor = Constante.ColorControl.ColorSinFoco;
        }

        public void txt_Enter(object sender, EventArgs e)
        {
           // ((TextBox)sender).BackColor = Constante.ColorControl.ColorConFoco;
        }

        public void PoblarComboBox(ComboBox cmb, object obj, string display, string valorDevuelto)
        {
            cmb.DataSource = obj;
            cmb.DisplayMember = display;
            cmb.ValueMember = valorDevuelto;
        }
    }
}
