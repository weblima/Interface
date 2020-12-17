using System;
using Contracts.Entities;

namespace Contracts.Services {
    class ContractService {

        private IOnlinePaymentService _paymentService;

        public ContractService(IOnlinePaymentService paymentService) {
            _paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months) {

            double amount = contract.TotalValue / months;

            for (int i = 1; i <= months; i++) {

                DateTime dueDate = contract.Date.AddMonths(i);

                double amountInterest = _paymentService.Interest(amount, i);
                double PaymentFee = _paymentService.PaymentFee(amountInterest);

                Installment installment = new Installment(dueDate, PaymentFee);
                contract.AddInstallment(installment);

            }
        }

    }
}
