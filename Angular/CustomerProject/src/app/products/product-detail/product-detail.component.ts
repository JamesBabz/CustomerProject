import {Component, OnInit} from '@angular/core';
import {Product} from '../shared/product.model';
import {ProductService} from '../shared/product.service';
import {ActivatedRoute, Router} from '@angular/router';
import 'rxjs/add/operator/switchMap';
import {Subject} from 'rxjs/Subject';
import {debounceTime} from 'rxjs/operator/debounceTime';
import {CartItem} from '../../cart-items/cart-item/shared/cart-item.model';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  private _success = new Subject<string>();

  inputNumber = 1;
  staticAlertClosed = false;
  successMessage: string;
  product: Product;
  cartItem: CartItem;

  constructor(private productService: ProductService, private router: Router, private route: ActivatedRoute) {
  }


  ngOnInit() {
    this.route.paramMap
      .switchMap(params => this.productService.getProductById(+params.get('id'))).subscribe(Product => this.product = Product);

    setTimeout(() => this.staticAlertClosed = true, 20000);

    this._success.subscribe((message) => this.successMessage = message);
    debounceTime.call(this._success, 5000).subscribe(() => this.successMessage = null);
  }

  public changeSuccessMessage() {
    if (this.inputNumber > 1) {
      this._success.next(this.inputNumber + ' ' + 'items have been added to your cart');
    } else {
      this._success.next('The item has been added to your cart');
    }


    // TEMP
    for (let i = 0; i < this.inputNumber; i++) {
      this.productService.addProductToCart(this.product).subscribe(CartItem => this.cartItem = CartItem);
    }
  }


}
