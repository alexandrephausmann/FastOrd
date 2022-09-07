import { Component, OnInit } from '@angular/core';
import { Product } from '../product.model';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.css', '../product.css']
})
export class ProductUpdateComponent implements OnInit {

  product: Product | undefined;

  constructor() { }

  ngOnInit(): void {
  }

  updateProduct(): void {

  }

  cancel(): void {
  }

}
