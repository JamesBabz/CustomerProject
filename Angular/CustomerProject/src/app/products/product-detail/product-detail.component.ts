import { Component, OnInit } from '@angular/core';
import {Product} from '../shared/product.model';
import {ProductService} from '../shared/product.service';
import {ActivatedRoute, Router} from '@angular/router';
import 'rxjs/add/operator/switchMap';
import {Subject} from 'rxjs/Subject';
import {debounceTime} from 'rxjs/operator/debounceTime';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  private _success = new Subject<string>();

  staticAlertClosed = false;
  successMessage: string;
  product: Product;
  constructor(private productService: ProductService, private router: Router, private route: ActivatedRoute) { }


  ngOnInit() {
    this.route.paramMap
      .switchMap(params => this.productService.getProductById(+params.get('id'))).subscribe(Product => this.product = Product);

    setTimeout(() => this.staticAlertClosed = true, 20000);

    this._success.subscribe((message) => this.successMessage = message);
    debounceTime.call(this._success, 10000).subscribe(() => this.successMessage = null);
  }

  public changeSuccessMessage() {
    this._success.next( 'The item has been added to your card');
  }



}
