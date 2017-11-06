import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {AppComponent} from './app.component';
import {CustomerComponent} from './customers/customer/customer.component';
import {CustomerService} from './customers/shared/customer.service';
import {HttpClientModule} from '@angular/common/http';
import {ProductComponent} from './products/product/product.component';
import {ProductService} from './products/shared/product.service';
import {ProductDetailComponent} from './products/product-detail/product-detail.component';
import {ProductListComponent} from './products/product-list/product-list.component';
import {RouterModule, Routes} from '@angular/router';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {CustomerListComponent} from './customers/customer-list/customer-list.component';
import {CustomerDetailComponent} from './customers/customer-detail/customer-detail.component';
<<<<<<< HEAD
<<<<<<< HEAD
import {LoginComponent} from './login/login.component';
import {AuthenticationService} from './login/shared/authentication.service';
import {AuthGuard} from './login/Auth/auth.guard';
import {HomeComponent} from './home/home.component';

=======
=======
>>>>>>> Development
import {CartComponent} from './carts/cart/cart.component';
import {CartDetailComponent} from './carts/cart-detail/cart-detail.component';
import {CartListComponent} from './carts/cart-list/cart-list.component';
import {CartService} from "./carts/shared/cart.service";
<<<<<<< HEAD
>>>>>>> Development
=======
>>>>>>> Development

const appRoutes: Routes = [
  {path: 'product/:id', component: ProductDetailComponent},
  {path: 'customer/:id', component: CustomerDetailComponent},
<<<<<<< HEAD
<<<<<<< HEAD
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
=======
  {path: 'cart/:id', component: CartDetailComponent},
>>>>>>> Development
=======
  {path: 'cart/:id', component: CartDetailComponent},
>>>>>>> Development
  {
    path: 'product',
    component: ProductListComponent,
    data: {title: 'Product list'}
<<<<<<< HEAD
<<<<<<< HEAD
  },
  {
    path: 'customer',
    component: CustomerListComponent,
    data: {title: 'Customer list'}
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {title: 'Customer list'}
=======
  }, {
    path: 'customer',
    component: CustomerListComponent,
    data: {title: 'Customer list'}
  }, {
    path: 'cart',
    component: CartListComponent,
    data: {title: 'Cart'}
>>>>>>> Development
  },
  {
=======
  }, {
    path: 'customer',
    component: CustomerListComponent,
    data: {title: 'Customer list'}
  }, {
    path: 'cart',
    component: CartListComponent,
    data: {title: 'Cart'}
  },
  {
>>>>>>> Development
    path: '',
    redirectTo: '/product',
    pathMatch: 'full'
  },
  {
    path: '',
    redirectTo: '/customer',
    pathMatch: 'full'
  },
  {
<<<<<<< HEAD
<<<<<<< HEAD
    path: '',
    redirectTo: '/login',
=======
    path: 'orderItem',
    redirectTo: '/cart',
>>>>>>> Development
=======
    path: 'orderItem',
    redirectTo: '/cart',
>>>>>>> Development
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    ProductComponent,
    ProductDetailComponent,
    ProductListComponent,
    CustomerListComponent,
    CustomerDetailComponent,
<<<<<<< HEAD
<<<<<<< HEAD
    LoginComponent
=======
    CartComponent,
    CartDetailComponent,
    CartListComponent
>>>>>>> Development
=======
    CartComponent,
    CartDetailComponent,
    CartListComponent
>>>>>>> Development
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    NgbModule.forRoot()
  ],
<<<<<<< HEAD
<<<<<<< HEAD
  providers: [CustomerService, ProductService, AuthenticationService, AuthGuard],
=======
  providers: [CustomerService, ProductService, CartService],
>>>>>>> Development
=======
  providers: [CustomerService, ProductService, CartService],
>>>>>>> Development
  bootstrap: [AppComponent]
})
export class AppModule {
}
