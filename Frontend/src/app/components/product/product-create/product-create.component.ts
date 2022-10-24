import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../product.model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css', '../product.css']
})
export class ProductCreateComponent implements OnInit {

  product: Product = {
    descProduct: '',
    productValue: 0
  }

  constructor(private ProductService: ProductService, private router: Router) { }

  ngOnInit(): void {
  }

  createProduct(): void {
    this.ProductService.create(this.product).subscribe(() => {
      this.ProductService.showMessage("Product registered!");
      this.router.navigate(['/products']);
    })

  }

  cancel(): void {
    this.router.navigate(['/products'])

  }
}
