import { Component } from '@angular/core';
import {Customer} from './customers/shared/customer.model';
import {CustomerService} from './customers/shared/customer.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  Customers: Customer[];

  constructor(private customService: CustomerService) {
    this.Customers = customService.getVideos();
  }
}
