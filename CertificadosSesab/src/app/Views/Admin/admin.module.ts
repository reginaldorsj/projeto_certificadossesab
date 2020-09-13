import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrimeNGModule } from '../../prime-ng.module';
import { FormsModule } from '@angular/forms';
import { FileUploadModule } from 'ng2-file-upload';
import { RouterModule } from '@angular/router';

import { LoginAdminComponent } from './login-admin/login-admin.component';
import { EventoComponent } from './evento/evento.component';
import { ParticipanteComponent } from './participante/participante.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { DatePickerMaskComponent } from '../../Components/date-picker-mask/date-picker-mask.component';
import { AlterarSenhaComponent } from './alterar-senha/alterar-senha.component';

@NgModule({
  declarations: [
    LoginAdminComponent,
    EventoComponent,
    ParticipanteComponent,
    UsuarioComponent,
    DatePickerMaskComponent,
    AlterarSenhaComponent
  ],
  imports: [
    PrimeNGModule,
    FormsModule,
    CommonModule,
    FileUploadModule,
    RouterModule
  ]
})
export class AdminModule { }
