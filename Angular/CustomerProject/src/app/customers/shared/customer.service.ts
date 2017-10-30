import { Injectable } from '@angular/core';
import {Customer} from './customer.model';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';

@Injectable()
export class CustomerService {

  constructor(private hhtp: HttpClient) { }

  getCustomers(): Observable <Customer[]> {

    return this.hhtp
      .get<Customer[]> (environment.ApiEndPoint + '/customer');
  }

  getCustomerById(id: number): Observable <Customer> {
    return this.hhtp
      .get(environment.ApiEndPoint +
        '/customer/' + id)
      ;
  }

}
