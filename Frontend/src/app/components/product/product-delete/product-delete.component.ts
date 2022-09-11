import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../product.model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-delete',
  templateUrl: './product-delete.component.html',
  styleUrls: ['./product-delete.component.css', '../product.css']
})
export class ProductDeleteComponent implements OnInit {

  product: Product | undefined;

  constructor(
    private ProductService: ProductService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.ProductService.readById(id!).subscribe(product => {
      this.product = product
    });
  }

  deleteProduct(): void {

    this.ProductService.delete(this.product!.codProduct!).subscribe(() => {
      this.ProductService.showMessage("Produto Deletado!");
      this.router.navigate(['/products']);
    })

  }

  cancel(): void {
    this.router.navigate(['/products'])
  }

}
