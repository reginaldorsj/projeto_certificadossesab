import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';

import { Unidade } from '../Models/unidade';


@Injectable({
  providedIn: 'root'
})
export class UnidadeService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }
  listarAtivos(): Observable<Unidade[]> {
    return this.http
      .get(`${environment.webapiUrl}unidade/listar`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Unidade = new Unidade();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  listar(): Observable<Unidade[]> {
    return this.http
      .get(`${environment.webapiUrl}unidade/listar/Descricao`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Unidade = new Unidade();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  inserir(unidade: Unidade): Observable<Unidade> {
    return this.http
      .post(`${environment.webapiUrl}unidade/inserir`, unidade)
      .pipe(
        map((data: any) => {
          let x: Unidade = new Unidade();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  alterar(unidade: Unidade): Observable<Unidade> {
    return this.http
      .put(`${environment.webapiUrl}unidade/alterar`, unidade)
      .pipe(
        map((data: any) => {
          let x: Unidade = new Unidade();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  excluir(id: number): Observable<any> {
    return this.http
      .delete(`${environment.webapiUrl}unidade/excluir/${id}`)
      .pipe(catchError((e) => this.errorHandler(e)));
  }
}

