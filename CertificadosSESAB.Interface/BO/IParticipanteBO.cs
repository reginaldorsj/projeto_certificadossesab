

using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.BO
{
	/// <summary>
	/// Regras de negócio para gerenciamento da classe <see cref='IParticipanteBO'/>
	/// 
	/// </summary>
	public interface IParticipanteBO : IDisposable
	{
		/// <summary>
		/// Selecionar objeto.
		/// </summary>
		/// <param name="id">O id.</param>
		/// <returns></returns>
		CertificadosSESAB.OR.Participante SelecionarPorId(object id);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="propertyOrder">A propriedade ordem.</param>
		/// <returns>A lista ordenada.</returns>
		System.Collections.Generic.IList<CertificadosSESAB.OR.Participante> Listar(string propertyOrder);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		CertificadosSESAB.OR.Participante SelecionarPor(string propertyName, object value);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		CertificadosSESAB.OR.Participante SelecionarPor(string propertyName1, object value1,string propertyName2, object value2);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		CertificadosSESAB.OR.Participante SelecionarPor(string[] propertyName, object[] value);
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		DataTable ToDataTable(IList<CertificadosSESAB.OR.Participante> lst);
        /// <summary>
        /// Insere ou altera um objeto no banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="participante">O(A) participante.</param>
        /// <param name="op">A operação.</param>
        /// <param name="evento">O evento.</param>
        /// <returns>O objeto após a persistência.</returns>
        CertificadosSESAB.OR.Participante InserirAlterar(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Participante participante, Regisoft.Operacao op, Evento evento);
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="participante">O(A) participante.</param>
        /// <param name="evento">O evento.</param>
        void Excluir(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Participante participante, Evento evento);
        /// <summary>
        /// Exclui uma lista de objeto do banco de dados.
        /// </summary>
        /// <param name="u">O usuário.</param>
        /// <param name="lst">A lista.</param>
        /// <param name="evento">O evento.</param>
        void Excluir(CertificadosSESAB.OR.Usuario u, IList<CertificadosSESAB.OR.Participante> lst, Evento evento);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Participante> ListarPor(string dado);
					
	}
}
