import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';

import { Participante } from '../Models/participante';
import { Evento } from '../Models/evento';


@Injectable({
  providedIn: 'root'
})
export class ParticipanteService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }

  selecionarPorCpf(cpf: string): Observable<Participante> {
    return this.http
      .get(`${environment.webapiUrl}participante/selecionarporcpf/${cpf}`)
      .pipe(
        map((data: any) => {
          if (data == null)
            return null;

          let x: Participante = new Participante();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  listar(evento: Evento): Observable<Participante[]> {
    return this.http
      .get(`${environment.webapiUrl}participante/listarporevento/${evento.IdEvento}`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Participante = new Participante();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  inserir(evento: Evento, participante: Participante): Observable<Participante> {
    return this.http
      .post(`${environment.webapiUrl}participante/inserir/${evento.IdEvento}`, participante)
      .pipe(
        map((data: any) => {
          let x: Participante = new Participante();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  alterar(evento: Evento, participante: Participante): Observable<Participante> {
    return this.http
      .put(`${environment.webapiUrl}participante/alterar/${evento.IdEvento}`, participante)
      .pipe(
        map((data: any) => {
          let x: Participante = new Participante();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  excluir(evento: Evento, id: number): Observable<any> {
    return this.http
      .delete(`${environment.webapiUrl}participante/excluir/${evento.IdEvento}/${id}`)
      .pipe(catchError((e) => this.errorHandler(e)));
  }
}

