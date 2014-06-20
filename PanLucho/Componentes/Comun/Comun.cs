using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Componentes.Comun
{
    public class Comun
    {
        private static string titulo = "Error de Entrada";
        public static string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public static bool EsCorreoValido(TextBox cajaTexto)
        {
            const string patron = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                  + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                  + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var expresion = new Regex(patron, RegexOptions.IgnoreCase);
            if (expresion.IsMatch(cajaTexto.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show(cajaTexto.Tag + " debe de ser una dirección de correo válida.", Titulo);
                cajaTexto.Focus();
                return false;
            }
        }

        public static void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsLetter(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = false;
        }


    }
}
