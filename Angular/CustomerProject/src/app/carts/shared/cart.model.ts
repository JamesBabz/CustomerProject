import {Customer} from '../../customers/shared/customer.model';

export class Cart {
  id?: number;
  productIds: string;
  customerId: number;
  customer: Customer;
}
