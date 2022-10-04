import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from 'src/app/views/home/home.component';

import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSortModule } from '@angular/material/sort';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { FooterComponent } from '../components/template/footer/footer.component';
import { HeaderComponent } from '../components/template/header/header.component';
import { NavComponent } from '../components/template/nav/nav.component';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    NavComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    MatToolbarModule,
    AppRoutingModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    FormsModule,
    MatSortModule,
    MatButtonModule,
    MatMenuModule,
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    NavComponent,
    HomeComponent
  ]
})
export class TemplateModule { }
