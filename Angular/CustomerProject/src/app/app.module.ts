import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customers/customer/customer.component';
import {CustomerService} from './customers/shared/customer.service';
import {HttpClientModule} from '@angular/common/http';
import { ProductComponent } from './products/product/product.component';
import {ProductService} from './products/shared/product.service';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import {RouterModule, Routes} from '@angular/router';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { CustomerDetailComponent } from './customers/customer-detail/customer-detail.component';
import { OrderItemDetailComponent } from './order-items/order-item-detail/order-item-detail.component';
import { OrderItemListComponent } from './order-items/order-item-list/order-item-list.component';
import { OrderItemComponent } from './order-items/order-item/order-item.component';
const appRoutes: Routes = [
  { path: 'product/:id',      component: ProductDetailComponent},
  { path: 'customer/:id',      component: CustomerDetailComponent},
  { path: 'orderitem/:id',      component: OrderItemDetailComponent},
  {
    path: 'product',
    component: ProductListComponent,
    data: { title: 'Product list' }
  }, {
    path: 'customer',
    component: CustomerListComponent,
    data: { title: 'Customer list' }
  }, {
    path: 'cart',
    component: OrderItemListComponent,
    data: { title: 'Cart' }
  },
  { path: '',
    redirectTo: '/product',
    pathMatch: 'full'
  },
  { path: '',
    redirectTo: '/customer',
    pathMatch: 'full'
  },
  { path: 'orderItem',
    redirectTo: '/cart',
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
    OrderItemDetailComponent,
    OrderItemListComponent,
    OrderItemComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    NgbModule.forRoot()
  ],
  providers: [CustomerService, ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
