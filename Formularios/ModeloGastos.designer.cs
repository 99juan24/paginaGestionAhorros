﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaginaAhorro.Formularios
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BDProyecto")]
	public partial class ModeloGastosDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void Insertgasto(gasto instance);
    partial void Updategasto(gasto instance);
    partial void Deletegasto(gasto instance);
        #endregion

        public ModeloGastosDataContext() :
                base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConexionBDProyecto"].ConnectionString, mappingSource)
        {
            OnCreated();
        }
        public ModeloGastosDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModeloGastosDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModeloGastosDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModeloGastosDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<gasto> gasto
		{
			get
			{
				return this.GetTable<gasto>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.actualizarGastos")]
		public int actualizarGastos([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Id", DbType="Int")] System.Nullable<int> id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string nombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Float")] System.Nullable<double> monto, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> fecha_limite)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, nombre, monto, fecha_limite);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.buscarGastos")]
		public ISingleResult<buscarGastosResult> buscarGastos([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Id", DbType="Int")] System.Nullable<int> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((ISingleResult<buscarGastosResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.eliminarGastos")]
		public int eliminarGastos([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Id", DbType="Int")] System.Nullable<int> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.insertarGastos")]
		public int insertarGastos([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Id", DbType="Int")] System.Nullable<int> id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string nombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Float")] System.Nullable<double> monto, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> fecha_creacion, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> fecha_limite)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id, nombre, monto, fecha_creacion, fecha_limite);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.gasto")]
	public partial class gasto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _nombre;
		
		private System.Nullable<double> _monto;
		
		private System.Nullable<System.DateTime> _fecha_creacion;
		
		private System.Nullable<System.DateTime> _fecha_limite;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void OnmontoChanging(System.Nullable<double> value);
    partial void OnmontoChanged();
    partial void Onfecha_creacionChanging(System.Nullable<System.DateTime> value);
    partial void Onfecha_creacionChanged();
    partial void Onfecha_limiteChanging(System.Nullable<System.DateTime> value);
    partial void Onfecha_limiteChanged();
    #endregion
		
		public gasto()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="NVarChar(50)")]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_monto", DbType="Float")]
		public System.Nullable<double> monto
		{
			get
			{
				return this._monto;
			}
			set
			{
				if ((this._monto != value))
				{
					this.OnmontoChanging(value);
					this.SendPropertyChanging();
					this._monto = value;
					this.SendPropertyChanged("monto");
					this.OnmontoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha_creacion", DbType="Date")]
		public System.Nullable<System.DateTime> fecha_creacion
		{
			get
			{
				return this._fecha_creacion;
			}
			set
			{
				if ((this._fecha_creacion != value))
				{
					this.Onfecha_creacionChanging(value);
					this.SendPropertyChanging();
					this._fecha_creacion = value;
					this.SendPropertyChanged("fecha_creacion");
					this.Onfecha_creacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha_limite", DbType="Date")]
		public System.Nullable<System.DateTime> fecha_limite
		{
			get
			{
				return this._fecha_limite;
			}
			set
			{
				if ((this._fecha_limite != value))
				{
					this.Onfecha_limiteChanging(value);
					this.SendPropertyChanging();
					this._fecha_limite = value;
					this.SendPropertyChanged("fecha_limite");
					this.Onfecha_limiteChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class buscarGastosResult
	{
		
		private int _Id;
		
		private string _nombre;
		
		private System.Nullable<double> _monto;
		
		private System.Nullable<System.DateTime> _fecha_creacion;
		
		private System.Nullable<System.DateTime> _fecha_limite;
		
		public buscarGastosResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL")]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="NVarChar(50)")]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this._nombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_monto", DbType="Float")]
		public System.Nullable<double> monto
		{
			get
			{
				return this._monto;
			}
			set
			{
				if ((this._monto != value))
				{
					this._monto = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha_creacion", DbType="Date")]
		public System.Nullable<System.DateTime> fecha_creacion
		{
			get
			{
				return this._fecha_creacion;
			}
			set
			{
				if ((this._fecha_creacion != value))
				{
					this._fecha_creacion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha_limite", DbType="Date")]
		public System.Nullable<System.DateTime> fecha_limite
		{
			get
			{
				return this._fecha_limite;
			}
			set
			{
				if ((this._fecha_limite != value))
				{
					this._fecha_limite = value;
				}
			}
		}
	}
}
#pragma warning restore 1591