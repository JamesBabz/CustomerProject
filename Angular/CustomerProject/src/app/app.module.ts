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
const appRoutes: Routes = [
  { path: 'product/:id',      component: ProductDetailComponent},
  { path: 'customer/:id',      component: CustomerDetailComponent},
  {
    path: 'product',
    component: ProductListComponent,
    data: { title: 'Product list' }
  },{
    path: 'customer',
    component: CustomerListComponent,
    data: { title: 'Customer list' }
  },
  { path: '',
    redirectTo: '/product',
    pathMatch: 'full'
  },
  { path: '',
    redirectTo: '/customer',
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
    CustomerDetailComponent
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
