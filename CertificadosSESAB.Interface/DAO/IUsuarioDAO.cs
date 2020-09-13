

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.DAO
{
	/// <summary>
	/// Classe <see cref='IUsuarioDAO'/> para acesso a dados
	/// 
	/// </summary>
	public interface IUsuarioDAO : Regisoft.Camadas.Generic.IBaseDAO<Usuario, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="unidade">O(A) unidade.</param>
		/// <returns>A lista.</returns>
		IList<Usuario> ListarPorUnidade(Unidade unidade);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="idunidade"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Usuario> ListarPor(string idunidade);
			
	}
}
