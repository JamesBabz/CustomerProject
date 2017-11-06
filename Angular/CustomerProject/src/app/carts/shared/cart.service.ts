import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {Cart} from './cart.model';
import {environment} from '../../../environments/environment';

@Injectable()
export class CartService {

  constructor(private http: HttpClient) { }

  getCarts(): Observable <Cart[]> {

    return this.http
      .get<Cart[]>(environment.ApiEndPoint + '/cart');
  }

  getCartById(id: number): Observable <Cart> {
    return this.http
      .get(environment.ApiEndPoint +
        '/cart/' + id)
      ;
  }

}
