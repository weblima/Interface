
namespace Contracts.Services {
    class PaypalService {

        public double PaymentFee(double amount) {

            double calculation = amount + (amount * 0.02);

            return calculation;
        }

        public double Interest(double amount, int months) {
            
            double calculation = amount + ((amount * 0.01) * months);

            return calculation;
        }

    }
}
