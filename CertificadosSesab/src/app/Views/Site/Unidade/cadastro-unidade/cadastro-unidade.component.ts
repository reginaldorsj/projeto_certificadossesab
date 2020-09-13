import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../../Shareds/auth.service';
import { Router } from '@angular/router';

import { MessageService, ConfirmationService } from 'primeng/api';
import { UnidadeService } from '../../../../Services/unidade.service';
import { UsuarioService } from '../../../../Services/usuario.service';

import { Unidade } from '../../../../Models/unidade';
import { Usuario } from '../../../../Models/usuario';

@Component({
  selector: 'app-cadastro-unidade',
  templateUrl: './cadastro-unidade.component.html',
  styleUrls: ['./cadastro-unidade.component.css']
})
export class CadastroUnidadeComponent implements OnInit {

  view: string;
  unidade: Unidade;
  unidades: Unidade[];

  viewUsuario: string;
  usuario: Usuario;
  usuarios: Usuario[];

  constructor(private auth: AuthService, private router: Router, private unidadeService: UnidadeService,
    private messageService: MessageService, private confirmationService: ConfirmationService,
    private usuarioService: UsuarioService) { }

  ngOnInit(): void {
    let userDatail = this.auth.getUserDetail();
    if (userDatail.idUnidade != 0) {
      this.sair();
    }

    this.incluir();
  }
  limparTudo() {
    this.unidade = new Unidade();
  }

  incluir(): void {
    this.view = 'incluir';
    this.limparTudo();
  }

  localizar(): void {
    this.view = 'localizar';
    this.limparTudo();

    this.unidadeService.listar().subscribe(unidades => {
      this.unidades = unidades;
    });
  }

  select(unidade: Unidade) {
    this.view = 'incluir';
    this.unidade = unidade;
    this.usuarioService.listarPorUnidade(unidade).subscribe(usuarios => {
      this.viewUsuario = 'listar';
      this.usuarios = usuarios
    });
  }

  sair(): void {
    this.router.navigate(['/index']);
  }

  gravar(): void {
    if (this.unidade.IdUnidade == undefined) {
      this.unidadeService.inserir(this.unidade).subscribe(unidade => {
        this.unidade = unidade;
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Inclusão realizada com sucesso.' });
      });
    } else {
      this.unidadeService.alterar(this.unidade).subscribe(unidade => {
        this.unidade = unidade;
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Alteração realizada com sucesso.' });
      });
    }
  }

  excluir(): void {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão desse registro?',
      accept: () => {
        this.unidadeService.excluir(this.unidade.IdUnidade).subscribe(() => {
          this.incluir();
          this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Exclusão realizada com sucesso.' });
        });
      }
    });
  }

  inserirUsuario(): void {
    this.viewUsuario = 'editar';
    this.usuario = new Usuario();
  }

  selectUsuario(usuario: Usuario): void {
    this.viewUsuario = 'editar';
    this.usuario = usuario;
  }

  deleteUsuario(usuario: Usuario): void {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão desse registro?',
      accept: () => {
        this.usuarioService.excluir(usuario.IdUsuario).subscribe(() => {
          this.select(this.unidade);
          this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Exclusão realizada com sucesso.' });
        });
      }
    });
  }

  desistirUsuario(): void {
    this.viewUsuario = 'listar';
  }

  gravarUsuario(): void {
    this.usuario.Unidade = this.unidade;
    if (this.usuario.IdUsuario == undefined) {
      this.usuarioService.inserir(this.usuario).subscribe(usuario => {
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Inclusão realizada com sucesso.' });
        this.select(this.unidade);
        this.viewUsuario = 'listar';
      });
    } else {
      this.usuarioService.alterar(this.usuario).subscribe(usuario => {
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Parabéns', detail: 'Alteração realizada com sucesso.' });
        this.select(this.unidade);
        this.viewUsuario = 'listar';
      });
    }
  }
}
