import { Component, OnInit } from '@angular/core';
import { Product } from '../product.model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-delete',
  templateUrl: './product-delete.component.html',
  styleUrls: ['./product-delete.component.css', '../product.css']
})
export class ProductDeleteComponent implements OnInit {

  product: Product | undefined;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  deleteProduct(): void {
  }

  cancel(): void {

  }

}
