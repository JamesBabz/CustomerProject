import { Component, OnInit } from '@angular/core';
import {ProductService} from '../shared/product.service';
import {Router} from '@angular/router';
import {Product} from '../shared/product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Product[];
  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit() {
    this.productService.getProducts().subscribe(Products => this.products = Products );
  }

  details(product: Product) {
    this.router.navigateByUrl('/product/' + product.id )
    console.log('clicked' + product.id);
  }

}
