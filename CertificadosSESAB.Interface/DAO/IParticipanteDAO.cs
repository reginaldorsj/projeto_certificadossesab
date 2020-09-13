

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.DAO
{
	/// <summary>
	/// Classe <see cref='IParticipanteDAO'/> para acesso a dados
	/// 
	/// </summary>
	public interface IParticipanteDAO : Regisoft.Camadas.Generic.IBaseDAO<Participante, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="nome"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Participante> ListarPor(string nome);
			
	}
}
