namespace Domain.ValueObjects
{
    public enum OrderStatus
    {
        New,        // Новый заказ
        InProgress, // В процессе выполнения
        Delivered,  // Доставлен
        Canceled    // Отменен
    }
}
