import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductCreateComponent } from './components/product/product-create/product-create.component';
import { ProductDeleteComponent } from './components/product/product-delete/product-delete.component';
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
    path: "products",
    component: ProductCrudComponent
  },
  {
    path: "products/create",
    component: ProductCreateComponent
  },
  {
    path: "products/update/:id",
    component: ProductUpdateComponent
  },
  {
    path: "products/delete/:id",
    component: ProductDeleteComponent
  },
  {
    path: "orders",
    component: OrdersComponent
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
