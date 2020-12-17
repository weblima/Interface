using System;
using System.Globalization;

namespace Contracts.Entities {
    class Installment {
        public DateTime DueDate { get; set; }
        public Double Amount { get; set; }
        public Installment() {

        }
        public Installment(DateTime dueDate, double amount) {
            DueDate = dueDate;
            Amount = amount;
        }

    }
}
