import {Component, Input, OnInit} from '@angular/core';
import {Customer} from '../shared/customer.model';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  @Input()
Customer: Customer;
  constructor() {
    this.Customer = {FirstName: 'Sigurd', LastName: 'Rasmussen', Address: 'Fuckerstreet'};
  }

  ngOnInit() {
  }

}