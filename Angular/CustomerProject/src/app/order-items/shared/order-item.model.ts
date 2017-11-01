import {Product} from '../../products/shared/product.model';

export class OrderItem {
  id?: number;
  items: Product[];
}
