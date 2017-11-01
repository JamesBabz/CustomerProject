import {Component, Input, OnInit} from '@angular/core';
import {Cart} from '../shared/cart.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  @Input()
  cart: Cart;
  constructor() { }

  ngOnInit() {
  }

}
