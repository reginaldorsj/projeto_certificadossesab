import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FileUploader } from 'ng2-file-upload';
import { environment } from '../../../../environments/environment';

import { EventoService } from '../../../Services/evento.service';
import { MessageService, ConfirmationService } from 'primeng/api';
import { AuthService } from '../../../Shareds/auth.service';

import { Evento } from '../../../Models/evento';

@Component({
  selector: 'app-evento',
  templateUrl: './evento.component.html',
  styleUrls: ['./evento.component.css']
})

export class EventoComponent implements OnInit {

  stringDateLiberacao: string;

  view: string;
  evento: Evento;
  arquivo: string;
  eventos: Evento[];

  uploader: FileUploader = new FileUploader({
    url: `${environment.webapiUrl}evento/certificado`,
    removeAfterUpload: false,
    autoUpload: false,
    authToken: `Bearer ${this.authService.getToken}`
  });

  constructor(private eventoService: EventoService, private messageService: MessageService, private authService: AuthService,
    private confirmationService: ConfirmationService, private router: Router) { }

  ngOnInit(): void {
    let userDetail = this.authService.getUserDetail();
    if (userDetail.idUnidade == 0) {
      this.router.navigate(['/index']);
    }

    this.incluir();
  }

  limparTudo() {
    this.evento = new Evento();
    this.arquivo = undefined;
    this.stringDateLiberacao = undefined;
  }

  incluir(): void {
    this.view = 'editar';
    this.limparTudo();
  }

  localizar(): void {
    this.view = 'localizar';
    this.limparTudo();

    let userDetail = this.authService.getUserDetail();
    this.eventoService.listar(userDetail.idUnidade).subscribe(eventos => {
      this.eventos = eventos;
    });
  }

  gravar(): void {
    if (!this.evento.IdEvento && !this.arquivo) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção', detail: 'Selecione o arquivo do certificado.' });
      return;
    }
    if (this.arquivo && !this.arquivo.toLowerCase().endsWith('.pdf')) {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção', detail: 'Selecione o arquivo do certificado em formato PDF.' });
      return;
    }
    if (this.arquivo)
      this.evento.ArquivoCertificado = this.arquivo.split('\\')[2];

    if (this.evento.IdEvento == undefined) {
      this.eventoService.inserir(this.evento).subscribe(evento => {
        this.evento = evento;
        if (this.arquivo)
          this.uploader.uploadAll();
        this.arquivo = undefined;
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Inclusão realizada com sucesso.' });
        this.preview();
      });
    } else {
      this.eventoService.alterar(this.evento).subscribe(evento => {
        this.evento = evento;
        if (this.arquivo)
          this.uploader.uploadAll();
        this.arquivo = undefined;
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Alteração realizada com sucesso.' });
        this.preview();
      });
    }
  }

  excluir(): void {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão desse registro?',
      accept: () => {
        this.eventoService.excluir(this.evento.IdEvento).subscribe(() => {
          this.incluir();
          this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Exclusão realizada com sucesso.' });
        });
      }
    });
  }

  select(evento: Evento): void {
    this.view = 'editar';
    this.evento = evento;
    this.stringDateLiberacao = this.evento.DataLiberacaoDocumento.toLocaleDateString('pt-BR');
  }

  recebeDataLiberacao(date: Date): void {
    if (date)
      this.stringDateLiberacao = date.toLocaleString('pt-BR').substring(0, 16);
    else
      this.stringDateLiberacao = undefined;
    this.evento.DataLiberacaoDocumento = date;
  }

  preview(): void {
    this.eventoService.previewCertificado(this.evento.IdEvento).subscribe(arquivoPdf => {
      const blob = new Blob([arquivoPdf], { type: 'application/pdf' });
      const url = window.URL.createObjectURL(blob);
      window.open(url);
    }, (error: any) => {
      if (error.blob) {
        const fr = new FileReader();
        fr.onloadend = (e => {
          const errorObj = JSON.parse(fr.result as string);
          this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: errorObj.Message });
        });
        fr.readAsText(error.blob, 'utf-8');
      } else {
        this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: error.message });
      }
    });
  }
}
