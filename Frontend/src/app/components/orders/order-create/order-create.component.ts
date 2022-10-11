import { Component, OnInit } from '@angular/core';
import { Product } from '../../product/product.model';
import { ProductService } from '../../product/product.service'

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.css']
})
export class OrderCreateComponent implements OnInit {

  quantityField = 0;
  isDecrementDisabled = true;

  products: Product[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.read().subscribe(response => {
      this.products = response;
      console.log(response);
    })
  }

  addProduct(): void {

  }

  increment() {
    this.quantityField++;
    if (this.quantityField == 1)
      this.isDecrementDisabled = false;

  }

  decrement() {
    this.quantityField--;
    if (this.quantityField == 0)
      this.isDecrementDisabled = true;
  }

  changeQuantityNumber(newValue: any) {
    this.quantityField = newValue.target.value;

    if (this.quantityField == 0)
      this.isDecrementDisabled = true;
    else
      this.isDecrementDisabled = false;
  }

}
