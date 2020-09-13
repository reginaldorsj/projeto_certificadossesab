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
	/// Controller da classe <see cref='UnidadeController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class UnidadeController : ApiController
	{
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("unidade/selecionarporid/{id}")]
		public CertificadosSESAB.OR.Unidade SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().UnidadeBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("unidade/listar/{propertyOrder}")]
		public IList<CertificadosSESAB.OR.Unidade> Listar(string propertyOrder)
		{
			return BOAccess.getBOFactory().UnidadeBO().Listar(propertyOrder);
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="unidade">O(A) unidade.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("unidade/inserir")]
		public CertificadosSESAB.OR.Unidade Inserir(CertificadosSESAB.OR.Unidade unidade)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().UnidadeBO().InserirAlterar(u, unidade, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="unidade">O(A) unidade.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("unidade/alterar")]
		public CertificadosSESAB.OR.Unidade Alterar(CertificadosSESAB.OR.Unidade unidade)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().UnidadeBO().InserirAlterar(u, unidade, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="unidade">O(A) unidade.</param>
		[HttpDelete]
		[Route("unidade/excluir/{id}")]
		public void Excluir(long id)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CertificadosSESAB.OR.Unidade unidade = BOAccess.getBOFactory().UnidadeBO().SelecionarPorId(id);
			BOAccess.getBOFactory().UnidadeBO().Excluir(u, unidade);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("unidade/excluirlista")]
		public void Excluir(IList<CertificadosSESAB.OR.Unidade> lst)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().UnidadeBO().Excluir(u, lst);
		}
	}
}
