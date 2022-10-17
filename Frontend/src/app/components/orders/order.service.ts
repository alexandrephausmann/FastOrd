import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, map, catchError } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { ProductOrderRequest } from './productOrderRequest.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  baseUrl = "http://localhost:5000/order";

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
    this.showMessage("Ocorreu um erro", true)
    return EMPTY
  }

  read(): Observable<any> {
    return this.http.get<any>(this.baseUrl).pipe(
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

}
