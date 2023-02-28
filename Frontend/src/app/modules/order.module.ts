import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderCreateComponent } from '../components/orders/order-create/order-create.component';
import { OrdersComponent } from '../views/orders/orders.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrderReadComponent } from '../components/orders/order-read/order-read.component';
import { OrderRoutingModule } from '../components/orders/order-routing.module';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { OrderCardComponent } from '../components/orders/order-card/order-card.component';
import { MatSelectModule } from '@angular/material/select';
import { OrderProductContainerComponent } from '../components/orders/order-product-container/order-product-container.component';
import { KitchenOrdersComponent } from '../views/kitchen-orders/kitchen-orders.component';


@NgModule({
  declarations: [
    OrderCreateComponent,
    OrderReadComponent,
    OrdersComponent,
    OrderCardComponent,
    OrderProductContainerComponent,
    KitchenOrdersComponent
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
    MatCardModule,
    MatSelectModule,
    MatExpansionModule,
    MatDividerModule,
    OrderRoutingModule
  ],
  exports: [
    OrdersComponent
  ]
})
export class OrderModule { }
