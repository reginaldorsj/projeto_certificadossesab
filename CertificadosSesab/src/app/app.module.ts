import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, LOCALE_ID } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import localePt from '@angular/common/locales/pt';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { DatePipe, registerLocaleData } from '@angular/common';

import { LayoutModule } from './Layout/layout.module';
import { PrimeNGModule } from './prime-ng.module';
import { AdminModule } from './Views/Admin/admin.module';
import { SiteModule } from './Views/Site/site.module';

import { ConfirmationService, MessageService } from 'primeng/api';

import { AppComponent } from './app.component';
import { AuthGuard } from './Shareds/auth-guard';
import { AuthService } from './Shareds/auth.service';
import { TokenizedInterceptor } from './Shareds/tokenized-interceptor';

import { NotFoundComponent } from './Views/not-found/not-found.component';

registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    PrimeNGModule,
    AppRoutingModule,
    AdminModule,
    LayoutModule,
    SiteModule
  ],
  providers: [
    ConfirmationService,
    MessageService,
    DatePipe,
    AuthGuard,
    AuthService,
    {
      provide: LOCALE_ID,
      useValue: 'pt-BR'
    }, {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenizedInterceptor,
      multi: true,
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
