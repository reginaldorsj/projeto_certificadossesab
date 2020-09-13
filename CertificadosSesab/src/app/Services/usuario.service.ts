import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, catchError } from 'rxjs/operators';

import { ModelService } from '../Models/model.service';
import { MessageService } from 'primeng/api';

import { Usuario } from '../Models/usuario';
import { Unidade } from '../Models/unidade';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient, private model: ModelService, private messageService: MessageService) { }

  errorHandler(e: any): Observable<any> {
    const msgErro: string = e.message;
    this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro interno!', detail: msgErro });
    return EMPTY;
  }
  listarPorUnidade(unidade: Unidade): Observable<Usuario[]> {
    return this.http
      .get(`${environment.webapiUrl}usuario/listarporunidade/${unidade.IdUnidade}`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Usuario = new Usuario();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  listar(): Observable<Usuario[]> {
    return this.http
      .get(`${environment.webapiUrl}usuario/listar`)
      .pipe(
        map((data: any[]) =>
          data.map((item: any) => {
            let x: Usuario = new Usuario();
            this.model.deepCopy(item, x);
            return x
          })
        ), catchError((e) => this.errorHandler(e))
      );
  }
  inserir(usuario: Usuario): Observable<Usuario> {
    return this.http
      .post(`${environment.webapiUrl}usuario/inserir`, usuario)
      .pipe(
        map((data: any) => {
          let x: Usuario = new Usuario();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  alterar(usuario: Usuario): Observable<Usuario> {
    return this.http
      .put(`${environment.webapiUrl}usuario/alterar`, usuario)
      .pipe(
        map((data: any) => {
          let x: Usuario = new Usuario();
          this.model.deepCopy(data, x);
          return x
        }), catchError((e) => this.errorHandler(e))
      );
  }
  excluir(id: number): Observable<any> {
    return this.http
      .delete(`${environment.webapiUrl}usuario/excluir/${id}`)
      .pipe(catchError((e) => this.errorHandler(e)));
  }
  alterarSenha(login: string, senha: string, novaSenha: string): Observable<Usuario> {
    return this.http
      .put(`${environment.webapiUrl}usuario/alterarsenha/${login}/${senha}/${novaSenha}`, null)
      .pipe(
        map((item: any) => {
          let x: Usuario = new Usuario();
          this.model.deepCopy(item, x);
          return x
        }), catchError((e) => { throw e })
      );
  }


}

