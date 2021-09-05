
using System;
using System.Data;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;

namespace ATENEUS.BUSINESS
{
	/// <summary>
	/// BFMOVIMIENTOCARTOLA.
	/// </summary>
	public class BFMOVIMIENTOCARTOLA
	{
		private DLMOVIMIENTOCARTOLA _objDAL;
		private DLMOVIMIENTOCARTOLAList _objDALList;
		
		public BFMOVIMIENTOCARTOLA()
		{
			_objDAL = new DLMOVIMIENTOCARTOLA();
			_objDALList = new DLMOVIMIENTOCARTOLAList();
		}

		public EMOVIMIENTOCARTOLA GetMOVIMIENTOCARTOLA()
		{
			return new EMOVIMIENTOCARTOLA();
		}

		public EMOVIMIENTOCARTOLA GetMOVIMIENTOCARTOLA(long id)
		{
            return new EMOVIMIENTOCARTOLA(id);
		}

		public bool Save(EMOVIMIENTOCARTOLA objMOVIMIENTOCARTOLA)
		{
			try
			{
				objMOVIMIENTOCARTOLA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EMOVIMIENTOCARTOLA> GetMOVIMIENTOCARTOLAAll()
		{
			return _objDALList.SelectAll();
        }

        public DataTable GetCartolaPuntos(Int64 RutUsuario, Int16 Periodo)
        {
            return _objDALList.GetCartolaPuntos(RutUsuario, Periodo);
        }

        public string CanjearProducto(string CodTienda, string CodProducto, Int64 RutUsuario, Int32 Saldo, Int32 MaxCanjes, Int32 CantidadCanjes)
        {
            string Resultado = "";
            try
            {
                if (CantidadCanjes >= MaxCanjes)
                {
                    Resultado = "ATENCION: Ya alcanzaste el máximo de canjees permitido.";
                    return Resultado;
                }
                BFPRODUCTOTIENDA objBFPT = new BFPRODUCTOTIENDA();
                EPRODUCTOTIENDA objPT = objBFPT.GetProductoTienda(CodTienda, CodProducto);
                int stock = objPT.STOCK;
                int SaldoFinal = Saldo - objPT.COSTOPUNTOS;

                if (stock <= 0)
                {
                    Resultado = "ATENCION: No queda stock disponible para este producto.";
                    return Resultado;
                }
                if (SaldoFinal < 0)
                {
                    Resultado = "ATENCION: Su saldo no es suficiente para este producto.";
                    return Resultado;
                }
                BFPRODUCTO objBFPR = new BFPRODUCTO();
                EPRODUCTO objPR = objBFPR.GetPRODUCTO(objPT.CODPRODUCTO);
                
                EMOVIMIENTOCARTOLA objMC = new EMOVIMIENTOCARTOLA();
                objMC.CODTIPOMOVIMIENTO = 2;
                objMC.RUTUSUARIO = RutUsuario;
                objMC.PUNTOS = objPT.COSTOPUNTOS;
                objMC.FECHAHORA = DateTime.Now;
                objMC.OBSERVACION = "Canje de producto: " + objPR.NOMBRE;
                objMC.SALDO = SaldoFinal;
                objMC.IsPersisted = false;
                Save(objMC); 

                BFPRODUCTOCANJEADO objBFPC = new BFPRODUCTOCANJEADO();
                EPRODUCTOCANJEADO objPC = new EPRODUCTOCANJEADO();
                objPC.CODPRODUCTO = objPT.CODPRODUCTO;
                objPC.CODMOVIMIENTO = objMC.CODMOVIMIENTO;
                objPC.CODTIENDA = CodTienda;
                objPC.COSTOPUNTOS = objPT.COSTOPUNTOS;
                objPC.IsPersisted = false;
                objBFPC.Save(objPC);

                objPT.STOCK = stock - 1;
                objPT.MAX_CANJEES = MaxCanjes;
                objPT.IsPersisted = true;
                objBFPT.Save(objPT);


                Resultado = "ATENCION: Este producto ha sido reservado correctamente.";
                return Resultado;
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                Resultado = "ATENCION: Ha ocurrido un problema, volver a intentarlo más tarde.";
                return Resultado;
            }
        }

        public void AsignarPuntos (List<EMOVIMIENTOCARTOLA> Lista, Int64 Rut)
        {
            try
            {
                foreach (EMOVIMIENTOCARTOLA objMC in Lista)
                {
                    Save(objMC);

                    BFASIGNAMOVIMIENTO objBFAM = new BFASIGNAMOVIMIENTO();
                    EASIGNAMOVIMIENTO objAM = new EASIGNAMOVIMIENTO();
                    objAM.CODMOVIMIENTO = objMC.CODMOVIMIENTO;
                    objAM.RUTUSUARIO = Rut;
                    objAM.IsPersisted = false;
                    objBFAM.Save(objAM);
                }
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public bool Delete(EMOVIMIENTOCARTOLA objMOVIMIENTOCARTOLA)
		{
			try
			{
                _objDAL.Delete(objMOVIMIENTOCARTOLA);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EMOVIMIENTOCARTOLA objMOVIMIENTOCARTOLA)
        {
            try
            {
                _objDAL.Update(objMOVIMIENTOCARTOLA);
                return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

	}
}

