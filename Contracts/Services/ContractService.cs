using System;
using Contracts.Entities;

namespace Contracts.Services {
    class ContractService {

        private PaypalService _paypalService = new PaypalService();

        public void ProcessContract(Contract contract, int months) {

            double amount = contract.TotalValue / months;

            for (int i = 1; i <= months; i++) {

                DateTime dueDate = contract.Date.AddMonths(i);

                double amountInterest = _paypalService.Interest(amount, i);
                double PaymentFee = _paypalService.PaymentFee(amountInterest);

                Installment installment = new Installment(dueDate, PaymentFee);
                contract.AddInstallment(installment);

            }
        }

    }
}
