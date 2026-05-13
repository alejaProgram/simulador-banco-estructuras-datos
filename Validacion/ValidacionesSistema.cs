using System;
using System.Globalization;

namespace Validacion
{
    public enum ResultadoEncolarCliente
    {
        Exito,
        ClienteNoExiste,
        YaEstaEnCola
    }

    public static class ValidacionesSistema
    {
        public const int MinDigitosCedula = 6;
        public const int MaxDigitosCedula = 10;
        public const int DigitosNumeroCuenta = 10;
        public const int MaxCaracteresNombre = 50;

        public const decimal SaldoMaximoPermitido = 999_999_999.99m;

        public const decimal SaldoInicialMinimoCopsSiNoEsCero = 1000m;

        private static readonly Lazy<CultureInfo> CulturaColombiana = new(() => CultureInfo.GetCultureInfo("es-CO"));

        public static CultureInfo CulturaCOP => CulturaColombiana.Value;

        public static string FormatearMonedaCOP(decimal valor)
        {
            CultureInfo c = CulturaColombiana.Value;
            string numero = valor == decimal.Truncate(valor)
                ? valor.ToString("N0", c)
                : valor.ToString("N2", c);
            return "$ " + numero + " COP";
        }

        private static bool TryParseDecimalMoneda(string texto, out decimal valor)
        {
            return decimal.TryParse(texto, NumberStyles.Number, CulturaCOP, out valor)
                || decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor)
                || decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out valor);
        }

        public const string MsgNombreVacio = "El nombre no puede estar vacío.";
        public const string MsgNombreSoloEspacios = "El nombre no puede estar vacío.";
        public const string MsgNombreDemasiadoLargo = "El nombre no puede superar los 50 caracteres.";
        public const string MsgCedulaVacia = "La cédula no puede estar vacía.";
        public const string MsgCedulaNoNumerica = "La cédula solo puede contener números.";
        public const string MsgCedulaLongitud = "La cédula debe tener entre 6 y 10 dígitos.";
        public const string MsgCedulaDuplicada = "Ya existe un cliente registrado con esa cédula.";
        public const string MsgCuentaVacia = "El número de cuenta no puede estar vacío.";
        public const string MsgCuentaNoNumerica = "El número de cuenta solo puede contener números.";
        public const string MsgCuentaLongitudExacta = "El número de cuenta debe tener exactamente 10 dígitos.";
        public const string MsgCuentaDuplicada = "Ya existe un cliente con ese número de cuenta.";
        public const string MsgSaldoInicialInvalido = "El saldo inicial no es válido. Use solo números (sin letras ni símbolos), mayor o igual a 0 y que no supere el límite permitido.";
        public const string MsgSaldoInicialNegativo = "El saldo inicial no puede ser negativo.";
        public const string MsgSaldoInicialExcesivo = "El saldo inicial supera el límite permitido.";
        public const string MsgClienteNoEncontrado = "Cliente no encontrado.";
        public const string MsgListaClientesVacia = "No hay clientes registrados.";
        public const string MsgColaVaciaAtender = "No hay clientes en espera.";
        public const string MsgColaVaciaMostrar = "La cola está vacía.";
        public const string MsgClienteNoExisteCola = "No se puede agregar un cliente que no existe.";
        public const string MsgClienteYaEnCola = "El cliente ya está en la cola.";
        public const string MsgCuentaNoExiste = "No existe un cliente con ese número de cuenta.";
        public const string MsgMontoInvalido = "Monto inválido. Debe ser un número mayor a 0, sin letras ni símbolos.";
        public const string MsgMontoNegativoOCero = "El monto debe ser mayor a 0.";
        public const string MsgMontoExcesivo = "El monto supera el límite permitido.";
        public const string MsgSaldoInsuficiente = "Saldo insuficiente.";
        public const string MsgSinTransacciones = "No hay transacciones para deshacer.";
        public const string MsgOpcionInvalida = "Opción inválida.";
        public const string MsgErrorInesperado = "Ocurrió un error inesperado. Intente de nuevo.";
        public const string MsgRetiroNoCompletado = "No se pudo completar el retiro.";
        public const string MsgDepositoNoCompletado = "No se pudo completar el depósito.";
        public const string MsgSaldoResultanteExcesivo = "La operación dejaría un saldo por encima del límite permitido.";
        public const string MsgReintentoCuenta = "Ingrese de nuevo el número de cuenta; deben ser exactamente 10 dígitos numéricos.";
        public const string MsgReintentoCedula = "Ingrese de nuevo la cédula; solo números y entre 6 y 10 dígitos.";
        public const string MsgOperacionCancelada = "Operación cancelada.";

        public static bool EsNumeroCuentaValido(string? numeroCuenta, out string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
            {
                mensajeError = MsgCuentaVacia;
                return false;
            }

            string n = numeroCuenta.Trim();
            if (n.Length != DigitosNumeroCuenta)
            {
                mensajeError = MsgCuentaLongitudExacta;
                return false;
            }

            for (int i = 0; i < n.Length; i++)
            {
                char c = n[i];
                if (c < '0' || c > '9')
                {
                    mensajeError = MsgCuentaNoNumerica;
                    return false;
                }
            }

            mensajeError = "";
            return true;
        }

        public static bool EsCedulaValida(string? cedula, out string normalizada, out string mensajeError)
        {
            normalizada = (cedula ?? "").Trim();
            if (string.IsNullOrEmpty(normalizada))
            {
                mensajeError = MsgCedulaVacia;
                return false;
            }

            for (int i = 0; i < normalizada.Length; i++)
            {
                if (normalizada[i] < '0' || normalizada[i] > '9')
                {
                    mensajeError = MsgCedulaNoNumerica;
                    return false;
                }
            }

            if (normalizada.Length < MinDigitosCedula || normalizada.Length > MaxDigitosCedula)
            {
                mensajeError = MsgCedulaLongitud;
                return false;
            }

            mensajeError = "";
            return true;
        }

        public static bool EsNombreValido(string? nombreCompleto, out string normalizado, out string mensajeError)
        {
            normalizado = (nombreCompleto ?? "").Trim();
            if (string.IsNullOrEmpty(normalizado))
            {
                mensajeError = MsgNombreVacio;
                return false;
            }

            if (normalizado.Length > MaxCaracteresNombre)
            {
                mensajeError = MsgNombreDemasiadoLargo;
                return false;
            }

            normalizado = CapitalizarNombre(normalizado);
            mensajeError = "";
            return true;
        }

        public static string CapitalizarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return nombre;

            string t = nombre.Trim().ToLowerInvariant();
            try
            {
                TextInfo ti = CultureInfo.GetCultureInfo("es-CO").TextInfo;
                return ti.ToTitleCase(t);
            }
            catch (CultureNotFoundException)
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(t);
            }
        }

        public static bool EsSaldoInicialValido(string? texto, out decimal saldo, out string mensajeError)
        {
            saldo = 0;
            string s = (texto ?? "").Trim();

            if (string.IsNullOrEmpty(s))
            {
                mensajeError = "";
                return true;
            }

            if (!TryParseDecimalMoneda(s, out saldo))
            {
                mensajeError = MsgSaldoInicialInvalido;
                return false;
            }

            if (saldo < 0)
            {
                mensajeError = MsgSaldoInicialNegativo;
                return false;
            }

            if (saldo > SaldoMaximoPermitido)
            {
                mensajeError = MsgSaldoInicialExcesivo;
                return false;
            }

            if (saldo > 0 && saldo < SaldoInicialMinimoCopsSiNoEsCero)
            {
                mensajeError =
                    $"Indique un saldo inicial en pesos colombianos (COP) de al menos {FormatearMonedaCOP(SaldoInicialMinimoCopsSiNoEsCero)}, " +
                    $"o pulse solo Enter para comenzar con {FormatearMonedaCOP(0)}.";
                return false;
            }

            mensajeError = "";
            return true;
        }

        public static bool EsMontoTransaccionValido(string? textoMonto, out decimal monto, out string mensajeError)
        {
            monto = 0;
            string t = (textoMonto ?? "").Trim();

            if (!TryParseDecimalMoneda(t, out monto))
            {
                mensajeError = MsgMontoInvalido;
                return false;
            }

            if (monto <= 0)
            {
                mensajeError = MsgMontoNegativoOCero;
                return false;
            }

            if (monto > SaldoMaximoPermitido)
            {
                mensajeError = MsgMontoExcesivo;
                return false;
            }

            mensajeError = "";
            return true;
        }

        public static bool HaySaldoSuficiente(decimal saldoActual, decimal montoRetiro, out string mensajeError)
        {
            if (montoRetiro <= 0)
            {
                mensajeError = MsgMontoNegativoOCero;
                return false;
            }

            if (saldoActual < montoRetiro)
            {
                mensajeError = MsgSaldoInsuficiente;
                return false;
            }

            mensajeError = "";
            return true;
        }

        public static bool SaldoResultanteValidoTrasDeposito(decimal saldoActual, decimal monto, out string mensajeError)
        {
            mensajeError = "";
            try
            {
                decimal suma = checked(saldoActual + monto);
                if (suma > SaldoMaximoPermitido)
                {
                    mensajeError = MsgSaldoResultanteExcesivo;
                    return false;
                }
            }
            catch (OverflowException)
            {
                mensajeError = MsgSaldoResultanteExcesivo;
                return false;
            }

            return true;
        }

        public static bool EsConfirmacionSi(string? respuesta)
        {
            string r = (respuesta ?? "").Trim();
            return r.Equals("S", StringComparison.OrdinalIgnoreCase)
                || r.Equals("Y", StringComparison.OrdinalIgnoreCase)
                || r.Equals("SI", StringComparison.OrdinalIgnoreCase)
                || r.Equals("YES", StringComparison.OrdinalIgnoreCase);
        }

        public static bool EsOpcionMenuValida(string? opcion, out int numeroOpcion)
        {
            numeroOpcion = 0;
            if (string.IsNullOrWhiteSpace(opcion))
                return false;

            string o = opcion.Trim();
            if (!int.TryParse(o, NumberStyles.Integer, CultureInfo.InvariantCulture, out int n))
                return false;

            if (n < 1 || n > 13)
                return false;

            numeroOpcion = n;
            return true;
        }
    }
}
