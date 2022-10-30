import { ChangeStatusOrderRequest } from './../ChangeStatusOrderRequest.model';
import { Component, Input, OnInit } from '@angular/core';
import { OrderStatus } from 'src/app/enums/order-status';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-card',
  templateUrl: './order-card.component.html',
  styleUrls: ['./order-card.component.css']
})
export class OrderCardComponent implements OnInit {

  panelOpenState: boolean = false;

  @Input()
  order: any;

  @Input()
  orderItems: any;

  OrderStatus = OrderStatus;


  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
  }

  changeStatusOrder(newIdStatusOrder: OrderStatus): void {
    console.log("Id Status" + newIdStatusOrder);
    var changeStatusOrder: ChangeStatusOrderRequest = {
      idOrder: this.order.codPedido,
      idOrderStatus: newIdStatusOrder

    }

    this.orderService.updateOrderStatus(changeStatusOrder).subscribe((orderStatus) => {
      this.orderService.showMessage("Order status changed!");
      console.log("order status: " + orderStatus);
      this.order.idOrderStatus = newIdStatusOrder;
      this.order.descStatusPedido = orderStatus.descOrderStatus;
      this.order = [...this.order];
    })
  }

}
