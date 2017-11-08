import {Component, Input, OnInit} from '@angular/core';
import {Cart} from '../shared/cart.model';
import {Customer} from '../../customers/shared/customer.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  @Input()
  cart: Cart;
  @Input()
  customer: Customer;

  constructor() {
  }

  ngOnInit() {
  }

}
