import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customers/customer/customer.component';
import {CustomerService} from './customers/shared/customer.service';
import {HttpClientModule} from '@angular/common/http';
import { ProductComponent } from './products/product/product.component';
import {ProductService} from './products/shared/product.service';

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [CustomerService, ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
