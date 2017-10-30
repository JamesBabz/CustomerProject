import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Product} from './product.model';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import {environment} from '../../../environments/environment';

@Injectable()
export class ProductService {


  constructor(private http: HttpClient) { }

getProducts(): Observable <Product[]> {

    return this.http
      .get<Product[]>(environment.ApiEndPoint + '/product');
}

getProductById(id: number): Observable <Product> {
  return this.http
    .get(environment.ApiEndPoint +
      '/product/' + id)
    ;
}
}
