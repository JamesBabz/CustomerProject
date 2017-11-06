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
import {LoginComponent} from './login/login.component';
import {AuthenticationService} from './login/shared/authentication.service';
import {AuthGuard} from './login/Auth/auth.guard';
import {HomeComponent} from './home/home.component';



import {CartComponent} from './carts/cart/cart.component';
import {CartDetailComponent} from './carts/cart-detail/cart-detail.component';
import {CartListComponent} from './carts/cart-list/cart-list.component';
import {CartService} from './carts/shared/cart.service';
import {FormsModule} from '@angular/forms';




const appRoutes: Routes = [
  {path: 'product/:id', component: ProductDetailComponent},
  {path: 'customer/:id', component: CustomerDetailComponent},

  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },

  {path: 'cart/:id', component: CartDetailComponent},

  {
    path: 'product',
    component: ProductListComponent,
    data: {title: 'Product list'}

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
    path: '',
    redirectTo: '/login',
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
    LoginComponent,
    HomeComponent,

    CartComponent,
    CartDetailComponent,
    CartListComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    NgbModule.forRoot(),
    FormsModule,

  ],

  providers: [CustomerService, ProductService, AuthenticationService, CartService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule {
}
