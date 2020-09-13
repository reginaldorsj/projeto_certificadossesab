import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../../../Shareds/auth.service';
import { MessageService } from 'primeng/api';
import { LoggedinUser } from '../../../../Shareds/loggedin-user';
import { AppResponse } from '../../../../Shareds/app-response';

@Component({
  selector: 'app-login-unidade',
  templateUrl: './login-unidade.component.html',
  styleUrls: ['./login-unidade.component.css']
})
export class LoginUnidadeComponent implements OnInit {

  username: string;
  password: string;
  error: string;
  viewProgress: boolean;

  constructor(private authService: AuthService, private router: Router, private messageService: MessageService) { }

  ngOnInit(): void {
    this.viewProgress = false;
    this.authService.logout();
  }

  entrar(): void {
    this.error = null;
    this.viewProgress = true;
    this.authService.login(this.username, this.password)
      .subscribe((data: LoggedinUser) => {
        if (data.idUnidade != 0) {
          this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro', detail: 'Dados inválidos. Tente outra vez.' });
          this.viewProgress = false;
          return;
        }

        this.authService.manageSession(data);
        this.authService.loginStatus.emit(true);

        if (this.authService.redirectUrl && !this.authService.redirectUrl.toLowerCase().endsWith('/unidade')) {
          this.router.navigate([this.authService.redirectUrl]);
        } else {
          this.router.navigate(['/unidade/cadastro']);
        }
      }, (error: AppResponse) => {
        this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro', detail: error.message });
        this.viewProgress = false;
      });
  }
}
