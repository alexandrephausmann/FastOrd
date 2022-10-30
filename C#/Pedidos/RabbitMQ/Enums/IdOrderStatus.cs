namespace Pedidos.Domain.Enums
{
    public enum IdOrderStatus
    {
        ReadyToPrepare = 1,
        InProgress = 2,
        ReadyForWithdrawal = 3,
        Done = 4,
        Cancelled = 5
    }
}
