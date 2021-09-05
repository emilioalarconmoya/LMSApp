using System;
using System.Collections.Generic;
using ATENEUS.COMMON;
using ATENEUS.BUSINESS;
using ATENEUS.CLASES.DAL;
using ATENEUS.CLASES.DAO;
using System.Data;

namespace ATENEUS.BUSINESS
{
    [Serializable()]
    public class BFREPORTES
    {
        private DLREPORTES _objDAL;

        public BFREPORTES()
		{
			_objDAL = new DLREPORTES();
		}

        private DataTable dtReporte = new DataTable();

        private Int16 TipoReporte = 0;

        private System.Int64 _RutUsuario = 0;

        private System.String _nombre_usuario = String.Empty;

        private System.String _apellidos = String.Empty;

        private System.Int16 _CodActividad = 0;

        private System.Int16 _CodUnidad = 0;

        private System.Decimal _cod_activ_usr = 0;

        private System.Int16 _cod_estado = 0;

        private System.DateTime _FechaInicio = System.DateTime.Now;

        private System.DateTime _HoraInicio = System.DateTime.Now;

        private System.DateTime _FechaFin = System.DateTime.Now;

        private System.DateTime _HoraFin = System.DateTime.Now;

        private System.Int16 _cod_tipo_actividad = 0;

        private System.Int16 _cod_tipo_unidad = 0;

        private System.Int16 _cod_proveedor = 0;

        private System.String _nombre = String.Empty;

        private System.String _codigo_sence = String.Empty;

        private System.Boolean _Vigente = false;

        private System.Int16 _CodPlantilla = 0;

        private System.Int16 _CodCaracteristica = 0;

        private System.Int16 _CodAtributo = 0;

        private System.String _NombreCaracteristica = String.Empty;

        private System.Int64 _cod_empresa = 0;

        private System.Int16 _estado_aprobado = -1;

        private System.Int64 _rut_tutor = 0;


        #region "Properties"

        public System.Int64 RutUsuario
        {
            get { return _RutUsuario; }
            set { _RutUsuario = value; }
        }

        public System.Int64 CodEmpresa
        {
            get { return _cod_empresa; }
            set { _cod_empresa = value; }
        }

        public System.String NombreUsuario
        {
            get { return _nombre_usuario; }
            set { _nombre_usuario = value; }
        }

        public System.String Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public System.Int16 CodActividad
        {
            get { return _CodActividad; }
            set { _CodActividad = value; }
        }

        public System.Int16 CodUnidad
        {
            get { return _CodUnidad; }
            set { _CodUnidad = value; }
        }

        public System.Decimal CodActivUsr
        {
            get { return _cod_activ_usr; }
            set { _cod_activ_usr = value; }
        }

        public System.Int16 CodEstado
        {
            get { return _cod_estado; }
            set { _cod_estado = value; }
        }

        public System.DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        public System.DateTime HoraInicio
        {
            get { return _HoraInicio; }
            set { _HoraInicio = value; }
        }

        public System.DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }

        public System.DateTime HoraFin
        {
            get { return _HoraFin; }
            set { _HoraFin = value; }
        }

        public System.Int16 CodTipoActividad
        {
            get { return _cod_tipo_actividad; }
            set { _cod_tipo_actividad = value; }
        }

        public System.Int16 CodTipoUnidad
        {
            get { return _cod_tipo_unidad; }
            set { _cod_tipo_unidad = value; }
        }

        public System.Int16 CodProveedor
        {
            get { return _cod_proveedor; }
            set { _cod_proveedor = value; }
        }

        public System.String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public System.String CodigoSence
        {
            get { return _codigo_sence; }
            set { _codigo_sence = value; }
        }

        public System.Boolean Vigente
        {
            get { return _Vigente; }
            set { _Vigente = value; }
        }

        public short CodPlantilla
        {
            get
            {
                return _CodPlantilla;
            }

            set
            {
                _CodPlantilla = value;
            }
        }

        public string NombreCaracteristica
        {
            get
            {
                return _NombreCaracteristica;
            }

            set
            {
                _NombreCaracteristica = value;
            }
        }

        public short CodCaracteristica
        {
            get
            {
                return _CodCaracteristica;
            }

            set
            {
                _CodCaracteristica = value;
            }
        }

        public short CodAtributo
        {
            get
            {
                return _CodAtributo;
            }

            set
            {
                _CodAtributo = value;
            }
        }
        public System.Int16 EstadoAprobado
        {
            get { return _estado_aprobado; }
            set { _estado_aprobado = value; }
        }

        public System.Int64 RutTutor
        {
            get { return _rut_tutor; }
            set { _rut_tutor = value; }
        }
        #endregion

        public DataTable REPORTES(Int16 Tipo)
		{
            TipoReporte = Tipo;
            DataTable dtReporte = new DataTable();
            switch (TipoReporte)
            { 
                case 1:
                    dtReporte = _objDAL.ReporteGeneral(Utiles.ConvertToString(CodActividad), FechaInicio.Year.ToString() + FechaInicio.Month.ToString().PadLeft(2, '0') + FechaInicio.Day.ToString().PadLeft(2, '0'), FechaFin.Year.ToString() + FechaFin.Month.ToString().PadLeft(2, '0') + FechaFin.Day.ToString().PadLeft(2, '0'),_cod_empresa);
                    dtReporte.TableName = "Reporte General";
                    break;
                case 2:
                    dtReporte = _objDAL.ReportePersonalizado(Utiles.ConvertToInt16(_CodPlantilla), Utiles.ConvertToInt32(_CodActividad), FechaInicio.Year.ToString() + FechaInicio.Month.ToString().PadLeft(2, '0') + FechaInicio.Day.ToString().PadLeft(2, '0'), FechaFin.Year.ToString() + FechaFin.Month.ToString().PadLeft(2, '0') + FechaFin.Day.ToString().PadLeft(2, '0'),_cod_empresa);
                    dtReporte.TableName = "Reporte personalizado";
                    break;
                case 3:
                    dtReporte = _objDAL.ReporteConsolidado(FechaInicio, FechaFin, Utiles.ConvertToInt32(_CodActividad), Utiles.ConvertToInt16(_CodCaracteristica), _NombreCaracteristica, _cod_empresa, _CodAtributo);
                    dtReporte.TableName = "Reporte consolidado";
                    break;
                case 4:
                    dtReporte = _objDAL.ReporteDetalleEvaluaciones(FechaInicio, FechaFin, Utiles.ConvertToInt32(_CodActividad), _CodUnidad,_cod_empresa);
                    dtReporte.TableName = "Detalle de evaluaciones";
                    break;
                case 5:
                    dtReporte = _objDAL.ReporteConexionAlumnoSence(RutUsuario, FechaInicio.Year.ToString() + FechaInicio.Month.ToString().PadLeft(2, '0') + FechaInicio.Day.ToString().PadLeft(2, '0'), FechaFin.Year.ToString() + FechaFin.Month.ToString().PadLeft(2, '0') + FechaFin.Day.ToString().PadLeft(2, '0'), _cod_empresa, Utiles.ConvertToInt32(_CodActividad));
                    dtReporte.TableName = "Detalle conexión alumno sence";
                    break;
                case 6:
                    dtReporte.TableName = "Ficha alumno";
                    dtReporte.Columns.Add();
                    break;
                case 7:
                    dtReporte.TableName = "Reporte visitas por rango horario";
                    dtReporte.Columns.Add();
                    break;
                case 8:
                    dtReporte.TableName = "Usuarios capacitados por sucursal";
                    dtReporte.Columns.Add();
                    break;
                case 9:
                    dtReporte.TableName = "Reporte resultado de evaluación";
                    dtReporte.Columns.Add();
                    break;
                case 10:
                    dtReporte.TableName = "Horas de capacitación";
                    dtReporte.Columns.Add();
                    break;
                case 11:
                    dtReporte.TableName = "Rendimiento de alumnos";
                    dtReporte.Columns.Add();
                    break;
                case 12:
                    dtReporte.TableName = "Reporte bitacora comunicación";
                    dtReporte.Columns.Add();
                    break;
                case 13:
                    dtReporte.TableName = "Reporte de rendimiento de tutores";
                    dtReporte.Columns.Add();
                    break;
                case 14:
                    dtReporte.TableName = "Reporte de encuesta";
                    dtReporte.Columns.Add();
                    break;
                case 15:
                    dtReporte.TableName = "Reporte detalle encuesta";
                    dtReporte.Columns.Add();
                    break;
                case 16:
                    dtReporte.TableName = "Reporte consolidado";
                    dtReporte.Columns.Add();
                    break;
                case 17:
                    dtReporte.TableName = "Reporte consolidado preguntas";
                    dtReporte.Columns.Add();
                    break;
                case 18:
                    dtReporte.TableName = "Reporte detalle consolidado preguntas";
                    dtReporte.Columns.Add();
                    break;
                case 19:
                    dtReporte.TableName = "Bitácora navegación";
                    dtReporte.Columns.Add();
                    break;
                case 20:
                    dtReporte.TableName = "Resultado encuesta por usuario";
                    dtReporte.Columns.Add();
                    break;
                case 21:
                    dtReporte.TableName = "Resultado detalle preguntas";
                    dtReporte.Columns.Add();
                    break;
                case 22:
                    dtReporte.TableName = "Ficha alumno";
                    dtReporte.Columns.Add();
                    break;
                case 23:
                    dtReporte.TableName = "Informe Cliente";
                    dtReporte.Columns.Add();
                    break;
                case 24:
                    dtReporte = _objDAL.ReporteSeguimiento(Utiles.ConvertToString(CodActividad), FechaInicio.Year.ToString() + FechaInicio.Month.ToString().PadLeft(2, '0') + FechaInicio.Day.ToString().PadLeft(2, '0'), FechaFin.Year.ToString() + FechaFin.Month.ToString().PadLeft(2, '0') + FechaFin.Day.ToString().PadLeft(2, '0'), _cod_empresa, _CodCaracteristica, _CodAtributo);
                    dtReporte.TableName = "Reporte Seguimiento";
                    break;
                case 25:
                    dtReporte = _objDAL.ReporteAlumnoTutor(Utiles.ConvertToString(CodActividad), FechaInicio.Year.ToString() + FechaInicio.Month.ToString().PadLeft(2, '0') + FechaInicio.Day.ToString().PadLeft(2, '0'), FechaFin.Year.ToString() + FechaFin.Month.ToString().PadLeft(2, '0') + FechaFin.Day.ToString().PadLeft(2, '0'), _cod_estado, _estado_aprobado, _cod_empresa, _rut_tutor);
                    dtReporte.TableName = "Reporte Alumnos tutor";
                    break;
                case 26:
                    dtReporte = _objDAL.ReporteIndicadoresActividad(CodActividad, FechaInicio,FechaFin, _CodCaracteristica, _CodAtributo, _cod_empresa);
                    dtReporte.TableName = "reprote indicadores";
                    break;
                case 27:
                    dtReporte = _objDAL.ReporteEstadisticasGenerales(FechaInicio, FechaFin, _cod_empresa);
                    dtReporte.TableName = "estadisticas generales";
                    break;
                default:
                    dtReporte.TableName = "";
                    dtReporte.Columns.Add();
                    break;
            }
            return dtReporte;
		}

        public DataTable GetReporte()
        {
            DataTable dtTmp = new DataTable(); ;
            switch (TipoReporte)
            {
                case 1: //Reporte General

                    break;
                case 2: //Reporte de actividades

                    break;
                case 3: //Listado de unidades por actividad

                    break;
                case 4: //Listado de alumnos existentes

                    break;
                case 5: //Estado de alumno por actividad

                    break;
                case 6: //Ficha alumno

                    break;
                case 7: //Reporte visitas por rango horario

                    break;
                case 8: //Usuarios capacitados por sucursal

                    break;
                case 9: //Reporte resultado de evaluación

                    break;
                case 10: //Horas de capacitación

                    break;
                case 11: //Rendimiento de alumnos

                    break;
                case 12: //Reporte bitacora comunicación

                    break;
                case 13: //Reporte de rendimiento de tutores

                    break;
                case 14: //Reporte de encuesta

                    break;
                case 15: //Reporte detalle encuesta

                    break;
                case 16: //Reporte consolidado

                    break;
                case 17: //Reporte consolidado preguntas

                    break;
                case 18: //Reporte detalle consolidado preguntas

                    break;
                case 19: //Bitácora navegación

                    break;
                case 20: //Resultado encuesta por usuario

                    break;
                case 21: //Resultado detalle preguntas

                    break;
                case 22: //Ficha alumno

                    break;
                case 23: //Informe Cliente

                    break;
                default:
                    break;
            }
            return dtReporte;
        }

    }
}
