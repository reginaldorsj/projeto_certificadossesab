import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, mergeMap, finalize } from 'rxjs/operators';

import { AuthService } from './auth.service';
import { AppResponse } from './app-response';

@Injectable({
  providedIn: 'root'
})
export class TokenizedInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) { }

  // Add authozization token to the request
  private setHeaders(request: HttpRequest<any>) {
    const token = this.authService.getToken;
    if (token) {
      request = request.clone({
        setHeaders: {
          'content-type': 'application/json',
          Authorization: `Bearer ${token}`
        }
      });
    }
    return request;
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    request = this.setHeaders(request);
    return next.handle(request)
      .pipe(
        catchError((error: any) => {
          if (error instanceof HttpErrorResponse) {
            switch (error.status) {
              case 0:
                return throwError({ status: error.status, message: "Serviço indisponível. Por favor, informe ao administrador." } as AppResponse);
              case 400:
              case 404:
                if (error.error instanceof Blob)
                  return throwError({ status: error.status, blob: error.error });
                else
                  return throwError({ status: error.status, message: (error.error.Message ? error.error.Message : error.error.error_description) } as AppResponse);
              case 500:
                return throwError({ status: error.status, message: error.error.ExceptionMessage } as AppResponse);
              default:
                return throwError({ status: error.status, message: error.message } as AppResponse);
            }
          } else if (error.error instanceof ErrorEvent) { // Client Side Error
            return throwError({ status: error.status, message: error.error.message } as AppResponse);
          } else {  // Server Side Error
            return throwError({ status: error.status, message: error.message } as AppResponse);
          }
        }),
        finalize(() => {
          // do something at the end
        })
      );
  }
}
