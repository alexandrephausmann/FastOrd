import { ProductOrder } from "./productOrder.model";
import { ProductOrderDetails } from "./ProductOrderDetails.model";

export interface ProductOrderRequest {
        orderDetails: ProductOrderDetails,
        productItens: ProductOrder[],

}