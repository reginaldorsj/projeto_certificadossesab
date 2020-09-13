import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';

import { EventoParticipante } from '../Models/evento-participante';
import { Evento } from '../Models/evento';


@Injectable({
  providedIn: 'root'
})
export class EventoParticipanteService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }

  listar(evento: Evento): Observable<EventoParticipante[]> {
    return this.http
      .get(`${environment.webapiUrl}eventoparticipante/listarporevento/${evento.IdEvento}`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: EventoParticipante = new EventoParticipante();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
}
