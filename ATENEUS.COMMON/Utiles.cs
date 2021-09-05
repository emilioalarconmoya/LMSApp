﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.VisualBasic;

namespace ATENEUS.COMMON
{
    public class Utiles
    {
        public static DateTime MAXDATETIME = DateTime.MaxValue.Date;
        public static DateTime MINDATETIME = DateTime.Parse("01/01/1900 00:00:00.000");
        private static Regex _isNumber = new Regex(@"^\d+$");
        public Utiles()
        {
        }
        #region "Conversiones"
        public static string digito_verificador(long rut)
        {
            long Digito;
            long Contador;
            long Multiplo;
            long Acumulador;
            string RutDigito;

            Contador = 2;
            Acumulador = 0;

            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador = Contador + 1;
                if (Contador == 8)
                {
                    Contador = 2;
                }

            }

            Digito = 11 - (Acumulador % 11);
            RutDigito = Digito.ToString().Trim();
            if (Digito == 10)
            {
                RutDigito = "K";
            }
            if (Digito == 11)
            {
                RutDigito = "0";
            }
            return (RutDigito);
        }
        public static DateTime FechaMinSistema()
        {
            return Convert.ToDateTime("01/01/1900");
        }
        public static string RutLngAUsr(long lngRutEmpl)
        {
            if (lngRutEmpl == 0)
            {
                return "";
            }
            long lngRutEmplLoc;
            string strTemp;
            string strDigVerif;
            int i, j;
            string strSalida;
            int intLargo;

            lngRutEmplLoc = lngRutEmpl;
            strDigVerif = digito_verificador(lngRutEmplLoc);

            strTemp = Utiles.ConvertToString(lngRutEmplLoc);
            //intLargo = Len(Trim(strTemp))
            intLargo = strTemp.ToString().Trim().Length;

            strSalida = "";
            j = 0;

            for (i = intLargo; i >= 1; i--)
            {
                if (j > 0 & j % 3 == 0)
                {
                    strSalida = "." + strSalida;
                }
                strSalida = strTemp.Substring(i - 1, 1) + strSalida;
                j = j + 1;
            }

            strSalida = strSalida.Trim() + "-" + strDigVerif.Trim();
            //strSalida = strTemp.Trim() + "-" + strDigVerif.Trim();

            return (strSalida);
        }
        public static bool ValidaRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expresion.IsMatch(rut))
            {
                return false;
            }
            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }
            return true;
        }
        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else {
                return suma.ToString();
            }
        }
        public static long RutUsrALng(string strRut)
        {

            if (strRut == null || string.IsNullOrEmpty(strRut))
            {
                return (0);
            }

            string strRutLoc, strTemp;
            int i, intLargo;
            long lngSalida;



            strRutLoc = strRut;

            intLargo = strRutLoc.Length;
            strTemp = "";

            for (i = 0; i <= intLargo - 1; i++)
            {

                if ((strRutLoc.Substring(i, 1) != "") && (strRutLoc.Substring(i, 1) != ".") && (strRutLoc.Substring(i, 1) != "-"))
                {
                    strTemp = strTemp + strRutLoc.Substring(i, 1);
                }
            }
            /* 17030443-8*/

            intLargo = strTemp.Trim().Length;
            strTemp = strTemp.Substring(0, intLargo - 1);

            bool canConvert = long.TryParse(strTemp, out lngSalida);
            if (!canConvert)
                return 0;
            return lngSalida;
        }
        public static int GetNumericMonth(string strMonth)
        {
            switch (strMonth.ToUpper())
            {
                case "ENERO":
                    return 1;
                case "FEBRERO":
                    return 2;
                case "MARZO":
                    return 3;
                case "ABRIL":
                    return 4;
                case "MAYO":
                    return 5;
                case "JUNIO":
                    return 6;
                case "JULIO":
                    return 7;
                case "AGOSTO":
                    return 8;
                case "SEPTIEMBRE":
                    return 9;
                case "OCTUBRE":
                    return 10;
                case "NOVIEMBRE":
                    return 11;
                case "DICIEMBRE":
                    return 12;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Transforma un objeto a Boolean
        /// </summary>
        /// <param name="objValue">El objeto</param>
        /// <returns>El valor de tipo <seealso cref="System.Boolean">Boolean</seealso></returns>
        public static bool ConvertToBoolean(object objValue)
        {
            try
            {
                if ((objValue != System.DBNull.Value) && (objValue != null))
                    return (Boolean)objValue;
                else
                    return false;
            }
            catch (SystemException ex)
            {
                //ErrorLogFactory.Instance.GetLog();
                //throw ExceptionFactory.Instance;
            }
            return false;
        }
        /// <summary>
        /// Converts a string in a boolean value
        /// </summary>
        /// <param name="strBit">A string representation of a boolean</param>
        /// <returns>A <seealso cref="System.Boolean">Boolean</seealso> value</returns>
        public static Boolean ConvertToBoolean(string strBit)
        {
            try
            {
                if (strBit != null)
                    if ((strBit == "1") || (strBit.ToLower() == "true"))
                    {
                        return true;
                    }
                    else if ((strBit == "0") || (strBit.ToLower() == "false"))
                    {
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                //return Boolean.Parse(strBit);
                else
                    return false;
            }
            catch (ArgumentNullException ex)
            {
                //Todo a exception logging
                ex.Message.ToString();
            }
            catch (FormatException ex)
            {
                //Todo a exception logging
                ex.Message.ToString();
            }

            return false;
        }
        /// <summary>
        /// Transforma un objeto a Double
        /// </summary>
        /// <param name="objValue">El objeto</param>
        /// <returns>El valor de tipo <seealso cref="Double">Double</seealso></returns>
        public static double ConvertToDouble(object objValue)
        {
            try
            {
                if ((objValue != System.DBNull.Value) && (objValue != null))
                    return Convert.ToDouble(objValue.ToString());
                else
                    return 0.0; // double.MinValue;
            }
            catch (SystemException ex)
            {

            }
            return double.MinValue;
        }
        /// <summary>
        /// Transforma un objeto a Int16
        /// </summary>
        /// <param name="objValue">El objeto</param>
        /// <returns>El valor de tipo <seealso cref="System.Int16">int</seealso></returns>
        public static Int16 ConvertToInt16(object objValue)
        {
            try
            {
                if ((objValue != System.DBNull.Value) && (objValue != null))
                    return Convert.ToInt16(objValue.ToString());
                else
                    return 0; // Int16.MinValue;
            }
            catch (SystemException ex)
            {
                return 0; // Int16.MinValue;
            }
        }
        /// <summary>
        /// Transforma un objeto a Int32
        /// </summary>
        /// <param name="objValue">El objeto</param>
        /// <returns>El valor de tipo <seealso cref="System.Int32">int</seealso></returns>
        public static Int32 ConvertToInt32(object objValue)
        {
            try
            {
                if ((objValue != System.DBNull.Value) && (objValue != null))
                    return Convert.ToInt32(objValue.ToString());
                else
                    return 0; // Int32.MinValue;
            }
            catch (SystemException ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// Transforma un objeto a Int64
        /// </summary>
        /// <param name="objValue">El objeto</param>
        /// <returns>El valor de tipo <seealso cref="System.Int64">int</seealso></returns>
        public static Int64 ConvertToInt64(object objValue)
        {
            try
            {
                if ((objValue != System.DBNull.Value) && (objValue != null))
                    return Convert.ToInt64(objValue.ToString());
                else
                    return 0; // Int64.MinValue;
            }
            catch (SystemException ex)
            {
                return 0; // Int16.MinValue;
            }
        }
        /// <summary>
        /// Transforma un objeto a Int32
        /// </summary>
        /// <param name="objValue">El objeto</param>
        /// <returns>El valor de tipo <seealso cref="System.Int32">int</seealso></returns>
        public static DateTime ConvertToDateTime(object objValue)
        {
            try
            {
                if ((objValue != System.DBNull.Value) && (objValue != null))
                    return Convert.ToDateTime(objValue);
                else
                    return DateTime.MaxValue;
            }
            catch (SystemException ex)
            {

            }
            return DateTime.MaxValue;
        }
        /// <summary>
        /// Transforma un objeto a Int32
        /// </summary>
        /// <param name="objValue">El objeto</param>
        /// <returns>El valor de tipo <seealso cref="System.Int32">int</seealso></returns>
        public static Decimal ConvertToDecimal(object objValue)
        {
            try
            {
                if ((objValue != System.DBNull.Value) && (objValue != null))
                    return Convert.ToDecimal(objValue);
                else
                    return 0; // Decimal.MinValue;
            }
            catch (SystemException ex)
            {

            }
            return Decimal.MinValue;
        }
        /// <summary>
        /// Transforma un objeto a Int32
        /// </summary>
        /// <param name="objValue">El objeto</param>
        /// <returns>El valor de tipo <seealso cref="System.Int32">int</seealso></returns>
        public static string ConvertToString(object objValue)
        {
            try
            {
                if ((objValue != System.DBNull.Value) && (objValue != null))
                    return Convert.ToString(objValue);
                else
                    return "";
            }
            catch (SystemException ex)
            {

            }
            return "";
        }
        #endregion
        #region "Validaciones"
        public static bool ValidarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }
        public static bool ValidarMail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Verifica si un string representa un numero entero
        /// </summary>
        /// <param name="theValue">El string a comparar</param>
        /// <returns>Verdadero si es un numero entero</returns>
        public static bool IsValidInteger(string theValue)
        {
            Match m = _isNumber.Match(theValue);
            return m.Success;
        }
        public static string GetValidString(string str)
        {
            if (str == null)
                return string.Empty;
            return str.Trim();
        }
        public static bool IsValidDateTime(DateTime dttValue)
        {
            return (dttValue < MAXDATETIME && dttValue >= MINDATETIME);
        }
        /// <summary>
        /// Valida valor del decimal si es menor o igual que 0 retorna DBNull
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object CheckDBDecimal(decimal valor)
        {
            if (valor <= 0)
                return System.DBNull.Value;
            else
                return valor;
        }
        /// <summary>
        /// Valida valor del entero, si es menor que 0 retorna DBNull
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object CheckDBDecimalWithZero(decimal valor)
        {
            if (valor < 0)
                return System.DBNull.Value;
            else
                return valor;
        }
        /// <summary>
        /// Valida valor del entero, si es menor o igual que 0 retorna DBNull
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object CheckDBByte(byte valor)
        {
            if (valor <= 0)
                return System.DBNull.Value;
            else
                return valor;
        }
        public static object CheckDBBoolean(bool? valor)
        {
            if (valor.HasValue)
                return valor.Value;
            return System.DBNull.Value;
        }
        /// <summary>
        /// Valida valor del entero, si es menor o igual que 0 retorna DBNull
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object CheckDBInt(int valor)
        {
            if (valor <= 0)
                return System.DBNull.Value;
            else
                return valor;
        }
        /// <summary>
        /// Valida valor del short, si es menor o igual que 0 retorna DBNull
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object CheckDBShort(short valor)
        {
            if (valor <= 0)
                return System.DBNull.Value;
            else
                return valor;
        }
        /// <summary>
        /// Valida el formato de valor dateTime informado, se superior a data atual retorna DBNull
        /// </summary>
        /// <param name="dtt"></param>
        /// <returns></returns>
        public static object CheckDBDateTime(DateTime dtt)
        {
            if (!IsValidDateTime(dtt))
                return System.DBNull.Value;
            else
                return dtt;
        }
        /// <summary>
        /// Valida valor del entero, si es menor que 0 retorna DBNull
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object CheckDBIntWithZero(int valor)
        {
            if (valor < 0)
                return System.DBNull.Value;
            else
                return valor;
        }
        /// <summary>
        /// Valida valor del long, se 0 retorna DBNull
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object CheckDBLong(long valor)
        {
            if (valor <= 0)
                return System.DBNull.Value;
            else
                return valor;
        }
        /// <summary>
        /// Valida valor del DOUBLE, se 0 retorna DBNull
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object CheckDBDouble(double valor)
        {
            if (valor <= 0)
                return System.DBNull.Value;
            else
                return valor;
        }
        /// <summary>
        /// Valida el valor de una string, se tamano fue 0 entonces retorna DBNull
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static object CheckDBStr(string valor)
        {
            string str = GetValidString(valor);
            if (str.Length == 0)
                return System.DBNull.Value;
            else
                return str;
        }
        #endregion
        #region "Seleccion"
        /// <summary>
        /// Obtiene un item para combo con el mensaje ingresado
        /// </summary>
        /// <returns></returns>
        public static Item GetSelectionItem(string texto)
        {
            return new Item(texto, "0");
        }
        /// <summary>
        /// Obtiene un item para combo con el mensaje de selección
        /// </summary>
        /// <returns></returns>
        public static Item GetSelectionItem()
        {
            return new Item(Utiles.GetSelectionText(), "0");
        }
        /// <summary>
        /// Obtiene el texto de selección según el idioma del usuario
        /// de sistema
        /// </summary>
        /// <returns>Un string con el texto</returns>
        public static string GetSelectionText()
        {
            return "Seleccione";
        }
        /// <summary>
        /// Obtiene un string no nulo y sin espacios colindantes a partir de un string
        /// </summary>
        /// <param name="str">el string a revisar</param>
        /// <returns>un <seealso cref="System.">string</seealso> no nulo</returns>
        #endregion
        #region "BD"
        public static string SubStringSQL(string str)
        {
            return "%" + str + "%";
        }
        #endregion
        #region "Funciones comunes"
        // se cambia a función boolean para que arroge si hubo error o no al descomprimir
        public static void Descomprimir(string Archivo, string Destino)
        {
                FastZip fzip = new FastZip();
                fzip.ExtractZip(Archivo, Destino, "");
                fzip = null;
           
        }
		public static Boolean Comprimir(string Archivo, string RutaCarpeta)
        {
            try
            {
                FastZip fzip = new FastZip();
                fzip.CreateZip(RutaCarpeta + ".zip", RutaCarpeta, true, "");
                fzip = null;
                return true;
            }
            catch (ZipException ex)
            {
                return false;
            }

        }
        public static DataTable ListaArchivos(string Path)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Archivo");
            if (System.IO.Directory.Exists(Path))
            {
                string[] arr = System.IO.Directory.GetFiles(Path);
                for (int i = 0; i <= arr.Length - 1; i++)
                {
                    string[] stringSeparators = new string[] { "\\" };
                    string archivo = arr[i];
                    string[] arr2 = archivo.Split(stringSeparators, StringSplitOptions.None);
                    DataRow dr;
                    dr = dt.NewRow();
                    dr["Archivo"] = arr2[arr2.Length - 1];
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        public static int[] Aleatorio(Int16 TotalPreguntas, Int16 CantAMostrar)
        {
            int[] numeros = new int[CantAMostrar];
            Random r = new Random();
            int auxiliar = 0;
            int contador = 0;
            for (int i = 0; i < CantAMostrar-1; i++)
            {
                auxiliar = r.Next(1, TotalPreguntas);
                bool continuar = false;
                while (!continuar)
                {
                    for (int j = 0; j <= contador; j++)
                    {
                        if (auxiliar == numeros[j])
                        {
                            continuar = true; // true;
                            j = contador;
                            break;
                        }
                    }

                    if (continuar)
                    {
                        auxiliar = r.Next(1, TotalPreguntas);
                        continuar = false;
                    }
                    else
                    {
                        continuar = true;
                        numeros[contador] = auxiliar;
                        contador++;
                    }
                }
            }
            return numeros;
        }
        public static Double CalculaNota(Double NotaMin, Double NotaMax, Double NotaAprob, Double Exig, int PtjeTotal, int PtjeObtenido)
        {
            double Nota = 0.0;

            double PtjeExigido = PtjeTotal * (Exig / 100);

            if (PtjeObtenido < PtjeExigido)
            {
                Nota = ((NotaAprob - NotaMin) * (PtjeObtenido / ((Exig / 100) * PtjeTotal))) + NotaMin;
            }
            else
            {
                Nota = (NotaMax - NotaAprob) * ((PtjeObtenido - ((Exig / 100) * PtjeTotal)) / (PtjeTotal * (1 - (Exig / 100)))) + NotaAprob;
            }
            if (Double.IsNaN(Nota))
                Nota = 0;

                return Nota;
        }
        public static Double CalculaAsistencia(Int16 TotalUnidades, Int16 UnidadesTerminadas)
        {
            double Asistencia = 0.0;

            Asistencia = (UnidadesTerminadas * 100) / TotalUnidades;

            return Asistencia;
        }


        #endregion
    }
}
