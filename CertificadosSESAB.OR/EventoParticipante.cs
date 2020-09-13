using System;
using Regisoft;
using System.Collections.Generic ;

namespace CertificadosSESAB.OR
{
	/// <summary>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Serializable]
	public /*sealed*/ class EventoParticipante
	{
		

		
		#region Private Members		

		private long? _id_evento_participante; 
		private Participante _id_participante; 
		private Evento _id_evento; 		
		#endregion

		
		
		#region Constructor

		public EventoParticipante()
		{
			_id_evento_participante = null; 
			_id_participante = null; 
			_id_evento = null; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor

		
		
		#region Public Properties
			
		public virtual long? IdEventoParticipante
		{
			get
			{ 
				return _id_evento_participante;
			}
			set
			{
				_id_evento_participante = value;
			}

		}
			

		public virtual Participante IdParticipante
		{
			get
			{ 
				return _id_participante;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'IdParticipante'");

				_id_participante = value;
			}

		}
			
		public virtual Evento IdEvento
		{
			get
			{ 
				return _id_evento;
			}
			set
			{
				if( value == null )
					throw new ExceptionRS("Informe 'IdEvento'");

				_id_evento = value;
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
			EventoParticipante castObj = (EventoParticipante)obj; 
			return ( castObj != null ) &&
				( this._id_evento_participante == castObj.IdEventoParticipante );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id_evento_participante.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
