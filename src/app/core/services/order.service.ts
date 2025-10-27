import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../models/order.model';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  constructor(private httpClient: HttpClient) { }

  getAllOrders(): Observable<Order[]> {
    const result = this.httpClient.get<Order[]>(`${environment.API_URL}/Order`);
    return result;
  }
}
