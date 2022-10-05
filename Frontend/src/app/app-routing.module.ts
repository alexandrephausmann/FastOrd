import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductCreateComponent } from './components/product/product-create/product-create.component';
import { ProductUpdateComponent } from './components/product/product-update/product-update.component';
import { ExternalOrdersComponent } from './views/external-orders/external-orders.component';
import { HomeComponent } from './views/home/home.component';
import { KitchenOrdersComponent } from './views/kitchen-orders/kitchen-orders.component';
import { OrdersPanelComponent } from './views/orders-panel/orders-panel.component';
import { OrdersComponent } from './views/orders/orders.component';
import { ProductCrudComponent } from './views/product-crud/product-crud.component';

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "externalOrders",
    component: ExternalOrdersComponent
  },
  {
    path: "kitchenOrders",
    component: KitchenOrdersComponent
  },
  {
    path: "ordersPanel",
    component: OrdersPanelComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
