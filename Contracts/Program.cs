using System;
using System.Globalization;
using Contracts.Entities;
using Contracts.Services;

namespace Contracts {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Enter contract data");

            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Contract value: ");
            double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Enter number of installments: ");
            int n = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, totalValue);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(contract, n);

            Console.WriteLine();
            Console.WriteLine("Installments: ");
            foreach (Installment i in contract.Installments) {
                Console.WriteLine(i.DueDate.ToString("dd/MM/yyy") + " - " + i.Amount.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
