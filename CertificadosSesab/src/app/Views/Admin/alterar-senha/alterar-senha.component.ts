import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UsuarioService } from '../../../Services/usuario.service';
import { MessageService } from 'primeng/api/';
import { AuthService } from '../../../Shareds/auth.service';

@Component({
  selector: 'app-alterar-senha',
  templateUrl: './alterar-senha.component.html',
  styleUrls: ['./alterar-senha.component.css']
})
export class AlterarSenhaComponent implements OnInit {

  username: string;

  password: string;
  newPassword: string;
  confirmNewPassword: string;

  viewProgress: boolean;

  constructor(private authService: AuthService, private usuarioService: UsuarioService, private messageService: MessageService,
    private router: Router) { }

  ngOnInit(): void {
    if (this.authService.getUserDetail() != null)
      this.username = this.authService.getUserDetail().userName;
  }

  limpaCampos() {
    this.username = undefined;
    this.password = undefined;
    this.newPassword = undefined;
    this.confirmNewPassword = undefined;
  }

  gravar(): void {
    this.viewProgress = true;
    this.usuarioService.alterarSenha(this.username, this.password, this.newPassword).subscribe(usuario => {
      this.messageService.add({ key: 'tc', severity: 'success', summary: 'Ok!', detail: 'Alteração realizada com sucesso.' });
      this.viewProgress = false;
      this.limpaCampos();

      setTimeout(() => {
        this.router.navigate(['/admin']);
      }, 1000 * 2.5);

    }, (e: any) => {
      this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Atenção!', detail: e.message });
      this.viewProgress = false;
    });
  }
}
