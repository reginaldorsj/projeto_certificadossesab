

using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.BO
{
	/// <summary>
	/// Regras de neg�cio para gerenciamento da classe <see cref='IEventoBO'/>
	/// 
	/// </summary>
	public interface IEventoBO : IDisposable
	{
		/// <summary>
		/// Selecionar objeto.
		/// </summary>
		/// <param name="id">O id.</param>
		/// <returns></returns>
		CertificadosSESAB.OR.Evento SelecionarPorId(object id);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="propertyOrder">A propriedade ordem.</param>
		/// <returns>A lista ordenada.</returns>
		System.Collections.Generic.IList<CertificadosSESAB.OR.Evento> Listar(string propertyOrder);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na sele��o.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		CertificadosSESAB.OR.Evento SelecionarPor(string propertyName, object value);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na sele��o.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na sele��o.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		CertificadosSESAB.OR.Evento SelecionarPor(string propertyName1, object value1,string propertyName2, object value2);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na sele��o.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		CertificadosSESAB.OR.Evento SelecionarPor(string[] propertyName, object[] value);
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		DataTable ToDataTable(IList<CertificadosSESAB.OR.Evento> lst);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="unidade">O(A) unidade.</param>
		/// <returns>A lista.</returns>
		IList<CertificadosSESAB.OR.Evento> ListarPorUnidade(CertificadosSESAB.OR.Unidade unidade);
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usu�rio.</param>
		/// <param name="evento">O(A) evento.</param>
		/// <param name="op">A opera��o.</param>
		/// <returns>O objeto ap�s a persist�ncia.</returns>
		CertificadosSESAB.OR.Evento InserirAlterar(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Evento evento, Regisoft.Operacao op);
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usu�rio.</param>
		/// <param name="evento">O(A) evento.</param>
		void Excluir(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.Evento evento);
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usu�rio.</param>
		/// <param name="lst">A lista.</param>
		void Excluir(CertificadosSESAB.OR.Usuario u, IList<CertificadosSESAB.OR.Evento> lst);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Evento> ListarPor(string dado);
					
	}
}
