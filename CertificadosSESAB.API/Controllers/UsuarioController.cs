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
	/// Controller da classe <see cref='UsuarioController'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	[Authorize]
	public class UsuarioController : ApiController
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="idUnidade">O ID da unidade.</param>
		/// <returns>A lista.</returns>
		[HttpGet]
		[Route("usuario/listarporunidade/{idUnidade}")]
		public IList<CertificadosSESAB.OR.Usuario> ListarPorUnidade(long idUnidade)
		{
			Unidade unidade = BOAccess.getBOFactory().UnidadeBO().SelecionarPorId(idUnidade); 
			return BOAccess.getBOFactory().UsuarioBO().ListarPorUnidade(unidade);
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <returns>A lista.</returns>
		[HttpGet]
		[Route("usuario/listar")]
		public IList<CertificadosSESAB.OR.Usuario> Listar()
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().UsuarioBO().ListarPorUnidade(u.IdUnidade);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		[HttpGet]
		[Route("usuario/selecionarporid/{id}")]
		public CertificadosSESAB.OR.Usuario SelecionarPorId(long id)
		{
			return BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(id);
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		[HttpGet]
		[Route("usuario/listar/{propertyOrder}")]
		public IList<CertificadosSESAB.OR.Usuario> Listar(string propertyOrder)
		{
			return BOAccess.getBOFactory().UsuarioBO().Listar(propertyOrder);
		}
		/// <summary>
		/// Inserir um objeto no banco de dados.
		/// </summary>
		/// <param name="usuario">O(A) usuario.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPost]
		[Route("usuario/inserir")]
		public CertificadosSESAB.OR.Usuario Inserir(CertificadosSESAB.OR.Usuario usuario)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().UsuarioBO().InserirAlterar(u, usuario, Regisoft.Operacao.Incluir);
		}
		/// <summary>
		/// Altera um objeto no banco de dados.
		/// </summary>
		/// <param name="usuario">O(A) usuario.</param>
		/// <returns>O objeto após a persistência.</returns>
		[HttpPut]
		[Route("usuario/alterar")]
		public CertificadosSESAB.OR.Usuario Alterar(CertificadosSESAB.OR.Usuario usuario)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			return BOAccess.getBOFactory().UsuarioBO().InserirAlterar(u, usuario, Regisoft.Operacao.Alterar);
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="usuario">O(A) usuario.</param>
		[HttpDelete]
		[Route("usuario/excluir/{id}")]
		public void Excluir(long id)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			CertificadosSESAB.OR.Usuario usuario = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(id);
			BOAccess.getBOFactory().UsuarioBO().Excluir(u, usuario);
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		[HttpDelete]
		[Route("usuario/excluirlista")]
		public void Excluir(IList<CertificadosSESAB.OR.Usuario> lst)
		{
			CertificadosSESAB.OR.Usuario u = BOAccess.getBOFactory().UsuarioBO().SelecionarPorId(User.Identity.GetUserId());
			BOAccess.getBOFactory().UsuarioBO().Excluir(u, lst);
		}
	}
}
