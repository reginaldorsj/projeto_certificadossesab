

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.DAO
{
	/// <summary>
	/// Classe <see cref='IHistoricoDAO'/> para acesso a dados
	/// 
	/// </summary>
	public interface IHistoricoDAO : Regisoft.Camadas.Generic.IBaseDAO<Historico, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		/// <returns>A lista.</returns>
		IList<Historico> ListarPorEventoParticipante(EventoParticipante eventoparticipante);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="ideventoparticipante"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Historico> ListarPor(string ideventoparticipante);
			
	}
}
