import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProductCrudComponent } from 'src/app/views/product-crud/product-crud.component';
import { ProductCreateComponent } from './product-create/product-create.component';
import { ProductUpdateComponent } from './product-update/product-update.component';

const routes = [
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
        }
];

@NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule]
})
export class ProductRoutingModule { }
