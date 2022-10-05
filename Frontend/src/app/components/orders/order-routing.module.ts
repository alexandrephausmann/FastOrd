import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OrdersComponent } from 'src/app/views/orders/orders.component';
import { OrderCreateComponent } from './order-create/order-create.component';


const routes = [
        {
                path: "orders",
                component: OrdersComponent
        },
        {
                path: "orders/create",
                component: OrderCreateComponent
        }
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule]
})
export class OrderRoutingModule { }
