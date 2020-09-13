

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.DAO
{
	/// <summary>
	/// Classe <see cref='IUnidadeDAO'/> para acesso a dados
	/// 
	/// </summary>
	public interface IUnidadeDAO : Regisoft.Camadas.Generic.IBaseDAO<Unidade, long>
	{
        IList<Unidade> ListarAtivos();
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="nome"> O dado para pesquisa.</param>
        /// <returns>A lista.</returns>
        IList<Unidade> ListarPor(string nome);
			
	}
}
