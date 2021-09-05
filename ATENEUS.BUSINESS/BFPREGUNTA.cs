
using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.IO;
using System.Text;
using System.Data;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFPREGUNTA.
	/// </summary>
	public class BFPREGUNTA
	{
		private DLPREGUNTA _objDAL;
		private DLPREGUNTAList _objDALList;
		
		public BFPREGUNTA()
		{
			_objDAL = new DLPREGUNTA();
			_objDALList = new DLPREGUNTAList();
		}

		public EPREGUNTA GetPREGUNTA()
		{
			return new EPREGUNTA();
		}

		public EPREGUNTA GetPREGUNTA(long id)
		{
            return new EPREGUNTA(id);
		}

		public bool Save(EPREGUNTA objPREGUNTA)
		{
			try
			{
				objPREGUNTA.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

		public List<EPREGUNTA> GetPREGUNTAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPREGUNTA objPREGUNTA)
		{
			try
			{
                _objDAL.Delete(objPREGUNTA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Update(EPREGUNTA objPREGUNTA)
        {
            try
            {
                _objDAL.Update(objPREGUNTA);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }
        public DataTable GetMassivePreguntas(string newFile, Int16 CodTipo, Int16 CodUnidad, Int16 Modo)
        {
            DataTable dt = new DataTable();
            DataTable dtTmp = new DataTable();
            try
            {
                DataSet excelList = _objDALList.SelectPreguntasByExcel(newFile);
                dtTmp.Columns.Add("Resultado");
                DataRow drTmp;
                if (excelList.Tables.Count > 0)
                {
                    BFPREGUNTAUNIDAD objBFPregUnid = new BFPREGUNTAUNIDAD();
                    List<EPREGUNTAUNIDAD> objPregUnida = new List<EPREGUNTAUNIDAD>();

                    BFPREGUNTA objBFPreg = new BFPREGUNTA();
                    EPREGUNTA objPreg = new EPREGUNTA();

                    BFALTERNATIVA objBFAlt = new BFALTERNATIVA();
                    List<EALTERNATIVA> objLstAlt = new List<EALTERNATIVA>();

                    BFEVALUACION objBFEval = new BFEVALUACION();
                    EEVALUACION objEval = new EEVALUACION();

                    BFENCUESTA objBFEncu = new BFENCUESTA();
                    EENCUESTA objEncu = new EENCUESTA();

                    objPregUnida = objBFPregUnid.PreguntasUnidad(CodUnidad);
                    foreach (EPREGUNTAUNIDAD obj in objPregUnida)
                    {
                        if ((objBFEval.SeEvaluoPregunta(obj.CodPregunta)) || (objBFEncu.SeEncuestoPregunta(obj.CodPregunta)))
                        {
                            drTmp = dtTmp.NewRow();
                            drTmp["Resultado"] = "ATENCION: Las preguntas de esta evaluacion no pueden ser modificadas, debiado a que ya se encuentran respondidas.";
                            dtTmp.Rows.Add(drTmp);
                            return dtTmp;
                        }
                    }


                    if (Modo == 1)
                    {
                        foreach (EPREGUNTAUNIDAD obj in objPregUnida)
                        {
                            objPreg = objBFPreg.GetPREGUNTA(obj.CodPregunta);
                            foreach (EALTERNATIVA objALt in objPreg.Alternativas)
                            {
                                objBFAlt.Delete(objALt);
                            }
                            objBFPregUnid.Delete(obj);
                        }
                        foreach (EPREGUNTAUNIDAD obj in objPregUnida)
                        {
                            objBFPreg.Delete(objPreg);
                        }
                    }

                    dt = excelList.Tables[0];
                    int Fila = 1;


                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!(dr[0].ToString() == "") && !(dr[1].ToString() == "")) // && !(dr[2].ToString() == "") && !(dr[9].ToString() == "") && !(dr[10].ToString() == ""))
                        {
                            if (dr[0].ToString() == "")
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " no posee el texto de la pregunta.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if (dr[1].ToString() == "")
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " no posee el tipo de pregunta.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if (!(dr[1].ToString().ToUpper() == "A") && !(dr[1].ToString().ToUpper() == "V") && !(dr[1].ToString().ToUpper() == "D"))
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: En la fila " + Fila + " debe poner uno de los siguientes tipos de pregunta:" + Environment.NewLine + "'A': Alternativas," + Environment.NewLine + "'V': Verdadero o Falso," + Environment.NewLine + "'D': Desarrollo.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if ((dr[2].ToString() == "") && (CodTipo == 2))
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: la fila " + Fila + " no posee puntaje para la pregunta.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if ((Utiles.ConvertToInt16(dr[2].ToString()) <= 0) && (CodTipo == 2))
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: En la fila " + Fila + " el puntaje debe ser mayor a 0.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if ((CodTipo == 2) && (dr[3].ToString() == ""))
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: Se estan cargando preguntas a una evaluacion y la fila " + Fila + " no posee la alternativa correcta.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if ((Utiles.ConvertToInt16(dr[3].ToString()) <= 0) && (CodTipo == 2))
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: En la fila " + Fila + " la alternativa correcta debe ser de valor numerico.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if ((dr[1].ToString().ToUpper() == "D") && (dr[10].ToString() == "") && CodTipo == 2)
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " debe ser solo A o V.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if (!(dr[1].ToString().ToUpper() == "D") && (dr[10].ToString() == ""))
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " debe poseer almenos 2 alternativas.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if (!(dr[1].ToString().ToUpper() == "D") && (dr[11].ToString() == ""))
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " debe poseer almenos 2 alternativas.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else
                            {
                                Int16 CodPregunta = Utiles.ConvertToInt16(GetSerial());
                                objPreg.CodPregunta = CodPregunta;
                                objPreg.Texto = dr[0].ToString().Trim().Replace("'", "^");
                                objPreg.CodCliente = dr[8].ToString().Trim().Replace("'", "^");
                                if (CodTipo == 2)
                                {
                                    objPreg.PuntajeMax = Utiles.ConvertToDouble(dr[2]);
                                }
                                else
                                {
                                    objPreg.PuntajeMax = Utiles.ConvertToDouble(0);
                                }
                                if (CodTipo == 2)
                                {
                                    objPreg.CodCorrecta = Utiles.ConvertToInt16(dr[3]);
                                }
                                else
                                {
                                    objPreg.CodCorrecta = Utiles.ConvertToInt16(0);
                                }
                                    
                                switch (dr[1].ToString().Trim())
                                {
                                    case "A":
                                        objPreg.CodTipoPreg = 3;
                                        break;
                                    case "V":
                                        objPreg.CodTipoPreg = 2;
                                        break;
                                    case "D":
                                        objPreg.CodTipoPreg = 1;
                                        break;
                                    default:
                                        objPreg.CodTipoPreg = 3;
                                        break;
                                }
                                objPreg.IsPersisted = false;
                                objBFPreg.Save(objPreg);
                                int i = 1;
                                for (int x = 10; x <= dt.Columns.Count - 1; x++)
                                {
                                    if (!(dr[x].ToString().Trim() == ""))
                                    {
                                        EALTERNATIVA objAlter = new EALTERNATIVA();
                                        objAlter.CodAlternativa = Utiles.ConvertToInt16(i);
                                        objAlter.CodPregunta = CodPregunta;
                                        objAlter.Texto = dr[x].ToString().Trim();
                                        if (CodTipo == 2)
                                        {
                                            objAlter.PuntajeMax = Utiles.ConvertToDouble(dr[2]);
                                        }
                                        else
                                        {
                                            objAlter.PuntajeMax = Utiles.ConvertToDouble(0);
                                        }
                                        if (CodTipo == 2)
                                        {
                                            if (i == Utiles.ConvertToInt16(dr[3]))
                                            {
                                                objAlter.EsCorrecta = true;
                                            }
                                            else
                                            {
                                                objAlter.EsCorrecta = false;
                                            }
                                        }
                                        else
                                        {
                                            objAlter.EsCorrecta = true;
                                        }
                                            
                                        objAlter.TextoComentario = "";
                                        objBFAlt.Save(objAlter);
                                    }
                                    i = i + 1;
                                }
                                EPREGUNTAUNIDAD objPU = new EPREGUNTAUNIDAD();
                                objPU.CodPregunta = CodPregunta;
                                objPU.CodUnidad = CodUnidad;
                                objPU.Imagen = dr[4].ToString().Trim();
                                objPU.Ancho = dr[5].ToString().Trim();
                                objPU.Alto = dr[6].ToString().Trim();
                                objPU.Link = dr[7].ToString().Trim();
                                objPU.UrlVideo = dr[8].ToString().Trim();
                                if (CodTipo == 2)
                                {
                                    objPU.PuntajeMax = Utiles.ConvertToDouble(dr[2]);
                                }
                                else
                                {
                                    objPU.PuntajeMax = Utiles.ConvertToDouble(0);
                                }
                                    
                                objBFPregUnid.Save(objPU);

                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " han sido agregados exitosamente.";
                                dtTmp.Rows.Add(drTmp);
                            }
                        }
                        else
                        {
                            drTmp = dtTmp.NewRow();
                            drTmp["Resultado"] = "ATENCION: La fila " + Fila + " no contiene data o se encuentra incompleta.";
                            dtTmp.Rows.Add(drTmp);
                        }
                        Fila = Fila + 1;
                    }
                }
                return dtTmp;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return dtTmp;
            }
        }

        public DataTable GetMassivePreguntasencuestas(string newFile, Int16 CodEncuesta, Int16 Modo)
        {
            DataTable dt = new DataTable();
            DataTable dtTmp = new DataTable();
            try
            {
                DataSet excelList = _objDALList.SelectPreguntasByExcel(newFile);
                dtTmp.Columns.Add("Resultado");
                DataRow drTmp;
                if (excelList.Tables.Count > 0)
                {
                    BFPREGUNTAENCUESTASATIS objBFPregUnid = new BFPREGUNTAENCUESTASATIS();
                    List<EPREGUNTAENCUESTASATIS> objPregUnida = new List<EPREGUNTAENCUESTASATIS>();

                    BFPREGUNTA objBFPreg = new BFPREGUNTA();
                    EPREGUNTA objPreg = new EPREGUNTA();

                    BFALTERNATIVA objBFAlt = new BFALTERNATIVA();
                    List<EALTERNATIVA> objLstAlt = new List<EALTERNATIVA>();
                    

                    BFENCUESTASATISUSUARIO objBFEncu = new BFENCUESTASATISUSUARIO();
                    EENCUESTASATISUSUARIO objEncu = new EENCUESTASATISUSUARIO();

                    objPregUnida = objBFPregUnid.PreguntasEncuesta(CodEncuesta);
                    foreach (EPREGUNTAENCUESTASATIS obj in objPregUnida)
                    {
                        if ((objBFEncu.SeEncuestoPregunta(obj.CodPregunta)))
                        {
                            drTmp = dtTmp.NewRow();
                            drTmp["Resultado"] = "ATENCION: Las preguntas de esta encuesta no pueden ser modificadas, debiado a que ya se encuentran respondidas.";
                            dtTmp.Rows.Add(drTmp);
                            return dtTmp;
                        }
                    }


                    if (Modo == 1)
                    {
                        foreach (EPREGUNTAENCUESTASATIS obj in objPregUnida)
                        {
                            objPreg = objBFPreg.GetPREGUNTA(obj.CodPregunta);
                            foreach (EALTERNATIVA objALt in objPreg.Alternativas)
                            {
                                objBFAlt.Delete(objALt);
                            }
                            objBFPregUnid.Delete(obj);
                        }
                        foreach (EPREGUNTAENCUESTASATIS obj in objPregUnida)
                        {
                            objBFPreg.Delete(objPreg);
                        }
                    }

                    dt = excelList.Tables[0];
                    int Fila = 1;


                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!(dr[0].ToString() == "") && !(dr[1].ToString() == "")) // && !(dr[2].ToString() == "") && !(dr[9].ToString() == "") && !(dr[10].ToString() == ""))
                        {
                            if (dr[0].ToString() == "")
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " no posee el texto de la pregunta.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if (dr[1].ToString() == "")
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " no posee el tipo de pregunta.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if (!(dr[1].ToString().ToUpper() == "A") && !(dr[1].ToString().ToUpper() == "V") && !(dr[1].ToString().ToUpper() == "D") && !(dr[1].ToString().ToUpper() == "E"))
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: En la fila " + Fila + " debe poner uno de los siguientes tipos de pregunta:" + Environment.NewLine + "'A': Alternativas," + Environment.NewLine + "'V': Verdadero o Falso," + Environment.NewLine + "'D': Desarrollo.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            //else if ((dr[2].ToString() == "") && (CodTipo == 2))
                            //{
                            //    drTmp = dtTmp.NewRow();
                            //    drTmp["Resultado"] = "ATENCION: la fila " + Fila + " no posee puntaje para la pregunta.";
                            //    dtTmp.Rows.Add(drTmp);
                            //}
                            //else if ((Utiles.ConvertToInt16(dr[2].ToString()) <= 0) && (CodTipo == 2))
                            //{
                            //    drTmp = dtTmp.NewRow();
                            //    drTmp["Resultado"] = "ATENCION: En la fila " + Fila + " el puntaje debe ser mayor a 0.";
                            //    dtTmp.Rows.Add(drTmp);
                            //}
                            //else if ((CodTipo == 2) && (dr[3].ToString() == ""))
                            //{
                            //    drTmp = dtTmp.NewRow();
                            //    drTmp["Resultado"] = "ATENCION: Se estan cargando preguntas a una evaluacion y la fila " + Fila + " no posee la alternativa correcta.";
                            //    dtTmp.Rows.Add(drTmp);
                            //}
                            //else if ((Utiles.ConvertToInt16(dr[3].ToString()) <= 0) && (CodTipo == 2))
                            //{
                            //    drTmp = dtTmp.NewRow();
                            //    drTmp["Resultado"] = "ATENCION: En la fila " + Fila + " la alternativa correcta debe ser de valor numerico.";
                            //    dtTmp.Rows.Add(drTmp);
                            //}
                            //else if ((dr[1].ToString().ToUpper() == "D") && (dr[10].ToString() == "") && CodTipo == 2)
                            //{
                            //    drTmp = dtTmp.NewRow();
                            //    drTmp["Resultado"] = "ATENCION: La fila " + Fila + " debe ser solo A o V.";
                            //    dtTmp.Rows.Add(drTmp);
                            //}
                            else if (!(dr[1].ToString().ToUpper() == "D") && (dr[10].ToString() == ""))
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " debe poseer almenos 2 alternativas.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else if (!(dr[1].ToString().ToUpper() == "D") && (dr[11].ToString() == ""))
                            {
                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " debe poseer almenos 2 alternativas.";
                                dtTmp.Rows.Add(drTmp);
                            }
                            else
                            {
                                Int16 CodPregunta = Utiles.ConvertToInt16(GetSerial());
                                objPreg.CodPregunta = CodPregunta;
                                objPreg.Texto = dr[0].ToString().Trim().Replace("'", "^");
                                objPreg.CodCliente = dr[8].ToString().Trim().Replace("'", "^");
                                //if (CodTipo == 2)
                                //{
                                //    objPreg.PuntajeMax = Utiles.ConvertToDouble(dr[2]);
                                //}
                                //else
                                //{
                                    objPreg.PuntajeMax = Utiles.ConvertToDouble(0);
                                //}
                                //if (CodTipo == 2)
                                //{
                                //    objPreg.CodCorrecta = Utiles.ConvertToInt16(dr[3]);
                                //}
                                //else
                                //{
                                    objPreg.CodCorrecta = Utiles.ConvertToInt16(0);
                                //}

                                switch (dr[1].ToString().Trim())
                                {
                                    case "A":
                                        objPreg.CodTipoPreg = 3;
                                        break;
                                    case "V":
                                        objPreg.CodTipoPreg = 2;
                                        break;
                                    case "D":
                                        objPreg.CodTipoPreg = 1;
                                        break;
                                    case "E":
                                        objPreg.CodTipoPreg = 4;
                                        break;
                                    default:
                                        objPreg.CodTipoPreg = 3;
                                        break;
                                }
                                objPreg.IsPersisted = false;
                                objBFPreg.Save(objPreg);
                                int i = 1;
                                for (int x = 10; x <= dt.Columns.Count - 1; x++)
                                {
                                    if (!(dr[x].ToString().Trim() == ""))
                                    {
                                        EALTERNATIVA objAlter = new EALTERNATIVA();
                                        objAlter.CodAlternativa = Utiles.ConvertToInt16(i);
                                        objAlter.CodPregunta = CodPregunta;
                                        objAlter.Texto = dr[x].ToString().Trim();
                                        //if (CodTipo == 2)
                                        //{
                                        //    objAlter.PuntajeMax = Utiles.ConvertToDouble(dr[2]);
                                        //}
                                        //else
                                        //{
                                            objAlter.PuntajeMax = Utiles.ConvertToDouble(0);
                                        //}
                                        //if (CodTipo == 2)
                                        //{
                                        //    if (i == Utiles.ConvertToInt16(dr[3]))
                                        //    {
                                        //        objAlter.EsCorrecta = true;
                                        //    }
                                        //    else
                                        //    {
                                        //        objAlter.EsCorrecta = false;
                                        //    }
                                        //}
                                        //else
                                        //{
                                            objAlter.EsCorrecta = false;
                                        //}

                                        objAlter.TextoComentario = "";
                                        objBFAlt.Save(objAlter);
                                    }
                                    i = i + 1;
                                }
                                EPREGUNTAENCUESTASATIS objPU = new EPREGUNTAENCUESTASATIS();
                                objPU.CodPregunta = CodPregunta;
                                objPU.CodEncuestaSatisfaccion = CodEncuesta;
                                objPU.Imagen = dr[4].ToString().Trim();
                                objPU.Ancho = dr[5].ToString().Trim();
                                objPU.Alto = dr[6].ToString().Trim();
                                objPU.Link = dr[7].ToString().Trim();
                                objPU.UrlVideo = dr[8].ToString().Trim();
                                //if (CodTipo == 2)
                                //{
                                //    objPU.PuntajeMax = Utiles.ConvertToDouble(dr[2]);
                                //}
                                //else
                                //{
                                    objPU.PuntajeMax = Utiles.ConvertToDouble(0);
                                //}

                                objBFPregUnid.Save(objPU);

                                drTmp = dtTmp.NewRow();
                                drTmp["Resultado"] = "ATENCION: La fila " + Fila + " han sido agregados exitosamente.";
                                dtTmp.Rows.Add(drTmp);
                            }
                        }
                        else
                        {
                            drTmp = dtTmp.NewRow();
                            drTmp["Resultado"] = "ATENCION: La fila " + Fila + " no contiene data o se encuentra incompleta.";
                            dtTmp.Rows.Add(drTmp);
                        }
                        Fila = Fila + 1;
                    }
                }
                return dtTmp;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return dtTmp;
            }
        }


        private Int64 GetSerial()
        {
            return _objDAL.Serial();
        }
	}
}

