using System;
using Regisoft;
using System.Collections.Generic ;

namespace CertificadosSESAB.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Usuario
	{
		

		
		#region Private Members		

		private long? _id_usuario; 
		private Unidade _id_unidade; 
		private string _nome; 
		private string _login; 
		private string _senha; 
		private string _e_mail; 		
		#endregion

		
		
		#region Constructor

		public Usuario()
		{
			_id_usuario = null; 
			_id_unidade = null; 
			_nome = null;
			_login = null;
			_senha = null;
			_e_mail = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdUsuario
		{
			get
			{ 
				return _id_usuario;
			}
			set
			{
				_id_usuario = value;
			}

		}
			
		public virtual Unidade IdUnidade
		{
			get
			{ 
				return _id_unidade;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'IdUnidade'");

				_id_unidade = value;
			}

		}
			
		public virtual string Nome
		{
			get
			{ 
				return _nome;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Nome'");
				
				if(  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'Nome'");					

				_nome = value;
			}
		}
			
		public virtual string Login
		{
			get
			{ 
				return _login;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Login'");
				
				if(  value.Length > 50)
					throw new ExceptionRS("Valor ultrapassa limite em 'Login'");					

				_login = value;
			}
		}
			
		public virtual string Senha
		{
			get
			{ 
				return _senha;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Senha'");
				
				if(  value.Length > 50)
					throw new ExceptionRS("Valor ultrapassa limite em 'Senha'");					

				_senha = value;
			}
		}
			
		public virtual string EMail
		{
			get
			{ 
				return _e_mail;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'EMail'");
				
				if(  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'EMail'");					

				_e_mail = value;
			}
		}
			
		#endregion 
		
		
		#region Public Functions

		#endregion

		
		
		#region Equals And HashCode Overrides
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			Usuario castObj = (Usuario)obj; 
			return ( castObj != null ) &&
				( this._id_usuario == castObj.IdUsuario );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_usuario.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
