import {Component, OnInit} from '@angular/core';
import {Cart} from '../shared/cart.model';
import {CartService} from '../shared/cart.service';
import {Router} from '@angular/router';
import {CustomerService} from '../../customers/shared/customer.service';
import {Customer} from '../../customers/shared/customer.model';

@Component({
  selector: 'app-cart-list',
  templateUrl: './cart-list.component.html',
  styleUrls: ['./cart-list.component.css']
})
export class CartListComponent implements OnInit {

  carts: Cart[];

  constructor(private cartService: CartService, private router: Router) {
  }

  ngOnInit() {
    this.cartService.getCarts().subscribe(Carts => this.carts = Carts);
  }

  details(cart: Cart) {
    this.router.navigateByUrl('/cart/' + cart.id);
  }

}
