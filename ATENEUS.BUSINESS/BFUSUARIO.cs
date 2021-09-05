
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.IO;
using System.Text;
using System.Data;
using System.Data.OleDb;


namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFUSUARIO.
	/// </summary>
	public class BFUSUARIO
	{
		private DLUSUARIO _objDAL;
		private DLUSUARIOList _objDALList;
		
		public BFUSUARIO()
		{
			_objDAL = new DLUSUARIO();
			_objDALList = new DLUSUARIOList();
		}

		public EUSUARIO GetUSUARIO()
		{
			return new EUSUARIO();
		}

        //public EUSUARIO GetUSUARIO(long id)
        //{
        //    return new EUSUARIO(id);
        //}

        public EUSUARIO GetUSUARIO(long id,Int64 CodEmpresa)
        {
            return new EUSUARIO(id,CodEmpresa);
        }
        public bool Save(EUSUARIO objUSUARIO)
		{
			try
			{
				objUSUARIO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EUSUARIO> GetUSUARIOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EUSUARIO objUSUARIO)
		{
			try
			{
                _objDAL.Delete(objUSUARIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EUSUARIO objUSUARIO)
        {
            try
            {
                _objDAL.Update(objUSUARIO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }
        public string CargarUsuarios_old(string strRuta, long lngCodEmpresa)
        {
            string str = "";
            FileStream file = new FileStream(strRuta, FileMode.Open);
            StreamReader reader = new StreamReader(file, Encoding.Default);
            try
            {
                int fila = 0;
                while (!reader.EndOfStream)
                {
                    String[] arrDatos = reader.ReadLine().Replace("'", "").Split(Convert.ToChar(";"));
                    if (fila >= 0)
                    {
                        EUSUARIO objUsuario = new EUSUARIO();
                        objUsuario.RutUsuario = Utiles.ConvertToInt64(arrDatos[0]);
                        objUsuario.Nombres = Utiles.ConvertToString(arrDatos[2]);
                        objUsuario.Apellidos = Utiles.ConvertToString(arrDatos[3]);
                        objUsuario.PasswdEnc = CCryptografia.Encriptar(Utiles.ConvertToString(arrDatos[4]));
                        objUsuario.Email = Utiles.ConvertToString(arrDatos[5]);
                        objUsuario.ClaveSence = Utiles.ConvertToString(arrDatos[6]);
                        objUsuario.Direccion = Utiles.ConvertToString(arrDatos[7]);
                        objUsuario.Comuna = Utiles.ConvertToString(arrDatos[8]);
                        objUsuario.Profesion = Utiles.ConvertToString(arrDatos[9]);
                        objUsuario.FechaCreacion = DateTime.Now;
                        DLUSUARIO dlUsuario = new DLUSUARIO();
                        objUsuario.IsPersisted = dlUsuario.ExisteUsuario(Utiles.ConvertToInt64(arrDatos[0]), lngCodEmpresa);
                        objUsuario.Save();

                        String[] arrCarac = Utiles.ConvertToString(arrDatos[13]).Replace("{", "").Replace("}", "").Split(Convert.ToChar(","));
                        for (int x = 0; x <= arrCarac.Length - 1; x++)
                        {
                            dlUsuario.SetCaracteristicasUsuario(Utiles.ConvertToInt64(arrDatos[0]), arrCarac[x].Split(Convert.ToChar(":"))[0].ToString(), arrCarac[x].Split(Convert.ToChar(":"))[1].ToString(), lngCodEmpresa);
                        }
                    }
                    fila++;
                }
                reader.Close();
                str = "Los datos han sido ingresados exitosamente";
                return str;
            }
            catch (Exception ex)
            {
                reader.Close();
                Log log = new Log();
                log.EscribirLog(ex);
                return "Ha ocurrido un problema, favor revisar el archivo e intentar nuevamente.";
            }
        }

        public string CargarUsuarios(string strRuta, long CodEmpresa)
        {
            string str = "";
            long rutNegativo = 0;
            //string datos = string.Empty;
            FileStream file = new FileStream(strRuta, FileMode.Open);
            StreamReader reader = new StreamReader(file, Encoding.Default);
            try
            {
                int fila = 0;
                while (!reader.EndOfStream)
                {
                    string datos = string.Empty;
                    String[] arrDatos = reader.ReadLine().Replace("'", "").Split(Convert.ToChar(";"));
    
                    if (fila > 0)
                    {
                        if (Utiles.ConvertToString(arrDatos[0]) != "" && Utiles.ConvertToString(arrDatos[2]) != "")
                        {
                            reader.Close();
                            return "Debe Agreagr un RUT o un DNI, no ambos en la fila " + fila;
                        }
                            EUSUARIO objUsuario = new EUSUARIO();
                        if(Utiles.ConvertToString(arrDatos[0]) != "" && Utiles.ConvertToString(arrDatos[1])!="")
                        {
                            objUsuario.RutUsuario = Utiles.ConvertToInt64(arrDatos[0]);
                            if (!Utiles.ValidaRut(Utiles.ConvertToString(arrDatos[0]) + "-" + Utiles.ConvertToString(arrDatos[1])))
                            {
                                reader.Close();
                                return "El Rut " + arrDatos[0].ToString() + " posee un número verificador incorrecto.";
                            }
                        }
                        else
                        {
                           if(Utiles.ConvertToString(arrDatos[2]) != "")
                           {
                                objUsuario.DNI = arrDatos[2].Trim();
                                objUsuario.RutUsuario = UltimoRutNegativo() - 1;
                                rutNegativo = UltimoRutNegativo() - 1;
                            }
                            else
                            {
                                reader.Close();
                                return "No existe RUT o DNI en la fila " + fila;
                            }
                        }
                        

                        DLUSUARIO dlUsuario = new DLUSUARIO();
                        objUsuario.Nombres = Utiles.ConvertToString(arrDatos[3]);
                        objUsuario.Apellidos = Utiles.ConvertToString(arrDatos[4]);
                        if(Convert.ToString(arrDatos[5])== "" || arrDatos[5]==null)
                        {
                            reader.Close();
                            return "El RUT/DNI " + arrDatos[0].ToString() + arrDatos[2].ToString() + " no posee contraseña.";
                        }
                        else
                        {
                            objUsuario.PasswdEnc = CCryptografia.Encriptar(Utiles.ConvertToString(arrDatos[5]));
                        }
                        if (Utiles.ConvertToString(arrDatos[0]) != "" && Utiles.ConvertToString(arrDatos[1]) != "")
                        {
                            //if (!dlUsuario.ExisteEmailUsuario(arrDatos[6].Trim(), Utiles.ConvertToInt64(arrDatos[0])))
                            //{
                            //    objUsuario.Email = Utiles.ConvertToString(arrDatos[6]);
                            //}
                            //else {
                            //    reader.Close();
                            //    return "El email " + arrDatos[6].ToString() + " ya existe para otra persona.";
                            //}
                        }

                        objUsuario.Email = Utiles.ConvertToString(arrDatos[6]);
                        objUsuario.ClaveSence = Utiles.ConvertToString(arrDatos[7]);
                        objUsuario.Direccion = Utiles.ConvertToString(arrDatos[8]);
                        objUsuario.Comuna = Utiles.ConvertToString(arrDatos[9]);
                        objUsuario.Profesion = Utiles.ConvertToString(arrDatos[10]);

                        objUsuario.Fono = Utiles.ConvertToString(arrDatos[11]);
                        objUsuario.FechaCreacion = DateTime.Now;
                        objUsuario.FechaCaducidad = DateTime.Now.AddYears(10);
						objUsuario.CodEmpresa = CodEmpresa;
                        if (Utiles.ConvertToString(arrDatos[0]) != "" && Utiles.ConvertToString(arrDatos[1]) != "")
                        {
                            if (Utiles.ConvertToString(arrDatos[0]) != "" && Utiles.ConvertToString(arrDatos[1]) != "")
                            {
                                objUsuario.IsPersisted = dlUsuario.ExisteUsuario(Utiles.ConvertToInt64(arrDatos[0]), CodEmpresa);
                            }
                        }
                        else
                        {
                            if (Utiles.ConvertToString(objUsuario.RutUsuario) != "")
                            {
                                //objUsuario.IsPersisted = dlUsuario.ExisteUsuarioDni(arrDatos[2].Trim());
                            }
                        }
                            
                           
                        objUsuario.Save();
                        for (int i = 12; i < arrDatos.Length; i++)
                        {
                            datos = datos+arrDatos[i];
                        }                        
                        String[] arrCarac = Utiles.ConvertToString(datos.Replace("{", "").Replace("}", "")).Split(Convert.ToChar(","));
                        if(arrCarac.Length > 20)
                        {
                            if (Utiles.ConvertToString(arrDatos[0]) != "" && Utiles.ConvertToString(arrDatos[1]) != "")
                            {
                                reader.Close();
                                return "El rut " + arrDatos[0].ToString() + "-" + arrDatos[1].ToString() + ", posee más columnas de las solicitadas. Ver formato.";
                            }
                            else
                            {
                                reader.Close();
                                return "El DNI " + arrDatos[2].ToString() + "-" + arrDatos[1].ToString() + ", posee más columnas de las solicitadas. Ver formato.";
                            }
                        }
                        for (int x = 0; x <= arrCarac.Length - 1; x++)
                        {
                            if (Utiles.ConvertToString(arrDatos[0]) != "" && Utiles.ConvertToString(arrDatos[1]) != "")
                            {
                                dlUsuario.SetCaracteristicasUsuario(Utiles.ConvertToInt64(arrDatos[0]), arrCarac[x].Split(Convert.ToChar(":"))[0].ToString(), arrCarac[x].Split(Convert.ToChar(":"))[1].ToString(), CodEmpresa);
                            }
                            else
                            {
                                dlUsuario.SetCaracteristicasUsuario(rutNegativo, arrCarac[x].Split(Convert.ToChar(":"))[0].ToString(), arrCarac[x].Split(Convert.ToChar(":"))[1].ToString(), CodEmpresa);
                            }
                                
                        }
                    }
                    fila++;
                }
                reader.Close();
                str = "Los datos han sido ingresados exitosamente";
                return str;
            }
            catch (Exception ex)
            {
                reader.Close();
                Log log = new Log();
                log.EscribirLog(ex);
                return "Ha ocurrido un problema, favor revisar el archivo e intentar nuevamente.";
            }
        }

        public string VerUsuarios(string strRuta)
        {
            string str = "";
            try
            {
                using (OleDbConnection conn = new OleDbConnection())
                {
                    DataTable dt = new DataTable();
                    string Import_FileName = strRuta;
                    string fileExtension = Path.GetExtension(Import_FileName);
                    if (fileExtension == ".xls")
                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                    if (fileExtension == ".xlsx")
                        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                    using (OleDbCommand comm = new OleDbCommand())
                    {
                        comm.CommandText = "Select * from [hoja1$]";

                        comm.Connection = conn;

                        using (OleDbDataAdapter da = new OleDbDataAdapter())
                        {
                            da.SelectCommand = comm;
                            da.Fill(dt);

                            str = "Número de registros - " + Utiles.ConvertToString(dt.Rows.Count);
                        }

                    }
                }
                return str;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return "Ha ocurrido un problema, favor revisar el archivo e intentar nuevamente.";
            }
        }

        public List<EUSUARIO> GetUsuarioParametros(long Rut, string Nombres, string Apellidos, string Email,Int64 CodEmpresa)
        {
            return _objDALList.SelectUsuarioParametros(Rut, Nombres, Apellidos, Email, CodEmpresa);
        }

        public List<EUSUARIO> GetUsuarioParametrosAtributo(long Rut, string Nombres, string Apellidos, string Email, long ruttutor, Int32 codCarcarteristica, Int32 CodAtributo, Int64 CodEmpresa)
        {
            return _objDALList.SelectUsuarioParametrosAtributo(Rut, Nombres, Apellidos, Email, ruttutor, codCarcarteristica, CodAtributo, CodEmpresa);
        }

        public DataTable GetUsuarioSaldo(long Rut, string Nombres, Int16 CodCaract, Int16 CodAtrib)
        {
            return _objDALList.GetUsuarioSaldo(Rut, Nombres, CodCaract, CodAtrib);
        }

        public DataTable GetUsuarioCargados(long Rut, string Nombres, string Apellido, Int16 CodCaract, Int16 CodAtrib, Int64 CodEmpresa, int codEstado)
        {
            return _objDALList.GetUsuariosCargados(Rut, Nombres, Apellido, CodCaract, CodAtrib, CodEmpresa, codEstado);
        }

        public List<EUSUARIO> GetUsuariosParametros(long Rut, string Nombres, Int16 CodCaract, Int16 CodAtrib,Int64 CodEmpresa)
        {
            return _objDALList.GetUsuariosParametros(Rut, Nombres, CodCaract, CodAtrib,CodEmpresa);
        }

        public List<EUSUARIO> GetUsuarioParametros(long Rut, string Nombres)
        {
            return _objDALList.SelectUsuarioParametros(Rut, Nombres);
        }

        public DataTable GetTutor(long codempresa)
        {
            return _objDALList.selectTutor(codempresa);
        }

        //esta funcion trae el último rut negativo para ingresar en losusuario extrajeros.
        public Int64 UltimoRutNegativo()
        {
            return _objDAL.UltimoRutNegativo();
        }
       

    }
}

