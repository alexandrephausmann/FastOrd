import { Component, Input, OnInit } from '@angular/core';
import { ProductOrder } from '../productOrder.model';

@Component({
  selector: 'app-order-product-container',
  templateUrl: './order-product-container.component.html',
  styleUrls: ['./order-product-container.component.css']
})
export class OrderProductContainerComponent implements OnInit {

  constructor() { }

  displayedColumns: string[] = ['item', 'value', 'quantity', 'subtotal'];

  @Input()
  productsOrder: ProductOrder[] = [];

  @Input()
  totalOrderPrice: number = 0;

  ngOnInit(): void {
  }


}
