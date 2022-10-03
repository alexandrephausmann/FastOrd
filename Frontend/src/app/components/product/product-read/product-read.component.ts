import { Component, OnInit } from '@angular/core';
import { Product } from '../product.model';
import { ProductService } from '../product.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-product-read',
  templateUrl: './product-read.component.html',
  styleUrls: ['./product-read.component.css', '../product.css']
})
export class ProductReadComponent implements OnInit {

  products: Product[] = [];

  displayedColumns = ['codProduct', 'description', 'productValue', 'action']

  constructor(private productService: ProductService) {
  }

  ngOnInit(): void {
    this.productService.read().subscribe(response => {
      this.products = response;
      console.log(response);
    })
  }

  deleteProduct(id: number) {
    swal.fire({
      title: 'Are you sure want to remove?',
      text: 'You will not be able to recover this product!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        this.productService.delete(id).subscribe((data) => {
          const productIndex = this.products.findIndex(item => item.codProduct === id);
          this.products.splice(productIndex, 1);
          this.products = [...this.products];
          this.productService.showMessage("Product deleted!");
        });
        swal.fire(
          'Deleted!',
          'The product was deleted sucessfully!.',
          'success'
        )
      } else if (result.dismiss === swal.DismissReason.cancel) {
        swal.fire(
          'Cancelled',
          'Your product is safe :)',
          'error'
        )
      }
    })
  }
}
