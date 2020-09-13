

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.DAO
{
	/// <summary>
	/// Classe <see cref='IEventoDAO'/> para acesso a dados
	/// 
	/// </summary>
	public interface IEventoDAO : Regisoft.Camadas.Generic.IBaseDAO<Evento, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="unidade">O(A) unidade.</param>
		/// <returns>A lista.</returns>
		IList<Evento> ListarPorUnidade(Unidade unidade);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="idunidade"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Evento> ListarPor(string idunidade);
			
	}
}
