import { Component, OnInit } from '@angular/core';
import { OrderStatus } from 'src/app/enums/order-status';

@Component({
  selector: 'app-kitchen-orders',
  templateUrl: './kitchen-orders.component.html',
  styleUrls: ['./kitchen-orders.component.css']
})
export class KitchenOrdersComponent implements OnInit {

  OrderStatus = OrderStatus;

  constructor() { }

  ngOnInit(): void {
  }

}
