import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order-read',
  templateUrl: './order-read.component.html',
  styleUrls: ['./order-read.component.css']
})
export class OrderReadComponent implements OnInit {

  panelOpenState: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
