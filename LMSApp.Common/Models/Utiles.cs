using System;
using System.Text;

namespace LMSApp.Common.Models
{
    public class Utiles
    {

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

            strTemp = Convert.ToString(lngRutEmplLoc);
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

        public static string Encriptar(string Texto)
        {
            string obj = "Soleduc";
            int i = 0;
            int j = 0;
            string P1 = "";
            long A1 = 0;
            long A2 = 0;
            long A3 = 0;
            object B;
            string S = "";

            foreach (var c in obj)
            {
                P1 = P1 + (int)c;
            }

            for (i = 0; i < Texto.Length; i++)
            {
                A1 = Encoding.ASCII.GetBytes(P1.Substring(j, 1))[0];
                j++;
                if (j > P1.Length)
                {
                    j = 1;
                }
                A2 = Encoding.ASCII.GetBytes(Texto.Substring(i, 1))[0];
                A3 = A1 ^ A2;
                B = A3;
                if (B.ToString().Length < 2)
                {
                    B = "0" + B;
                }
                S = S + B;
            }


            return S;

        }
    }
}
