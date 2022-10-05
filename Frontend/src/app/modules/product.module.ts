import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { AppRoutingModule } from 'src/app/app-routing.module';

import { ProductCrudComponent } from 'src/app/views/product-crud/product-crud.component';
import { ProductCreateComponent } from '../components/product/product-create/product-create.component';
import { ProductReadComponent } from '../components/product/product-read/product-read.component';
import { ProductUpdateComponent } from '../components/product/product-update/product-update.component';
import { ProductRoutingModule } from '../components/product/product-routing.module';


@NgModule({
  declarations: [
    ProductCreateComponent,
    ProductReadComponent,
    ProductUpdateComponent,
    ProductCrudComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatCardModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatSnackBarModule,
    HttpClientModule,
    MatButtonModule,
    MatMenuModule,
    //AppRoutingModule,
    ProductRoutingModule
  ],
  exports: [
    ProductCrudComponent
  ]
})
export class ProductModule { }
