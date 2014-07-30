//using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
using Componentes.Transaccion;
using Controles;
using Componentes;

namespace ClbUsuarios
{
    public partial class FrmUsuarios : frmMantenimiento
    {

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        protected override void Buscar()
        {
            base.Buscar();
            var fcon = new frmConsulta();

            var lstUsuarios = new List<Usuario>();
            var u = new Usuario();
            //u.Nick = "admin";
            //u.contrasena = "12345";
            //u.rol = "administrador";
            //u.nombre = "Marco";
            //u.apellido = "Castro";
            //u.email = "macastro@espol.edu.ec";
            lstUsuarios.Add(u);

            //fcon.CargarGrid(lstUsuarios);
            fcon.gridControl1.DataSource = lstUsuarios;
            fcon.ShowDialog();

            
            var oUsuario= new Usuario();
            oUsuario=(Usuario)fcon.oGenerico;


        }
    }
}
