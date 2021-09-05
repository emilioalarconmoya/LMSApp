﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ATENEUS.CLASES.DAO;
using ATENEUS.DATAACCESS;
using ATENEUS.COMMON;

namespace ATENEUS.CLASES.DAL
{
    /// <summary>
    /// Summary description for DLBase.
    /// </summary>
    public abstract class DLBase
    {
        protected virtual string GetDeleteProcedure() { return string.Empty; }
        protected virtual string GetInsertProcedure() { return string.Empty; }
        protected virtual string GetSelectProcedure() { return string.Empty; }
        protected virtual string GetUpdateProcedure() { return string.Empty; }

        protected virtual IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db) { return null; }
        protected virtual IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db) { return null; }
        protected virtual IDbDataParameter[] GetSelectParameters(long id, DB db) { return null; }
        protected virtual IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db) { return null; }

        protected virtual void SetPrimaryKey(DomainObject obj, long id) { }

        /// <summary>
        /// Llena un objeto de negocio con datos persistidos 
        /// en una base de datos
        /// </summary>
        /// <param name="id">Identificador único del registro</param>
        /// <param name="obj">El objeto de negocio</param>
        public virtual void Select(long id,Int64 CodEmpresa, DomainObject obj)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            //IDbDataParameter[] prms = GetSelectParameters(id, db);
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@RUT_USUARIO";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEmpresa;
            prms[1].ParameterName = "@cod_empresa";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, this.GetSelectProcedure(), prms);

            if ((dr != null) && dr.Read())
            {
                this.Fill(obj, dr);
                obj.IsPersisted = true;
            }
            dr.Close();
        }

        public virtual void Select(long id, DomainObject obj)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = GetSelectParameters(id, db);            
            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, this.GetSelectProcedure(), prms);

            if ((dr != null) && dr.Read())
            {
                this.Fill(obj, dr);
                obj.IsPersisted = true;
            }
            dr.Close();
        }

        /// <summary>
        /// Persiste los datos de un objeto de negocio
        /// </summary>
        /// <param name="obj">El objeto de negocio</param>
        public virtual void Insert(DomainObject obj)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = GetInsertParameters(obj, db);

            long id = Utiles.ConvertToInt64(db.ExecuteScalar(CommandType.StoredProcedure, GetInsertProcedure(), prms));

            SetPrimaryKey(obj, id);
        }

        /// <summary>
        /// Persiste los datos actualizados de un objeto de negocio
        /// </summary>
        /// <param name="obj">El objeto de negocio</param>
        public virtual void Update(DomainObject obj)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = GetUpdateParameters(obj, db);

            db.ExecuteNonQuery(CommandType.StoredProcedure, GetUpdateProcedure(), prms);
        }

        /// <summary>
        /// Elimina los datos persistidos de un objeto de negocio
        /// </summary>
        /// <param name="obj">El objeto de negocio</param>
        public virtual void Delete(DomainObject obj)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = GetDeleteParameters(obj, db);

            db.ExecuteNonQuery(CommandType.StoredProcedure, GetDeleteProcedure(), prms);
        }

        ///// <summary>
        ///// Persiste los datos actualizados de un objeto de negocio
        ///// </summary>
        ///// <param name="obj">El objeto de negocio</param>
        ///// <param name="transaction">La transacción del proceso</param>
        //public virtual void Insert(DomainObject obj, IDbTransaction transaction)
        //{
        //    DB db = DatabaseFactory.Instance.GetDatabase();
        //    IDbDataParameter[] prms = GetInsertParameters(obj, db);

        //    long id = Tools.ConvertToInt64(db.ExecuteScalar(transaction, CommandType.StoredProcedure, GetInsertProcedure(), prms));

        //    SetPrimaryKey(obj, id);
        //}

        ///// <summary>
        ///// Elimina los datos persistidos de un objeto de negocio
        ///// </summary>
        ///// <param name="obj">El objeto de negocio</param>
        ///// <param name="transaction">La transacción del proceso</param>
        //public virtual void Update(DomainObject obj, IDbTransaction transaction)
        //{
        //    DB db = DatabaseFactory.Instance.GetDatabase();
        //    IDbDataParameter[] prms = GetUpdateParameters(obj, db);

        //    db.ExecuteNonQuery(transaction, CommandType.StoredProcedure, GetUpdateProcedure(), prms);
        //}


        /// <summary>
        /// Realiza el Marshaling y llenado los datos de un objeto de negocio
        /// a partir de un DataReader.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="dr"></param>
        public abstract void Fill(DomainObject obj, IDataReader dr);
    }
}
