import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from '../app-routing.module';

import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { AdminLayoutHeaderComponent } from './admin-layout-header/admin-layout-header.component';
import { AdminLayoutFooterComponent } from './admin-layout-footer/admin-layout-footer.component';

import { SiteLayoutComponent } from './site-layout/site-layout.component';
import { SiteLayoutHeaderComponent } from './site-layout-header/site-layout-header.component';
import { SiteLayoutFooterComponent } from './site-layout-footer/site-layout-footer.component';


@NgModule({
  declarations: [
    AdminLayoutComponent,
    AdminLayoutHeaderComponent,
    AdminLayoutFooterComponent,
    SiteLayoutComponent,
    SiteLayoutHeaderComponent,
    SiteLayoutFooterComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule
  ]
})
export class LayoutModule { }
