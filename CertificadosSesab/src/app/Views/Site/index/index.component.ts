import { Component, OnInit } from '@angular/core';

import { MessageService } from 'primeng/api';
import { AuthService } from '../../../Shareds/auth.service';
import { UnidadeService } from '../../../Services/unidade.service';
import { ParticipanteService } from '../../../Services/participante.service';

import { Evento } from '../../../Models/evento';
import { Unidade } from '../../../Models/unidade';
import { EventoService } from '../../../Services/evento.service';
import { element } from 'protractor';
import { Participante } from '../../../Models/participante';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  carregando: boolean;

  unidades = [];
  selectedUnidade: Unidade;

  eventos = [];
  selectedEvento: Evento;

  cpf: string;

  constructor(private authService: AuthService, private unidadeService: UnidadeService, private eventoService: EventoService,
    private messageService: MessageService, private participanteService: ParticipanteService) { }

  ngOnInit(): void {
    this.authService.logout();

    this.unidadeService.listarAtivos().subscribe(unidades => {
      unidades.forEach(unidade => {
        this.unidades.push({ 'label': unidade.Descricao, 'value': unidade });
      })
    })
  }

  carregaEventos(): void {
    this.eventos = [];
    this.selectedEvento = undefined;

    if (this.selectedUnidade == null) {
      return;
    }
    this.eventoService.listar(this.selectedUnidade.IdUnidade).subscribe(eventos => {
      if (eventos.length != 0) {
        eventos.forEach(evento => {
          this.eventos.push({ 'label': evento.Nome, 'value': evento });
        });
      } else {
        this.eventos = [];
      }
    });
  }

  gerar(): void {
    this.carregando = true;

    var promise = new Promise((resolve, reject) => {
      this.participanteService.selecionarPorCpf(this.cpf).subscribe(participante => {
        if (participante == null) {
          reject();
        } else {
          resolve(participante);
        }
      });
    })
    promise.then((participante: Participante) => {
      this.eventoService.previewCertificadoParticipante(this.selectedEvento.IdEvento, participante).subscribe(arquivoPdf => {
        const blob = new Blob([arquivoPdf], { type: 'application/pdf' });
        const url = window.URL.createObjectURL(blob);
        this.carregando = false;
        window.open(url);
      }, (error: any) => {
        if (error.blob) {
          const fr = new FileReader();
          fr.onloadend = (e => {
            const errorObj = JSON.parse(fr.result as string);
            this.carregando = false;
            this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: errorObj.Message });
          });
          fr.readAsText(error.blob, 'utf-8');
        } else {
          this.carregando = false;
          this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: error.message });
        }
      });
    }).catch(() => {
      this.carregando = false;
      this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: 'Nenhum participante encontrado com este CPF.' });
    });
  }
}
