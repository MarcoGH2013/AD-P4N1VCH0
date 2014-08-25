using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Componentes.ProveedorData;
using Componentes.Transaccion;

namespace Componentes.NivelMedio.Transacciones
{
    public static class Facturas
    {
        public static bool Guardar(Factura ofactura)
        {
            var call = new SqlProveedorData();
            return call.FacturaGuardar(ofactura);
        }
    }
}
