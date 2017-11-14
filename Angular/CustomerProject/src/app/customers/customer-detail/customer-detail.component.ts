import { Component, OnInit } from '@angular/core';
import {Customer} from '../shared/customer.model';
import {CustomerService} from '../shared/customer.service';
import {ActivatedRoute, Router} from '@angular/router';



@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {

  customer: Customer;
  customerEdit: Customer;
  profilePic: any;
  confirmDelete = false;

  constructor(private customerService: CustomerService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.paramMap
      .switchMap(params => this.customerService
        .getCustomerById(+params.get('id')))
      .subscribe(Customer => {
        this.customer = Customer;
        this.customerEdit = Object.assign({}, this.customer);
      });
  }

  cancel() {
    this.customerEdit = Object.assign({}, this.customer);
  }

  deleteCustomer() {
    if (this.confirmDelete) {
      this.customerService.deleteCustomerById(this.customer.id).subscribe(Customer => {
          this.router.navigate(['/customer']);
        }
      );
    }
  }

  delete() {
    this.confirmDelete = true;
  }

  abortDelete() {
    this.confirmDelete = false;
  }

  updateCustomer() {
    this.customerService.updateCustomerById(this.customer.id, this.customerEdit).subscribe(Customer => {
      this.customer = Customer;
      this.customerEdit = Object.assign({}, this.customer);
    });
  }

  onFileChange(fileInput: any) {

    this.profilePic = fileInput.target.files[0];

    const reader = new FileReader();

    reader.onload = (e: any) => {
      this.profilePic = e.target.result;
    }

    reader.readAsDataURL(fileInput.target.files[0]);
  }
}
