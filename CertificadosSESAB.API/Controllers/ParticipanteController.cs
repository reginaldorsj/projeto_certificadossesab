using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using CertificadosSESAB.OR;

namespace CertificadosSESAB.API
{
	/// <summary>
	/// Controller da classe <see cref='ParticipanteController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class ParticipanteController : ApiController
	{


		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("participante/selecionarporid/{id}")]
		public CertificadosSESAB.OR.Participante SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().ParticipanteBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("participante/listar/{propertyOrder}")]
		public IList<CertificadosSESAB.OR.Participante> Listar(string propertyOrder)
		{
			return BOAccess.getBOFactory().ParticipanteBO().Listar(propertyOrder);
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="participante">O(A) participante.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("participante/inserir/{idEvento}")]
		public CertificadosSESAB.OR.Participante Inserir(CertificadosSESAB.OR.Participante participante, long idEvento)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			Evento evento = BOAccess.getBOFactory().EventoBO().SelecionarPorId(idEvento);
			return BOAccess.getBOFactory().ParticipanteBO().InserirAlterar(u, participante, Regisoft.Operacao.Incluir, evento);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="participante">O(A) participante.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("participante/alterar/{idEvento}")]
		public CertificadosSESAB.OR.Participante Alterar(CertificadosSESAB.OR.Participante participante, long idEvento)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			Evento evento = BOAccess.getBOFactory().EventoBO().SelecionarPorId(idEvento);
			return BOAccess.getBOFactory().ParticipanteBO().InserirAlterar(u, participante, Regisoft.Operacao.Alterar, evento);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="participante">O(A) participante.</param>
		[HttpDelete]
		[Route("participante/excluir/{idEvento}/{id}")]
		public void Excluir(long id, long idEvento)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CertificadosSESAB.OR.Participante participante = BOAccess.getBOFactory().ParticipanteBO().SelecionarPorId(id);
			Evento evento = BOAccess.getBOFactory().EventoBO().SelecionarPorId(idEvento);
			BOAccess.getBOFactory().ParticipanteBO().Excluir(u, participante, evento);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("participante/excluirlista/{idEvento}")]
		public void Excluir(IList<CertificadosSESAB.OR.Participante> lst, long idEvento)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			Evento evento = BOAccess.getBOFactory().EventoBO().SelecionarPorId(idEvento);
			BOAccess.getBOFactory().ParticipanteBO().Excluir(u, lst,evento);
		}
	}
}
