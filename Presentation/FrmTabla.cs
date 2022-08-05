using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudWdwsForms.Models;

namespace CrudWdwsForms.Presentation
{
    public partial class FrmTabla : Form
    {
        Tbl_Crud oTabla = null;
        public int? id;
        
        public FrmTabla(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            using (CrudEntities db = new CrudEntities())
            {
                oTabla = db.Tbl_Crud.Find(id);
                txtNombre.Text = oTabla.nombre;
                txtCorreo.Text = oTabla.correo;
                dtFechaNacimiento.Value = Convert.ToDateTime(oTabla.fecha_nacimiento);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CrudEntities db = new CrudEntities())
            {

                if (id == null)
                    oTabla = new Tbl_Crud();

                oTabla.nombre = txtNombre.Text;
                oTabla.correo = txtCorreo.Text;
                oTabla.fecha_nacimiento = dtFechaNacimiento.Text;


                if (id == null)
                     db.Tbl_Crud.Add(oTabla);
                else
                {
                    db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();

                this.Close();
            }
        }

        private void FrmTabla_Load(object sender, EventArgs e)
        {

        }
    }
}
