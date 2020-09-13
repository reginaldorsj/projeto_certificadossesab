import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { PrimeNGModule } from '../../../prime-ng.module';

import { CadastroUnidadeComponent } from './cadastro-unidade/cadastro-unidade.component';
import { LoginUnidadeComponent } from './login-unidade/login-unidade.component';



@NgModule({
  declarations: [
    CadastroUnidadeComponent,
    LoginUnidadeComponent
  ],
  imports: [
    CommonModule,
    PrimeNGModule,
    FormsModule
  ]
})
export class UnidadeModule { }
