import { Component, OnInit } from '@angular/core';
import {OrderItem} from '../shared/order-item.model';
import {OrderItemService} from '../shared/order-item.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-order-item-list',
  templateUrl: './order-item-list.component.html',
  styleUrls: ['./order-item-list.component.css']
})
export class OrderItemListComponent implements OnInit {

  orderItems: OrderItem[];
  constructor(private orderItemService: OrderItemService, private router: Router) {  }

  ngOnInit() {
    this.orderItemService.getOrderItems().subscribe(OrderItem => this.orderItems = OrderItem);
  }

  details(orderItem: OrderItem){
    this.router.navigateByUrl('/cart/' + orderItem.id);
  }

}
