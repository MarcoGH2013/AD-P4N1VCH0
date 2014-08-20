using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Componentes.NivelMedio.Transacciones;
using Componentes.Transaccion;
using Controles;

namespace ClbRoles
{
    public partial class FrmRoles : frmMantenimiento
    {
        private byte rolIdCodigo;
        private string[] moduloNombre;
        private bool editarModulo;
        private bool cargarFormularios;
        public decimal Codigo;
        public FrmRoles()
        {
            InitializeComponent();
        }
        private void FrmRolModule_Load(object sender, EventArgs e)
        {
            cargarFormularios = true;
            CargarModulos();
            Nuevo();
            //editModule = false;
            cargarFormularios = false;
        }

        protected override void Nuevo()
        {
            base.Nuevo();
            if (cargarFormularios) return;
            LimpiarForm();
            HabilitarForm(true);
        }


        private void CargarModulos()
        {
            string modNombre;
            int j = 0;
            int I;
            List<Modulo> modulos = Modulos.ObtenerLista();
            foreach (Modulo modulo in modulos)
            {
                ModuloCategoria moduloCategoria = ModuloCategorias.Obtener((int)modulo.IdModuloCategoria);
                modNombre = moduloCategoria.Nombre;
                I = PosCategoria(modNombre);
                if (I < 0)
                {
                    var tempSiS = new string[j + 1];
                    if (moduloNombre != null)
                        Array.Copy(moduloNombre, tempSiS, Math.Min(moduloNombre.Length, tempSiS.Length));
                    moduloNombre = tempSiS;
                    moduloNombre[j] = modNombre;
                    tvwModulos.Nodes.Add(moduloCategoria.Id.ToString(), modNombre);
                    tvwModulos.Nodes[j].Nodes.Add(modulo.Id.ToString(), modulo.Nombre);
                    j++;
                }
                else
                {
                    tvwModulos.Nodes[I].Nodes.Add(modulo.Id.ToString(), modulo.Nombre);
                }
            }
            LimpiarModulos();
        }

        private void LimpiarModulos()
        {
            for (int c = 0; c <= tvwModulos.Nodes.Count - 1; c++)
            {
                tvwModulos.Nodes[c].SelectedImageIndex = 0;
                tvwModulos.Nodes[c].ExpandAll();
                for (int p = 0; p <= tvwModulos.Nodes[c].Nodes.Count - 1; p++)
                {
                    tvwModulos.Nodes[c].Nodes[p].ImageIndex = 2;
                    tvwModulos.Nodes[c].Nodes[p].SelectedImageIndex = 2;
                    tvwModulos.Nodes[c].Nodes[p].Tag = "";
                }
            }
        }

        private int PosCategoria(string nombre)
        {
            int idx = -1;
            if (moduloNombre != null)
            {
                for (int I = 0; I <= moduloNombre.Length - 1; I++)
                {
                    if (moduloNombre[I] == nombre)
                    {
                        idx = I;
                        break;
                    }
                }
            }
            return idx;
        }

        private void tvwModulos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null && e.Button == MouseButtons.Left)
            {
                TreeNode node = e.Node;
                HabilitarObjecto(node);
            }
        }

        private void HabilitarObjecto(TreeNode nodo)
        {
            if (!chkEstado.Enabled) return;
            if (nodo.ImageIndex == 1)
            {
                nodo.ImageIndex = 2;
                nodo.SelectedImageIndex = 2;
                tvwObjecto.Enabled = false;
            }
            else
            {
                nodo.ImageIndex = 1;
                nodo.SelectedImageIndex = 1;
                tvwObjecto.Enabled = true;
            }
        }

        protected override void Buscar()
        {
            base.Buscar();
            try
            {
                List<Rol> roles = new List<Rol>();
                roles = Roles.ObtenerLista();

                frmConsulta fcon = new frmConsulta();
                fcon.gridControl1.DataSource = Roles.ObtenerLista();
                fcon.ShowDialog();
                var oCliente = new Rol();
                if (fcon.oGenerico != null)
                {
                    oCliente = (Rol)fcon.oGenerico;
                    Codigo = oCliente.Id;
                    rolIdCodigo = byte.Parse(oCliente.Id.ToString());
                    LimpiarForm();
                    CargarDato();
                    this.FormModoParametro = FormModo.Edicion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido una excepción controlada llamada: " +
                                    ex.Message.ToString(CultureInfo.GetCultureInfo("es-EC")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void LimpiarForm()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            chkEstado.Checked = true;
            LimpiarModulos();
            LimpiarObjecto();
            HabilitarForm(false);
            errorProvider1.Clear();
        }

        private void HabilitarForm(bool valor)
        {
            txtDescripcion.ReadOnly = !valor;
            txtNombre.ReadOnly = !valor;
            chkEstado.Enabled = valor;
            tvwModulos.Enabled = valor;
            //tvwObject.Enabled = value; 
        }

        private void LimpiarObjecto()
        {
            editarModulo = false;
            for (int I = 0; I <= tvwObjecto.Nodes.Count - 1; I++)
            {
                tvwObjecto.Nodes[I].Checked = false;
            }
            editarModulo = true;
        }

        private void CargarDato()
        {
            Rol rol = Roles.Obtener(rolIdCodigo);
            txtNombre.Text = rol.Nombre;
            txtDescripcion.Text = rol.Descripcion;
            chkEstado.Checked = (rol.IdEstado == 1);
            LimpiarModulos();
            List<ModulosXRol> rolmodule = ModulosXRols.ObtenerLista(rolIdCodigo);
            foreach (ModulosXRol rolModule in rolmodule)
            {
                AlterarModulo((int)rolModule.IdModulo, rolModule.Parametros);
                AlterarObjecto(rolModule.Parametros);
            }
            //tvwModules.SelectedNode=tvwModules.Nodes[0].Nodes[0];
            editarModulo = true;
            tvwObjecto.Enabled = true;
            tvwModulos.Enabled = true;
        }

        private void AlterarModulo(int moduleId, string parameter)
        {
            for (int I = 0; I <= tvwModulos.Nodes.Count - 1; I++)
            {
                for (int j = 0; j <= tvwModulos.Nodes[I].Nodes.Count - 1; j++)
                {
                    if (tvwModulos.Nodes[I].Nodes[j].Name == moduleId.ToString())
                    {
                        tvwModulos.Nodes[I].Nodes[j].ImageIndex = 1;
                        tvwModulos.Nodes[I].Nodes[j].SelectedImageIndex = 1;
                        tvwModulos.Nodes[I].Nodes[j].Tag = parameter;
                    }
                }
            }
        }

        private void AlterarObjecto(string parametro)
        {
            editarModulo = false;
            for (int I = 0; I <= tvwObjecto.Nodes.Count - 1; I++)
            {
                tvwObjecto.Nodes[I].Checked = parametro.Contains(tvwObjecto.Nodes[I].Tag.ToString());
            }
            editarModulo = true;
        }

        private string SeleccionarOjecto()
        {
            string lineArg = "";
            if (tvwObjecto.Enabled)
            {
                for (int I = 0; I <= tvwObjecto.Nodes.Count - 1; I++)
                {
                    if (tvwObjecto.Nodes[I].Checked)
                        lineArg += tvwObjecto.Nodes[I].Tag + "|";
                }
                if (lineArg.Length > 0)
                    lineArg = lineArg.Substring(0, lineArg.Length - 1);
            }
            return lineArg;
        }

        protected override void Eliminar()
        {
            if (MessageBox.Show("Está seguro de eliminar el rol...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                Rol rol = new Rol();
                rol.Descripcion = "";
                rol.Nombre = "";
                rol.IdEstado = 0;
                rol.Id = rolIdCodigo;
                
                int rtn = Roles.Eliminar((int)rol.Id);
                if (rtn > 0)
                {
                    MessageBox.Show("Eliminación OK....!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Nuevo();
                }
                else
                {
                    MessageBox.Show("La eliminación no fue satisfactoria…!", Application.ProductName, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido una excepción controlada llamada: " +
                                                ex.Message.ToString(CultureInfo.GetCultureInfo("es-EC")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        protected override void Guardar()
        {
            bool bValidName = ValidarNombre();
            string Name = "";
            string description = "";
            Int32 Status;

            if (!bValidName)
            {
                MessageBox.Show("Por favor ingrese el nombre del rol...!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return;
            }

            bValidName = NombreRepetido();
            if (bValidName)
            {
                MessageBox.Show("El nombre del rol ya se encuentra ingresado...!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return;
            }

            if (MessageBox.Show("Está seguro de grabar el rol...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            Name = txtNombre.Text.Trim();
            description = txtDescripcion.Text.Trim();
            Status = (chkEstado.Checked ? 1 : 0);

            Rol rol = new Rol();
            rol.Descripcion = description;
            rol.Nombre = Name;
            rol.IdEstado = (byte)Status;
            
            rol.Id = rolIdCodigo;
            ModulosXRol rolModule = new ModulosXRol();

            if (FormModoParametro == FormModo.Nuevo)
            {
                int rolId = Roles.Crear(rol);
                for (int I = 0; I <= tvwModulos.Nodes.Count - 1; I++)
                {
                    for (int j = 0; j <= tvwModulos.Nodes[I].Nodes.Count - 1; j++)
                    {
                        if (tvwModulos.Nodes[I].Nodes[j].ImageIndex == 2) continue;
                        rolModule.IdRol = short.Parse(rolId.ToString());
                        rolModule.IdModulo = Int16.Parse(tvwModulos.Nodes[I].Nodes[j].Name);
                        rolModule.Parametros = tvwModulos.Nodes[I].Nodes[j].Tag.ToString();
                        ModulosXRols.Crear(rolModule);
                    }
                }
                MessageBox.Show("Grabado OK....!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information); MessageBox.Show("Grabado OK....!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Nuevo();
            }
            else
            {
                Roles.Actualizar(rol);
                Roles.Eliminar(rolIdCodigo);

                for (int I = 0; I <= tvwModulos.Nodes.Count - 1; I++)
                {
                    for (int j = 0; j <= tvwModulos.Nodes[I].Nodes.Count - 1; j++)
                    {
                        if (tvwModulos.Nodes[I].Nodes[j].ImageIndex == 2) continue;
                        rolModule.IdRol = short.Parse(rolIdCodigo.ToString());
                        rolModule.IdModulo = Int16.Parse(tvwModulos.Nodes[I].Nodes[j].Name);
                        rolModule.Parametros = tvwModulos.Nodes[I].Nodes[j].Tag.ToString();
                        ModulosXRols.Crear(rolModule);
                    }
                }
                MessageBox.Show("Actualización OK....!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Nuevo();
            }
        }

        protected override void Deshacer()
        {
            rolIdCodigo = 0;
            LimpiarForm();
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            ValidarNombre();
        }

        private bool ValidarNombre()
        {
            bool bStatus = true;
            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "Por favor ingrese el nombre del rol...!");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtNombre, "");
            return bStatus;
        }

        private bool NombreRepetido()
        {
            bool rtn = false;
            List<Rol> roles = Roles.ObtenerLista();
            foreach (Rol rol in roles)
            {
                if ((rol.Nombre == txtNombre.Text && FormModoParametro == FormModo.Nuevo) || (rol.Nombre == txtNombre.Text && rol.Id != rolIdCodigo && FormModoParametro == FormModo.Edicion))
                {
                    rtn = true;
                    break;
                }
            }
            return rtn;
        }


        private void tvwObject_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!chkEstado.Enabled && editarModulo)
                e.Cancel = true;

        }

        private void tvwModules_Enter(object sender, EventArgs e)
        {
            tlblMensaje.Text = "Doble click para dar acceso al modulo..!";
        }

        private void tvwModules_Leave(object sender, EventArgs e)
        {
            tlblMensaje.Text = "";
        }

        private void tvwModules_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (cargarFormularios) return;
            try
            {
                if (e.Node.Parent != null)
                {
                    TreeNode node = e.Node;
                    tvwObjecto.Enabled = (node.ImageIndex != 2);
                    if (node.Tag != null)
                    {
                        LimpiarObjecto();
                        if (node.Tag.ToString().Length > 0)
                            AlterarObjecto(node.Tag.ToString());
                    }
                }
                else
                {
                    LimpiarObjecto();
                    tvwObjecto.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido una excepción controlada llamada: " +
                                ex.Message.ToString(CultureInfo.GetCultureInfo("es-EC")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tvwObject_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (tvwModulos.SelectedNode != null && editarModulo)
            {
                if (tvwModulos.SelectedNode.ImageIndex == 1)
                    tvwModulos.SelectedNode.Tag = SeleccionarOjecto();
            }
        }
    }
}
