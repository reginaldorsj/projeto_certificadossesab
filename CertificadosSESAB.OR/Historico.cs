using System;
using Regisoft;
using System.Collections.Generic ;

namespace CertificadosSESAB.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class Historico
	{
		

		
		#region Private Members		

		private long? _id_historico; 
		private EventoParticipante _id_evento_participante; 
		private DateTime _data_hora; 		
		#endregion

		
		
		#region Constructor

		public Historico()
		{
			_id_historico = null; 
			_id_evento_participante = null; 
			_data_hora = Convert.ToDateTime("1/1/1800");
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdHistorico
		{
			get
			{ 
				return _id_historico;
			}
			set
			{
				_id_historico = value;
			}

		}
			
		public virtual EventoParticipante IdEventoParticipante
		{
			get
			{ 
				return _id_evento_participante;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'IdEventoParticipante'");

				_id_evento_participante = value;
			}

		}
			
		public virtual DateTime DataHora
		{
			get
			{ 
				return _data_hora;
			}
			set
			{
				_data_hora = value;
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
			Historico castObj = (Historico)obj; 
			return ( castObj != null ) &&
				( this._id_historico == castObj.IdHistorico );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_historico.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
