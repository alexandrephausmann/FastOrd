import { Component, Input, OnInit } from '@angular/core';

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
  orderItens: any;

  constructor() { }

  ngOnInit(): void {
  }

}
