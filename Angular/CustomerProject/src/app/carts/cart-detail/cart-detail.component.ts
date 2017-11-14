import {Component, OnInit} from '@angular/core';
import {CartService} from '../shared/cart.service';
import {ActivatedRoute, Router} from '@angular/router';
import {Cart} from '../shared/cart.model';
import {ProductService} from '../../products/shared/product.service';
import {CartItem} from '../../cart-items/cart-item/shared/cart-item.model';
import {forEach} from '@angular/router/src/utils/collection';
import ownKeys = Reflect.ownKeys;

@Component({
  selector: 'app-cart-detail',
  templateUrl: './cart-detail.component.html',
  styleUrls: ['./cart-detail.component.css']
})
export class CartDetailComponent implements OnInit {

  cart: Cart;
  items: CartItem[];
  sortedItems: Map<CartItem, number>

  // totalPrice: number;

  constructor(private cartService: CartService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.paramMap
      .switchMap(params => this.cartService.getCartById(+params.get('id'))).subscribe(Cart => this.cart = Cart);
    this.route.paramMap
      .switchMap(params => this.cartService.getCartItemsByCartId(+params.get('id'))).subscribe(CartItem => this.items = CartItem);
  }

  calculateTotalPrice() {
    let totalPrice = 0;
    for (const item of this.items) {
      totalPrice += item.product.listPrice;
    }

    return totalPrice;
  }

  getSortedItemArray() {
    let arr = {};
    for (let i = 0; i < this.items.length; i++) {
      arr[i] = this.items[i].product.name;
    }
    let counts = {};

    for (let i = 0; i < this.items.length; i++) {
      let num = arr[i];
      // if(counts[num] = counts[num]){
      //   counts[num] + 1
      // }else{
      //   counts[num] = 1
      // }
      counts[num] = counts[num] ? counts[num] + 1 : 1;
    }
    // console.log(counts[num]);
    let keys = Object.keys(counts);
    let sortedItems = new Map<object, object>();
    sortedItems.set(keys, counts);
    console.log(sortedItems)
    return Object.keys(counts);

  }

  deleteCart(id: number) {
    // this.route.paramMap.switchMap(params => this.cartService.deleteCart(+params.get('id'))).subscribe(Cart => this.cart = Cart);
  }


}
