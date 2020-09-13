using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CertificadosSESAB.OR;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Net.Http.Headers;
using System.Web;
using System.Threading;

namespace CertificadosSESAB.API.Controllers
{
    public class DiversosController : ApiController
    {
		[HttpGet]
		[Route("evento/previewcertificado/{id}")]
		public HttpResponseMessage PreviewCertificado(long id)
		{
			Evento evento = BOAccess.getBOFactory().EventoBO().SelecionarPorId(id);
			if (evento == null)
            {
				var message = "Evento não identificado.";
				throw new HttpResponseException(
					Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
			}
			var context = System.Web.HttpContext.Current;
			var filePath = context.Server.MapPath("~/Documentos/" + evento.ArquivoCertificado);

			if (!File.Exists(filePath))
				Thread.Sleep(2000);

			if (!File.Exists(filePath))
			{
				var message = "Arquivo '" + evento.ArquivoCertificado + "' não encontrado.";
				throw new HttpResponseException(
					Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
			}
			byte[] document = Documento.Gerar("Lorem Ipsum Dolor Sit Amet Consectetur".ToUpper(), filePath, evento.X, evento.Y);
			return getHttpResponseMessage(document, evento.ArquivoCertificado);
		}
		[HttpGet]
		[Route("evento/previewcertificado/{idEvento}/{idParticipante}")]
		public HttpResponseMessage PreviewCertificado(long idEvento, long idParticipante)
		{
			Evento evento = BOAccess.getBOFactory().EventoBO().SelecionarPorId(idEvento);
			if (evento == null)
			{
				var message = "Evento não identificado.";
				throw new HttpResponseException(
					Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
			}
			Participante participante = BOAccess.getBOFactory().ParticipanteBO().SelecionarPorId(idParticipante);
			if (participante == null)
			{
				var message = "Participante não identificado.";
				throw new HttpResponseException(
					Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
			}
			EventoParticipante ep = BOAccess.getBOFactory().EventoParticipanteBO().SelecionarPor("IdEvento", evento, "IdParticipante", participante);
			if (ep == null)
			{
				var message = "Evento/Participante não encontrado.";
				throw new HttpResponseException(
					Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
			}

			var context = System.Web.HttpContext.Current;
			var filePath = context.Server.MapPath("~/Documentos/" + evento.ArquivoCertificado);
			if (!File.Exists(filePath))
			{
				var message = "Arquivo '" + evento.ArquivoCertificado + "' não encontrado.";
				throw new HttpResponseException(
					Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
			}
			byte[] document = Documento.Gerar(ep.IdParticipante.Nome, filePath, evento.X, evento.Y);
			return getHttpResponseMessage(document, evento.ArquivoCertificado);
		}

		[HttpGet]
		[Route("participante/selecionarporcpf/{cpf}")]
		public Participante SelecionarPorCpf(string cpf)
		{ 
			return BOAccess.getBOFactory().ParticipanteBO().SelecionarPor("Cpf", cpf);
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="unidade">O(A) unidade.</param>
		/// <returns>A lista.</returns>
		[HttpGet]
		[Route("evento/listarporunidade/{idUnidade}")]
		public IList<Evento> ListarPorUnidade(long idUnidade)
        {
			Unidade unidade = BOAccess.getBOFactory().UnidadeBO().SelecionarPorId(idUnidade);
			if (unidade == null)
				return new List<Evento>();

			return BOAccess.getBOFactory().EventoBO().ListarPorUnidade(unidade);
        }

		[HttpGet]
		[Route("unidade/listar")]
		public IList<Unidade> ListarAtivos()
        {
			return BOAccess.getBOFactory().UnidadeBO().ListarAtivos();
        }
		[HttpPut]
		[Route("usuario/alterarsenha/{login}/{senha}/{novaSenha}")]
		public HttpResponseMessage AlterarSenha(string login, string senha, string novaSenha)
		{
			Usuario usuario = BOAccess.getBOFactory().UsuarioBO().SelecionarPor("Login", login);
			if (usuario == null || usuario.Senha != senha)
			{
				var message = "Usuário não identificado.";
				throw new HttpResponseException(
					Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
			}

			BOAccess.getBOFactory().UsuarioBO().AlterarSenha(usuario, novaSenha);
			return new HttpResponseMessage(HttpStatusCode.OK);

		}
		private HttpResponseMessage getHttpResponseMessage(byte[] bytes, string docFile)
		{
			//Create HTTP Response.  
			HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
			//Set the Response Content.  
			response.Content = new ByteArrayContent(bytes);
			//Set the Response Content Length.  
			response.Content.Headers.ContentLength = bytes.LongLength;
			//Set the Content Disposition Header Value and FileName.  
			response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
			response.Content.Headers.ContentDisposition.FileName = docFile;
			//Set the File Content Type.  
			response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(docFile));
			return response;
		}
	}
}
