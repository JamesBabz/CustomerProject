import {Component, OnInit} from '@angular/core';
import {CartService} from '../shared/cart.service';
import {ActivatedRoute, Router} from '@angular/router';
import {Cart} from '../shared/cart.model';
import {ProductService} from '../../products/shared/product.service';
import {Product} from '../../products/shared/product.model';

@Component({
  selector: 'app-cart-detail',
  templateUrl: './cart-detail.component.html',
  styleUrls: ['./cart-detail.component.css']
})
export class CartDetailComponent implements OnInit {

  cart: Cart;

  constructor(private cartService: CartService, productService: ProductService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.paramMap
      .switchMap(params => this.cartService.getCartById(+params.get('id'))).subscribe(Cart => this.cart = Cart);
  }

  getProductsInCart() {
    let productIds: number[];
    let products: Product[];
    productIds = this.cart.productIds.split(',').map(Number);

    return products;
  }

  deleteCart(id: number) {
    this.route.paramMap.switchMap(params => this.cartService.deleteCart(+params.get('id'))).subscribe(Cart => this.cart = Cart);
  }



}
