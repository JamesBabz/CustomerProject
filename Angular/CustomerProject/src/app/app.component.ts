import { Component } from '@angular/core';
import {Customer} from './customers/shared/customer.model';
import {CustomerService} from './customers/shared/customer.service';
import {ProductService} from './products/shared/product.service';
import {Product} from './products/shared/product.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  customers: Customer[];
  products: Product[];

constructor(private produtService: ProductService, private customerService: CustomerService){
  customerService.getCustomers().subscribe(Customers => this.customers = Customers);
  produtService.getProducts().subscribe(Products => this.products = Products );
}
}
