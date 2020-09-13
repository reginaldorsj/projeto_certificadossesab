import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './Shareds/auth-guard';

import { AdminLayoutComponent } from './Layout/admin-layout/admin-layout.component';
import { SiteLayoutComponent } from './Layout/site-layout/site-layout.component';
import { LoginAdminComponent } from './Views/Admin/login-admin/login-admin.component';
import { EventoComponent } from './Views/Admin/evento/evento.component';
import { ParticipanteComponent } from './Views/Admin/participante/participante.component';
import { UsuarioComponent } from './Views/Admin/usuario/usuario.component';

import { IndexComponent } from './Views/Site/index/index.component';
import { LoginUnidadeComponent } from './Views/Site/Unidade/login-unidade/login-unidade.component';
import { CadastroUnidadeComponent } from './Views/Site/Unidade/cadastro-unidade/cadastro-unidade.component';
import { AlterarSenhaComponent } from './Views/Admin/alterar-senha/alterar-senha.component';
import { NotFoundComponent } from './Views/not-found/not-found.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/index',
    pathMatch: 'full'
  },
  {
    path: '',
    component: SiteLayoutComponent,
    children: [
      {
        path: '',
        redirectTo: '/page-not-found',
        pathMatch: 'full'
      },
      {
        path: 'index',
        component: IndexComponent
      },
      {
        path: 'unidade',
        children: [
          {
            path: '',
            component: LoginUnidadeComponent
          },
          {
            path: 'cadastro',
            component: CadastroUnidadeComponent,
            canActivate: [AuthGuard]
          }
        ]
      }
    ]
  },
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      {
        path: 'admin',
        children: [
          {
            path: '',
            component: LoginAdminComponent
          },
          {
            path: 'alterar-senha',
            component: AlterarSenhaComponent
          },
          {
            path: 'evento',
            component: EventoComponent,
            canActivate: [AuthGuard]
          },
          {
            path: 'participante',
            component: ParticipanteComponent,
            canActivate: [AuthGuard]
          },
          {
            path: 'usuario',
            component: UsuarioComponent,
            canActivate: [AuthGuard]
          }
        ]
      }
    ]
  },
  {
    path: 'page-not-found',
    component: NotFoundComponent
  },
  {
    path: '**',
    redirectTo: '/page-not-found',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
