import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { MessageService, ConfirmationService } from 'primeng/api';

import { EventoParticipanteService } from '../../../Services/evento-participante.service';
import { EventoService } from '../../../Services/evento.service';
import { ParticipanteService } from '../../../Services/participante.service';

import { Participante } from '../../../Models/participante';
import { AuthService } from '../../../Shareds/auth.service';
import { Evento } from '../../../Models/evento';

@Component({
  selector: 'app-participante',
  templateUrl: './participante.component.html',
  styleUrls: ['./participante.component.css']
})
export class ParticipanteComponent implements OnInit {

  view: string;
  participante: Participante;
  participantes: Participante[]

  eventos = [];
  selectedEvento;

  constructor(private participanteService: ParticipanteService, private messageService: MessageService, private authService: AuthService,
    private confirmationService: ConfirmationService, private router: Router, private eventoService: EventoService,
    private eventoParticipanteService: EventoParticipanteService) { }

  ngOnInit(): void {
    let userDatail = this.authService.getUserDetail();
    if (userDatail.idUnidade == 0) {
      this.router.navigate(['/index']);
    }

    this.eventoService.listar(userDatail.idUnidade).subscribe(eventos => {
      eventos.forEach((evento) => {
        this.eventos.push({ "label": evento.Nome, "value": evento })
      });
    });

    this.incluir();
  }

  limparTudo() {
    this.participante = new Participante();
    this.participantes = [];
  }

  incluir(): void {
    this.view = 'editar';
    this.limparTudo();
  }

  localizar(): void {
    this.view = 'localizar';
    this.limparTudo();
  }

  confirmaLocalizacao(): void {
    this.eventoParticipanteService.listar(this.selectedEvento).subscribe(eventoparticipantes => {
      eventoparticipantes.forEach(eventoParticipante => this.participantes.push(eventoParticipante.Participante));
    });
  }

  gravar(): void {
    if (this.participante.IdParticipante == undefined) {
      this.participanteService.inserir(this.selectedEvento, this.participante).subscribe(participante => {
        this.participante = participante;
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Inclusão realizada com sucesso.' });
      });
    } else {
      this.participanteService.alterar(this.selectedEvento, this.participante).subscribe(participante => {
        this.participante = participante;
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Alteração realizada com sucesso.' });
      });
    }
  }

  excluir(): void {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão desse registro?',
      accept: () => {
        this.participanteService.excluir(this.selectedEvento, this.participante.IdParticipante).subscribe(() => {
          this.incluir();
          this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Exclusão realizada com sucesso.' });
        });
      }
    });
  }

  select(participante: Participante): void {
    this.view = 'editar';
    this.participante = participante;
  }

  preview(participante: Participante): void {
    this.eventoService.previewCertificadoParticipante(this.selectedEvento.IdEvento, participante).subscribe(arquivoPdf => {
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
