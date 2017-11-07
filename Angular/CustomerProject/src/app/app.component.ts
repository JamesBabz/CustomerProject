import { Component } from '@angular/core';
import {Customer} from './customers/shared/customer.model';
import {CustomerService} from './customers/shared/customer.service';
import {ProductService} from './products/shared/product.service';
import {Product} from './products/shared/product.model';
import {Cart} from "./carts/shared/cart.model";
import {TodoItem} from './login/_models/todoitem';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  customers: Customer[];
  products: Product[];
  carts: Cart[];
  logins: TodoItem[];

constructor() {


}
}
