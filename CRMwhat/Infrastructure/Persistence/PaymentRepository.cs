using System;

namespace Infrastructure.ExternalServices
{
    public class PaymentProcessor
    {
        public bool ProcessPayment(decimal amount, string paymentMethod)
        {
            // Симуляция успешного платежа
            Console.WriteLine($"Processing payment of {amount} using {paymentMethod}...");
            return true;
        }
    }
}
