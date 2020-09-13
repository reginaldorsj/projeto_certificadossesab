import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

import { MessageService, ConfirmationService } from 'primeng/api';
import { AuthService } from '../../../Shareds/auth.service';
import { UsuarioService } from '../../../Services/usuario.service';

import { Usuario } from '../../../Models/usuario';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  view: string = "browse";
  usuario: Usuario;

  usuarios: Usuario[];
  viewAtualizar: boolean = false;

  constructor(private usuarioService: UsuarioService, private authService: AuthService, private router: Router,
    private messageService: MessageService, private confirmationService: ConfirmationService) { }

  ngOnInit(): void {
    let userDatail = this.authService.getUserDetail();
    if (userDatail.idUnidade == 0) {
      this.router.navigate(['/index']);
    }

    this.atualizar();
    this.usuario = new Usuario();
  }

  atualizar(): void {
    this.viewAtualizar = true;
    this.usuarioService.listar().subscribe(usuarios => {
      this.usuarios = usuarios;
      this.viewAtualizar = false;
    });
  }

  desistir(): void {
    this.view = "browse";

    this.atualizar();
  }

  inserir(): void {
    this.view = "insert";
    this.usuario = new Usuario();
  }

  gravar(): void {
    if (!this.usuario.IdUsuario) {
      this.usuarioService.inserir(this.usuario).subscribe(usuario => {
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Inclusão realizada com sucesso.' });
        this.atualizar();
        this.desistir();
      });
    } else {
      this.usuarioService.alterar(this.usuario).subscribe(usuario => {
        this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Alteração realizada com sucesso.' });
        this.atualizar();
        this.desistir();
      });
    }
  }

  excluir(usuario: Usuario) {
    this.confirmationService.confirm({
      message: 'Confirma a exclusão?',
      rejectLabel: "Não",
      acceptLabel: "Sim",
      accept: () => {
        this.usuarioService.excluir(usuario.IdUsuario).subscribe(() => {
          this.atualizar();
        });
      }
    });
  }
  alterar(usuario: Usuario) {
    this.view = "insert";
    this.usuario = usuario;
  }
}
