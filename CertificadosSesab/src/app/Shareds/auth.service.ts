import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

import { LoggedinUser } from './loggedin-user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  redirectUrl: string;
  loginStatus: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(private httpClient: HttpClient,
    private router: Router) { }

  public login(userName: string, password: string): Observable<LoggedinUser> {
    var data = `grant_type=password&username=${userName}&password=${password}`;
    return this.httpClient.post<LoggedinUser>(`${environment.webapiUrl}token`, data);
  }

  public getUserDetail() {
    if (sessionStorage.getItem('user')) {
      return JSON.parse(sessionStorage.getItem('user'));
    } else {
      return null;
    }
  }

  public get isLoggedIn() { return !!sessionStorage.getItem('token'); }

  public get getToken() { return sessionStorage.getItem('token'); }

  public manageSession(data: LoggedinUser) {
    sessionStorage.setItem('token', data.access_token);
    sessionStorage.setItem('user', JSON.stringify(data));
  }

  public logout(): void {
    this.redirectUrl = document.location.pathname;
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('user');
    if (!document.location.pathname.endsWith("/unidade") && !document.location.pathname.endsWith("/admin")) {
      this.router.navigate(['/index']);
    }
    this.loginStatus.emit(false);
  }
}
