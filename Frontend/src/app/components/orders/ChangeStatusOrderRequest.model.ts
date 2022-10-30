import { OrderStatus } from "src/app/enums/order-status";

export interface ChangeStatusOrderRequest {
        idOrder: Number,
        idOrderStatus: OrderStatus,
}