import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { OrdersComponent } from './views/orders/orders.component';
import { ExternalOrdersComponent } from './views/external-orders/external-orders.component';
import { KitchenOrdersComponent } from './views/kitchen-orders/kitchen-orders.component';
import { OrdersPanelComponent } from './views/orders-panel/orders-panel.component';

import { HttpClientModule } from '@angular/common/http';

import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { ProductModule } from './modules/product.module';
import { TemplateModule } from './modules/template.module';
import { OrderModule } from './modules/order.module';


registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    ExternalOrdersComponent,
    KitchenOrdersComponent,
    OrdersPanelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ProductModule,
    TemplateModule,
    OrderModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
