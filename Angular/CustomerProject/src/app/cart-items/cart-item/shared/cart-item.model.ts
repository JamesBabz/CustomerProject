import {Product} from '../../../products/shared/product.model';
import {Cart} from '../../../carts/shared/cart.model';

export class CartItem{
  id?: number;
  productId?: number;
  product: Product;
  cartId?: number;
  cart: Cart;

}
