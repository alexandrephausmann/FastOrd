import { Component, OnInit } from '@angular/core';
import { Product } from '../product.model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-read',
  templateUrl: './product-read.component.html',
  styleUrls: ['./product-read.component.css', '../product.css']
})
export class ProductReadComponent implements OnInit {

  products: any[] = [];

  displayedColumns = ['codProduct', 'description', 'productValue', 'action']

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.read().subscribe(response => {

      /* products.forEach(element => {
         this.products = [{ codProduct: element.codProduct, descProduct: element.descProduct, productValue: element.productValue }];
         console.log(`Id: ${element.codProduct} - Name ${element.descProduct} product ${element.productValue}`);
       })*/

      //this.products.push({ codProduct: 1, descProduct: "teste", productValue: 123 })
      this.products = response;
      console.log(response);
      //console.log(products.toString());
    })
    //this.products.push({ codProduct: 1, descProduct: "teste", productValue: 123 });
  }

}
