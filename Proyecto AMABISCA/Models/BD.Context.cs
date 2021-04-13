﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_AMABISCA.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AMABISCAEntities : DbContext
    {
        public AMABISCAEntities()
            : base("name=AMABISCAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AT_DESCRIPCION> AT_DESCRIPCION { get; set; }
        public virtual DbSet<AT_PROVEEDOR> AT_PROVEEDOR { get; set; }
        public virtual DbSet<BT_DESCRIPCION> BT_DESCRIPCION { get; set; }
        public virtual DbSet<BT_TIPO> BT_TIPO { get; set; }
        public virtual DbSet<IT_DESCRIPCION> IT_DESCRIPCION { get; set; }
        public virtual DbSet<OT_DESCRIPCION> OT_DESCRIPCION { get; set; }
        public virtual DbSet<OT_ENVIO> OT_ENVIO { get; set; }
        public virtual DbSet<OT_ESTADO> OT_ESTADO { get; set; }
        public virtual DbSet<OT_IDENTIFICACION> OT_IDENTIFICACION { get; set; }
        public virtual DbSet<PT_CATEGORIA> PT_CATEGORIA { get; set; }
        public virtual DbSet<PT_DESCRIPCION> PT_DESCRIPCION { get; set; }
        public virtual DbSet<PT_TIPO_UNIDAD> PT_TIPO_UNIDAD { get; set; }
        public virtual DbSet<PT_UNIDAD> PT_UNIDAD { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UT_CUENTA> UT_CUENTA { get; set; }
        public virtual DbSet<UT_DESCRIPCION> UT_DESCRIPCION { get; set; }
        public virtual DbSet<UT_ROL> UT_ROL { get; set; }
    
        public virtual int P_AGREGAR_ROL(string nOMBRE, string pERMISO)
        {
            var nOMBREParameter = nOMBRE != null ?
                new ObjectParameter("NOMBRE", nOMBRE) :
                new ObjectParameter("NOMBRE", typeof(string));
    
            var pERMISOParameter = pERMISO != null ?
                new ObjectParameter("PERMISO", pERMISO) :
                new ObjectParameter("PERMISO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("P_AGREGAR_ROL", nOMBREParameter, pERMISOParameter);
        }
    
        public virtual ObjectResult<P_CLIENTES_RECURRENTES_Result> P_CLIENTES_RECURRENTES(Nullable<int> lIMITE)
        {
            var lIMITEParameter = lIMITE.HasValue ?
                new ObjectParameter("LIMITE", lIMITE) :
                new ObjectParameter("LIMITE", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<P_CLIENTES_RECURRENTES_Result>("P_CLIENTES_RECURRENTES", lIMITEParameter);
        }
    
        public virtual ObjectResult<P_INVENTARIO_PERIODO_Result> P_INVENTARIO_PERIODO(Nullable<System.DateTime> fECHAMIN, Nullable<System.DateTime> fECHAMAX)
        {
            var fECHAMINParameter = fECHAMIN.HasValue ?
                new ObjectParameter("FECHAMIN", fECHAMIN) :
                new ObjectParameter("FECHAMIN", typeof(System.DateTime));
    
            var fECHAMAXParameter = fECHAMAX.HasValue ?
                new ObjectParameter("FECHAMAX", fECHAMAX) :
                new ObjectParameter("FECHAMAX", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<P_INVENTARIO_PERIODO_Result>("P_INVENTARIO_PERIODO", fECHAMINParameter, fECHAMAXParameter);
        }
    
        public virtual ObjectResult<P_PRODUCTOS_SOLICITADOS_Result> P_PRODUCTOS_SOLICITADOS(Nullable<int> lIMITE)
        {
            var lIMITEParameter = lIMITE.HasValue ?
                new ObjectParameter("LIMITE", lIMITE) :
                new ObjectParameter("LIMITE", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<P_PRODUCTOS_SOLICITADOS_Result>("P_PRODUCTOS_SOLICITADOS", lIMITEParameter);
        }
    
        public virtual ObjectResult<P_VENTAS_PERIODO_Result> P_VENTAS_PERIODO(Nullable<System.DateTime> fECHAMIN, Nullable<System.DateTime> fECHAMAX)
        {
            var fECHAMINParameter = fECHAMIN.HasValue ?
                new ObjectParameter("FECHAMIN", fECHAMIN) :
                new ObjectParameter("FECHAMIN", typeof(System.DateTime));
    
            var fECHAMAXParameter = fECHAMAX.HasValue ?
                new ObjectParameter("FECHAMAX", fECHAMAX) :
                new ObjectParameter("FECHAMAX", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<P_VENTAS_PERIODO_Result>("P_VENTAS_PERIODO", fECHAMINParameter, fECHAMAXParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
