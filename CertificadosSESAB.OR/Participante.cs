using System;
using Regisoft;
using System.Collections.Generic ;

namespace CertificadosSESAB.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Participante
	{
		

		
		#region Private Members		

		private long? _id_participante; 
		private string _nome; 
		private string _cpf; 
		private string _email; 		
		#endregion

		
		
		#region Constructor

		public Participante()
		{
			_id_participante = null; 
			_nome = null;
			_cpf = null;
			_email = null;
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdParticipante
		{
			get
			{ 
				return _id_participante;
			}
			set
			{
				_id_participante = value;
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
			
		public virtual string Cpf
		{
			get
			{ 
				return _cpf;
			}

			set	
			{	
				if( value == null )
					throw new ExceptionRS("Informe 'Cpf'");
				
				if(  value.Length > 11)
					throw new ExceptionRS("Valor ultrapassa limite em 'Cpf'");					

				_cpf = value;
			}
		}
			
		public virtual string Email
		{
			get
			{ 
				return _email;
			}

			set	
			{	
				if(  value != null &&  value.Length > 100)
					throw new ExceptionRS("Valor ultrapassa limite em 'Email'");					

				_email = value;
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
			Participante castObj = (Participante)obj; 
			return ( castObj != null ) &&
				( this._id_participante == castObj.IdParticipante );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_participante.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
