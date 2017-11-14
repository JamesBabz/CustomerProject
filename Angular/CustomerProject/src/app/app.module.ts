import {BrowserModule} from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
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




import {CartComponent} from './carts/cart/cart.component';
import {CartDetailComponent} from './carts/cart-detail/cart-detail.component';
import {CartListComponent} from './carts/cart-list/cart-list.component';
import {FormsModule, NgModel} from '@angular/forms';
import { CartItemComponent } from './cart-items/cart-item/cart-item.component';
import {CartService} from './carts/shared/cart.service';
import {LoginComponent} from './login/login.component';
import {AuthenticationService} from './login/shared/authentication.service';


const appRoutes: Routes = [
  {path: 'product/:id', component: ProductDetailComponent},
  {path: 'customer/:id', component: CustomerDetailComponent},

  { path: 'login', component: LoginComponent },
 // { path: '', component: HomeComponent, canActivate: [AuthGuard] },

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
    path: 'customer',
    redirectTo: '/customer',
    pathMatch: 'full'
  },
  {
    path: '**', redirectTo: ''
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

    CartComponent,
    CartDetailComponent,
    CartListComponent,
    CartItemComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    HttpModule,
    RouterModule.forRoot(appRoutes),
    NgbModule.forRoot(),
    FormsModule

  ],

  providers: [CustomerService, ProductService, CartService,
    AuthenticationService,
    ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
