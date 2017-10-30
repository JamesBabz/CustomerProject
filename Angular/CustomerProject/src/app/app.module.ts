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
const appRoutes: Routes = [
  { path: 'product/:id',      component: ProductDetailComponent},
  {
    path: 'product',
    component: ProductListComponent,
    data: { title: 'Product list' }
  },
  { path: '',
    redirectTo: '/product',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    ProductComponent,
    ProductDetailComponent,
    ProductListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [CustomerService, ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
