import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../../Shareds/auth.service';
import { MessageService } from 'primeng/api';
import { LoggedinUser } from '../../../Shareds/loggedin-user';
import { AppResponse } from '../../../Shareds/app-response';

@Component({
  selector: 'app-login-admin',
  templateUrl: './login-admin.component.html',
  styleUrls: ['./login-admin.component.css']
})
export class LoginAdminComponent implements OnInit {

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
        this.authService.manageSession(data);
        this.authService.loginStatus.emit(true);

        if (this.authService.redirectUrl && !this.authService.redirectUrl.toLowerCase().endsWith('/admin')) {
          this.router.navigate([this.authService.redirectUrl]);
        } else {
          this.router.navigate(['/admin/evento']);
        }
      }, (error: AppResponse) => {
        this.messageService.add({ key: 'tc', severity: 'error', summary: 'Erro', detail: error.message });
        this.viewProgress = false;
      });
  }
}
