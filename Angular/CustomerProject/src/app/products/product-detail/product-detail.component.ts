import { Component, OnInit } from '@angular/core';
import {Product} from '../shared/product.model';
import {ProductService} from '../shared/product.service';
import {ActivatedRoute, Router} from '@angular/router';
import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: Product;
  constructor(private productService: ProductService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap
      .switchMap(params => this.productService.getProductById(+params.get('id'))).subscribe(Product => this.product = Product);
  }

}
