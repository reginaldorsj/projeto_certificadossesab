import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { PrimeNGModule } from '../../prime-ng.module';
import { UnidadeModule } from './Unidade/unidade.module';

import { IndexComponent } from './index/index.component';



@NgModule({
  declarations: [
    IndexComponent
  ],
  imports: [
    UnidadeModule,
    PrimeNGModule,
    FormsModule,
    CommonModule
  ]
})
export class SiteModule { }
