import { Component, Input, OnInit } from '@angular/core';
import { OrderStatus } from 'src/app/enums/order-status';
import { OrderService } from '../order.service';
import { HostListener } from "@angular/core";
import { Subject } from 'rxjs';

@Component({
  selector: 'app-order-read',
  templateUrl: './order-read.component.html',
  styleUrls: ['./order-read.component.css']
})
export class OrderReadComponent implements OnInit {

  orders: any;

  @Input()
  orderStatus: OrderStatus = OrderStatus.All;

  screenHeight: number = 0;

  constructor(private orderService: OrderService) {
    this.onResize();
  }

  ngOnInit(): void {
    this.onResize();
    this.getOrders();

    this.orderService.getOrderStatusChange().subscribe((status) => {
      this.getOrders();
    })

  }

  getOrders() {
    this.orderService.getOrders(this.orderStatus).subscribe(response => {
      this.orders = response;
      console.log(this.orders.ordersResponse);
    })
  }

  @HostListener('window:resize', ['$event'])
  onResize() {
    this.screenHeight = window.innerHeight - 227;
    const box = document.getElementById('cards');
    if (box != null) {
      box.style.maxHeight = this.screenHeight.toString() + 'px';
    }

  }

}
