import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { Product } from '../../product/product.model';
import { ProductService } from '../../product/product.service'
import { OrderService } from '../order.service';
import { ProductOrder } from '../productOrder.model';

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.css']
})
export class OrderCreateComponent implements OnInit {

  quantityField = 0;
  isDecrementDisabled = true;
  totalOrderPrice: number = 0;

  products: Product[] = [];
  productsOrder: ProductOrder[] = [];
  selectedValue: number = 0;

  constructor(private productService: ProductService, private orderService: OrderService) { }

  ngOnInit(): void {
    this.productService.read().subscribe(response => {
      this.products = response;
      console.log(response);
    })
  }

  addProduct(): void {

    if (this.selectedValue == 0) {
      this.orderService.showMessage("You neeed to select a product");
      return;
    }

    if (this.quantityField <= 0) {
      this.orderService.showMessage("You neeed to put a quantity for the product");
      return;
    }

    var product = this.products.find(product => product.codProduct == this.selectedValue);

    if (product != undefined) {

      var existProductOrder = this.productsOrder.find(product => product.codProduct == this.selectedValue);

      if (existProductOrder != undefined) {
        let index = this.productsOrder.indexOf(existProductOrder);
        existProductOrder.quantity = existProductOrder.quantity + this.quantityField;
        this.productsOrder[index] = existProductOrder;
      }
      else {
        var productOrder: ProductOrder = {
          codProduct: product.codProduct,
          descProduct: product.descProduct,
          productValue: product.productValue,
          quantity: this.quantityField
        }
        this.productsOrder.push(productOrder);
      }

      this.productsOrder = [...this.productsOrder];
      this.updateTotalCost();
      this.cleanFields();
    }
  }

  increment() {
    this.quantityField++;
    if (this.quantityField == 1)
      this.isDecrementDisabled = false;

  }

  decrement() {
    this.quantityField--;
    if (this.quantityField == 0)
      this.isDecrementDisabled = true;
  }

  changeQuantityNumber(newValue: any) {
    this.quantityField = newValue.target.value;

    if (this.quantityField == 0)
      this.isDecrementDisabled = true;
    else
      this.isDecrementDisabled = false;
  }

  updateTotalCost() {
    this.totalOrderPrice = +this.productsOrder.reduce((sum, currentItem) => {
      return sum + (currentItem.quantity * currentItem.productValue);
    }, 0).toFixed(2);
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
        const productIndex = this.productsOrder.findIndex(item => item.codProduct === id);
        this.productsOrder.splice(productIndex, 1);
        this.productsOrder = [...this.productsOrder];
        this.updateTotalCost();
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

  cleanFields() {
    this.quantityField = 0;
    this.selectedValue = 0;

  }

}
