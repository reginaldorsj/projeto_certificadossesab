

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.DAO
{
	/// <summary>
	/// Classe <see cref='IEventoParticipanteDAO'/> para acesso a dados
	/// 
	/// </summary>
	public interface IEventoParticipanteDAO : Regisoft.Camadas.Generic.IBaseDAO<EventoParticipante, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="participante">O(A) participante.</param>
		/// <returns>A lista.</returns>
		IList<EventoParticipante> ListarPorParticipante(Participante participante);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="evento">O(A) evento.</param>
		/// <returns>A lista.</returns>
		IList<EventoParticipante> ListarPorEvento(Evento evento);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="idparticipante"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<EventoParticipante> ListarPor(string idparticipante);
			
	}
}
