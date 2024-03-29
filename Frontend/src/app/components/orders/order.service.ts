import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, map, catchError, Subject } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { OrderStatus } from 'src/app/enums/order-status';
import { ChangeStatusOrderRequest } from './ChangeStatusOrderRequest.model';
import { ProductOrderRequest } from './productOrderRequest.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  baseUrl = "http://localhost:5000/order";

  statusChange$ = new Subject<boolean>();

  constructor(private snackbar: MatSnackBar, private http: HttpClient) { }

  showMessage(msg: string, isError: boolean = false): void {
    this.snackbar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: isError ? ['msg-error'] : ['msg-sucess']

    })
  }

  errorHandler(e: any): Observable<any> {
    this.showMessage("Unexpected error", true)
    return EMPTY
  }

  getOrders(id: OrderStatus): Observable<any> {
    if (id == OrderStatus.All) {
      this.getAllOrders();
      return this.getAllOrders();
    }
    else {
      return this.getOrderByID(id);
    }
  }

  getAllOrders(): Observable<any> {
    return this.http.get<any>(this.baseUrl).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    )
  }

  getOrderByID(id: OrderStatus): Observable<any> {
    var url = `${this.baseUrl}/${id}`
    return this.http.get<any>(url).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    )
  }

  create(product: ProductOrderRequest): Observable<ProductOrderRequest> {
    return this.http.post<ProductOrderRequest>(this.baseUrl, product).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    )
  }

  updateOrderStatus(changeStatusOrderRequest: ChangeStatusOrderRequest): Observable<any> {
    var url = `${this.baseUrl}/updateStatus`
    return this.http.put<ChangeStatusOrderRequest>(url, changeStatusOrderRequest).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    )
  }

  updateOrderStatusComponent() {
    this.statusChange$.next(true);
  }

  getOrderStatusChange() {
    return this.statusChange$.asObservable();
  }

}
