using System;
using Regisoft;
using System.Collections.Generic ;

namespace CertificadosSESAB.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Evento
	{
		

		
		#region Private Members		

		private long? _id_evento; 
		private Unidade _id_unidade; 
		private string _nome; 
		private string _arquivo_certificado; 
		private int _x; 
		private int _y; 
		private DateTime _data_liberacao_documento; 		
		#endregion

		
		
		#region Constructor

		public Evento()
		{
			_id_evento = null; 
			_id_unidade = null; 
			_nome = null;
			_arquivo_certificado = null;
			_x = 0;
			_y = 0;
			_data_liberacao_documento = Convert.ToDateTime("1/1/1800");
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdEvento
		{
			get
			{ 
				return _id_evento;
			}
			set
			{
				_id_evento = value;
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
			
		public virtual string ArquivoCertificado
		{
			get
			{ 
				return _arquivo_certificado;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'ArquivoCertificado'");
				
				if(  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'ArquivoCertificado'");					

				_arquivo_certificado = value;
			}
		}
			
		public virtual int X
		{
			get
			{ 
				return _x;
			}
			set
			{
				_x = value;
			}

		}
			
		public virtual int Y
		{
			get
			{ 
				return _y;
			}
			set
			{
				_y = value;
			}

		}
			
		public virtual DateTime DataLiberacaoDocumento
		{
			get
			{ 
				return _data_liberacao_documento;
			}
			set
			{
				_data_liberacao_documento = value;
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
			Evento castObj = (Evento)obj; 
			return ( castObj != null ) &&
				( this._id_evento == castObj.IdEvento );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_evento.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
