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
	/// Controller da classe <see cref='HistoricoController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class HistoricoController : ApiController
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="eventoparticipante">O(A) eventoparticipante.</param>
		/// <returns>A lista.</returns>
		[HttpPost]
		[Route("historico/listarporeventoparticipante")]
		public IList<CertificadosSESAB.OR.Historico> ListarPorEventoParticipante(EventoParticipante eventoparticipante)
		{
			return BOAccess.getBOFactory().HistoricoBO().ListarPorEventoParticipante(eventoparticipante);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("historico/selecionarporid/{id}")]
		public CertificadosSESAB.OR.Historico SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().HistoricoBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("historico/listar/{propertyOrder}")]
		public IList<CertificadosSESAB.OR.Historico> Listar(string propertyOrder)
		{
			return BOAccess.getBOFactory().HistoricoBO().Listar(propertyOrder);
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="historico">O(A) historico.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("historico/inserir")]
		public CertificadosSESAB.OR.Historico Inserir(CertificadosSESAB.OR.Historico historico)
		{
			return BOAccess.getBOFactory().HistoricoBO().InserirAlterar(historico, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="historico">O(A) historico.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("historico/alterar")]
		public CertificadosSESAB.OR.Historico Alterar(CertificadosSESAB.OR.Historico historico)
		{
			return BOAccess.getBOFactory().HistoricoBO().InserirAlterar(historico, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="historico">O(A) historico.</param>
		[HttpDelete]
		[Route("historico/excluir/{id}")]
		public void Excluir(long id)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CertificadosSESAB.OR.Historico historico = BOAccess.getBOFactory().HistoricoBO().SelecionarPorId(id);
			BOAccess.getBOFactory().HistoricoBO().Excluir(u, historico);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("historico/excluirlista")]
		public void Excluir(IList<CertificadosSESAB.OR.Historico> lst)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().HistoricoBO().Excluir(u, lst);
		}
	}
}
