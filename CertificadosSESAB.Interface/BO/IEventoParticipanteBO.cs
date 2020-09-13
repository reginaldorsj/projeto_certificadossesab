

using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.BO
{
	/// <summary>
	/// Regras de negócio para gerenciamento da classe <see cref='IEventoParticipanteBO'/>
	/// 
	/// </summary>
	public interface IEventoParticipanteBO : IDisposable
	{
		/// <summary>
		/// Selecionar objeto.
		/// </summary>
		/// <param name="id">O id.</param>
		/// <returns></returns>
		CertificadosSESAB.OR.EventoParticipante SelecionarPorId(object id);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="propertyOrder">A propriedade ordem.</param>
		/// <returns>A lista ordenada.</returns>
		System.Collections.Generic.IList<CertificadosSESAB.OR.EventoParticipante> Listar(string propertyOrder);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		CertificadosSESAB.OR.EventoParticipante SelecionarPor(string propertyName, object value);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		CertificadosSESAB.OR.EventoParticipante SelecionarPor(string propertyName1, object value1,string propertyName2, object value2);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		CertificadosSESAB.OR.EventoParticipante SelecionarPor(string[] propertyName, object[] value);
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		DataTable ToDataTable(IList<CertificadosSESAB.OR.EventoParticipante> lst);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="participante">O(A) participante.</param>
		/// <returns>A lista.</returns>
		IList<CertificadosSESAB.OR.EventoParticipante> ListarPorParticipante(CertificadosSESAB.OR.Participante participante);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="evento">O(A) evento.</param>
		/// <returns>A lista.</returns>
		IList<CertificadosSESAB.OR.EventoParticipante> ListarPorEvento(CertificadosSESAB.OR.Evento evento);
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		CertificadosSESAB.OR.EventoParticipante InserirAlterar(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.EventoParticipante eventoparticipante, Regisoft.Operacao op);
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		void Excluir(CertificadosSESAB.OR.Usuario u, CertificadosSESAB.OR.EventoParticipante eventoparticipante);
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="u">O usuário.</param>
		/// <param name="lst">A lista.</param>
		void Excluir(CertificadosSESAB.OR.Usuario u, IList<CertificadosSESAB.OR.EventoParticipante> lst);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<EventoParticipante> ListarPor(string dado);
					
	}
}
