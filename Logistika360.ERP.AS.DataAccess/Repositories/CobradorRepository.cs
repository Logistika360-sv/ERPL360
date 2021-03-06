﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistika360.ERP.ERPADMIN.DataAccess.Repositories;
using Logistika360.ERP.AS.DataAccess.Entities;
using Logistika360.ERP.AS.DataAccess.Contracts;
using System.Data;
using System.Data.SqlClient;

namespace Logistika360.ERP.AS.DataAccess.Repositories
{
    public class CobradorRepository : MasterRepository, ICobradorRepository
    {

        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public CobradorRepository()
        {
            selectAll = "SELECT * FROM ERPL360.COBRADOR";
            insert = "insert into ERPL360.COBRADOR(COBRADOR,CONJUNTO,NOMBRE,EMPLEADO,COMISION,CTR_COMISION,CTA_COMISION,CORREO,ACTIVO,TELEFONO,CREATEDBY,CREATEDATE,RECORDDATE,UPDATEDBY) values(@COBRADOR,@CONJUNTO,@NOMBRE,@EMPLEADO,@COMISION,@CTR_COMISION,@CTA_COMISION,@CORREO,@ACTIVO,@TELEFONO,@CREATEDBY,@CREATEDATE,@RECORDDATE,@UPDATEDBY)";
            update = "UPDATE ERPL360.COBRADOR SET NOMBRE=@NOMBRE,EMPLEADO=@EMPLEADO,CTR_COMISION=@CTR_COMISION,CTA_COMISION=@CTA_COMISION,CORREO=@CORREO,ACTIVO=@ACTIVO,TELEFONO=@TELEFONO,UPDATEDBY=@UPDATEDBY,RECORDDATE=@RECORDDATE WHERE CONJUNTO=@CONJUNTO AND COBRADOR=@COBRADOR ";
            delete = "DELETE ERPL360.COBRADOR WHERE CONJUNTO=@CONJUNTO AND COBRADOR=@COBRADOR";
        }

        public int Add(Cobrador entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@COBRADOR", entity.COBRADOR));
            parameters.Add(new SqlParameter("@CONJUNTO", entity.CONJUNTO));
            parameters.Add(new SqlParameter("@NOMBRE", entity.NOMBRE));
            parameters.Add(new SqlParameter("@EMPLEADO", entity.EMPLEADO));
            parameters.Add(new SqlParameter("@COMISION", entity.COMISION));
            parameters.Add(new SqlParameter("@CTR_COMISION", entity.CTR_COMISION));
            parameters.Add(new SqlParameter("@CTA_COMISION", entity.CTA_COMISION));
            parameters.Add(new SqlParameter("@CORREO", entity.CORREO));
            parameters.Add(new SqlParameter("@ACTIVO", entity.ACTIVO));
            parameters.Add(new SqlParameter("@TELEFONO", entity.TELEFONO));
            parameters.Add(new SqlParameter("@CREATEDBY", entity.CreatedBy));
            parameters.Add(new SqlParameter("@CREATEDATE", entity.CreateDate));
            parameters.Add(new SqlParameter("@RECORDDATE", entity.RecordDate));
            parameters.Add(new SqlParameter("@UPDATEDBY", entity.UpdatedBy));
            return ExecuteNonQuery(insert);
        }

        public int Edit(Cobrador entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@COBRADOR", entity.COBRADOR));
            parameters.Add(new SqlParameter("@CONJUNTO", entity.CONJUNTO));
            parameters.Add(new SqlParameter("@NOMBRE", entity.NOMBRE));
            parameters.Add(new SqlParameter("@EMPLEADO", entity.EMPLEADO));
            parameters.Add(new SqlParameter("@COMISION", entity.COMISION));
            parameters.Add(new SqlParameter("@CTR_COMISION", entity.CTR_COMISION));
            parameters.Add(new SqlParameter("@CTA_COMISION", entity.CTA_COMISION));
            parameters.Add(new SqlParameter("@CORREO", entity.CORREO));
            parameters.Add(new SqlParameter("@ACTIVO", entity.ACTIVO));
            parameters.Add(new SqlParameter("@TELEFONO", entity.TELEFONO));
            parameters.Add(new SqlParameter("@RECORDDATE", entity.RecordDate));
            parameters.Add(new SqlParameter("@UPDATEDBY", entity.UpdatedBy));
            return ExecuteNonQuery(update);

        }

        public IEnumerable<Cobrador> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listCobrador= new List<Cobrador>();
            foreach (DataRow item in tableResult.Rows)
            {
                listCobrador.Add(new Cobrador
                {
                    COBRADOR = item[0].ToString(),
                    CONJUNTO = item[1].ToString(),
                    NOMBRE = item[2].ToString(),
                    EMPLEADO = item[3].ToString(),
                    COMISION = Convert.ToDecimal(item[4].ToString()),
                    CTR_COMISION = item[5].ToString(),
                    CTA_COMISION = item[6].ToString(),
                    CORREO = item[7].ToString(),
                    ACTIVO = item[8].ToString(),
                    TELEFONO = item[9].ToString(),
                    UpdatedBy = item[10].ToString(),
                    RecordDate = Convert.ToDateTime(item[11]),
                    CreatedBy = item[12].ToString(),
                    CreateDate = Convert.ToDateTime(item[13]),



                });
            }
            return listCobrador;
        }

        public int Remove(string valor)
        {
            throw new NotImplementedException();
        }

        public int Remove2(string COBRADOR, string CONJUNTO)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@COBRADOR", COBRADOR));
            parameters.Add(new SqlParameter("@CONJUNTO", CONJUNTO));
            return ExecuteNonQuery(delete);
        }
    }
}
