import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {OrderItem} from './order-item.model';
import {environment} from '../../../environments/environment';

@Injectable()
export class OrderItemService {

  constructor(private hhtp: HttpClient) { }

  getOrderItems(): Observable <OrderItem[]> {

    return this.hhtp
      .get<OrderItem[]> (environment.ApiEndPoint + '/cart');
  }

  getOrderItemById(id: number): Observable <OrderItem> {
    return this.hhtp
      .get(environment.ApiEndPoint +
        '/orderItem/' + id)
      ;
  }

}
