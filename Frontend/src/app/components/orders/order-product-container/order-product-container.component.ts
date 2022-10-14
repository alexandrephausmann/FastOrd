import { Component, Input, OnInit } from '@angular/core';
import { ProductOrder } from '../productOrder.model';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-order-product-container',
  templateUrl: './order-product-container.component.html',
  styleUrls: ['./order-product-container.component.css']
})
export class OrderProductContainerComponent implements OnInit {

  constructor() { }

  @Output() deleteProductEvent = new EventEmitter<number>();

  displayedColumns: string[] = ['item', 'value', 'quantity', 'subtotal', 'action'];

  @Input()
  productsOrder: ProductOrder[] = [];

  @Input()
  totalOrderPrice: number = 0;

  ngOnInit(): void {
  }

  deleteProduct(id: number) {
    this.deleteProductEvent.emit(id);
  }

}
