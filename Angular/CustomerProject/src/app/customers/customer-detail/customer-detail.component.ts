import { Component, OnInit } from '@angular/core';
import {Customer} from '../shared/customer.model';
import {CustomerService} from '../shared/customer.service';
import {ActivatedRoute, Router} from '@angular/router';
import {environment} from '../../../environments/environment';


@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {

  customer: Customer;
  inputAddress: string;
  inputLastname: string;
  inputFirstname: string;
  constructor(private customerService: CustomerService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap
      .switchMap(params => this.customerService.getCustomerById(+params.get('id'))).subscribe(Customer => this.customer = Customer);
  }

  deleteCustomer() {
    this.customerService.deleteCustomerById(this.customer.id).subscribe(Customer => this.customer = Customer);
  }

}
