import {Cart} from '../../carts/shared/cart.model';

export class Customer {
id?: number;
firstName: string;
lastName: string;
address: string;
cart: Cart;
}
