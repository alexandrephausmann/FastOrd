import { Component, OnInit } from '@angular/core';

interface Food {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.css']
})
export class OrderCreateComponent implements OnInit {

  quantityField = 0;
  isDecrementDisabled = true;

  foods: Food[] = [
    { value: 'steak-0', viewValue: 'Steak' },
    { value: 'pizza-1', viewValue: 'Pizza' },
    { value: 'tacos-2', viewValue: 'Tacos' },
  ];

  constructor() { }

  ngOnInit(): void {
  }

  addProduct(): void {

  }

  increment() {
    console.log('increment ' + this.quantityField)
    this.quantityField++;
    console.log('increment ' + this.quantityField)
  }

  decrement() {
    console.log('decrement ' + this.quantityField)
    this.quantityField--;
    console.log('decrement ' + this.quantityField)
  }

}
