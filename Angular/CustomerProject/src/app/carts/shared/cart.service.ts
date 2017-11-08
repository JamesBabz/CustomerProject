import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {Cart} from './cart.model';
import {environment} from '../../../environments/environment';

const url = environment.ApiEndPoint + '/cart/';

@Injectable()
export class CartService {


  constructor(private http: HttpClient) {
  }

  getCarts(): Observable<Cart[]> {

    return this.http
      .get<Cart[]>(environment.ApiEndPoint + '/cart');
  }

  getCartById(id: number): Observable<Cart> {
    return this.http
      .get(url + id)
      ;
  }

  deleteCart(id: number): Observable<Cart> {
    return this.http
      .delete(url + id)
      ;
  }

  createCart(cart: Cart): Observable<Cart> {
    return this.http.post(url, cart);
  }

}
