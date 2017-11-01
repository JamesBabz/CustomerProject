import { Component } from '@angular/core';
import {Customer} from './customers/shared/customer.model';
import {CustomerService} from './customers/shared/customer.service';
import {ProductService} from './products/shared/product.service';
import {Product} from './products/shared/product.model';
import {OrderItem} from './order-items/shared/order-item.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  customers: Customer[];
  products: Product[];
  orderItems: OrderItem[];

constructor(){


}
}
