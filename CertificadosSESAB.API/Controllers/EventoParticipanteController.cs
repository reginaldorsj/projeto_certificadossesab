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
	/// Controller da classe <see cref='EventoParticipanteController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class EventoParticipanteController : ApiController
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="participante">O(A) participante.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("eventoparticipante/listarporparticipante")]
		public IList<CertificadosSESAB.OR.EventoParticipante> ListarPorParticipante(Participante participante)
		{
			return BOAccess.getBOFactory().EventoParticipanteBO().ListarPorParticipante(participante);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="evento">O(A) evento.</param>
		/// <returns>A lista.</returns>
		[HttpGet]
		[Route("eventoparticipante/listarporevento/{idEvento}")]
		public IList<CertificadosSESAB.OR.EventoParticipante> ListarPorEvento(long idEvento)
		{
			Evento evento = BOAccess.getBOFactory().EventoBO().SelecionarPorId(idEvento);
			return BOAccess.getBOFactory().EventoParticipanteBO().ListarPorEvento(evento);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("eventoparticipante/selecionarporid/{id}")]
		public CertificadosSESAB.OR.EventoParticipante SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().EventoParticipanteBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("eventoparticipante/listar/{propertyOrder}")]
		public IList<CertificadosSESAB.OR.EventoParticipante> Listar(string propertyOrder)
		{
			return BOAccess.getBOFactory().EventoParticipanteBO().Listar(propertyOrder);
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("eventoparticipante/inserir")]
		public CertificadosSESAB.OR.EventoParticipante Inserir(CertificadosSESAB.OR.EventoParticipante eventoparticipante)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().EventoParticipanteBO().InserirAlterar(u, eventoparticipante, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("eventoparticipante/alterar")]
		public CertificadosSESAB.OR.EventoParticipante Alterar(CertificadosSESAB.OR.EventoParticipante eventoparticipante)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().EventoParticipanteBO().InserirAlterar(u, eventoparticipante, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		[HttpDelete]
		[Route("eventoparticipante/excluir/{id}")]
		public void Excluir(long id)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CertificadosSESAB.OR.EventoParticipante eventoparticipante = BOAccess.getBOFactory().EventoParticipanteBO().SelecionarPorId(id);
			BOAccess.getBOFactory().EventoParticipanteBO().Excluir(u, eventoparticipante);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("eventoparticipante/excluirlista")]
		public void Excluir(IList<CertificadosSESAB.OR.EventoParticipante> lst)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().EventoParticipanteBO().Excluir(u, lst);
		}
	}
}
