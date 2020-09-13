import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';

import { Evento } from '../Models/evento';
import { Participante } from '../Models/participante';


@Injectable({
  providedIn: 'root'
})
export class EventoService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }

  previewCertificado(id: number): Observable<Blob> {
    return this.http
      .get(`${environment.webapiUrl}evento/previewcertificado/${id}`, { responseType: 'blob' })
      .pipe(
        map((data: any) => {
          return data;
        }), catchError((e) => { throw e })
      );
  }
  previewCertificadoParticipante(id: number, participante: Participante): Observable<Blob> {
    return this.http
      .get(`${environment.webapiUrl}evento/previewcertificado/${id}/${participante.IdParticipante}`, { responseType: 'blob' })
      .pipe(
        map((data: any) => {
          return data;
        }), catchError((e) => { throw e })
      );
  }

  listar(idUnidade:number): Observable<Evento[]> {
    return this.http
      .get(`${environment.webapiUrl}evento/listarporunidade/${idUnidade}`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Evento = new Evento();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  inserir(evento: Evento): Observable<Evento> {
    return this.http
      .post(`${environment.webapiUrl}evento/inserir`, this.updateTimeZone(evento))
      .pipe(
        map((data: any) => {
          let x: Evento = new Evento();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  alterar(evento: Evento): Observable<Evento> {
    return this.http
      .put(`${environment.webapiUrl}evento/alterar`, this.updateTimeZone(evento))
      .pipe(
        map((data: any) => {
          let x: Evento = new Evento();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  excluir(id: number): Observable<any> {
    return this.http
      .delete(`${environment.webapiUrl}evento/excluir/${id}`)
      .pipe(catchError((e) => this.errorHandler(e)));
  }
  private updateTimeZone(evento: Evento): Evento {
    evento.DataLiberacaoDocumento = this.model.convertTimeZone(evento.DataLiberacaoDocumento);
    return evento;
  }

}

