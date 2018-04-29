using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSection.Classes;

namespace CSharpSection
{
    class Program
    {
        static IOperations am;
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BankAccount bankAccount1 = new BankAccount(1222.33f, "Haitn");
            Console.WriteLine(bankAccount1.Balance);

            BankAccount bankAccount2 = new BankAccount(1333.33f, "tnHai");

            ChildBankAccount bankAccount3 = new ChildBankAccount(1333.33f, "tnHai", "Haitn");
            Console.WriteLine(bankAccount1.AddBalance(1000f));
            Console.WriteLine(bankAccount2.AddBalance(-2000f));
            Console.WriteLine(bankAccount2.AddBalance(-2000f, true));
            Console.WriteLine(bankAccount3.Parent);
            
            am = new AdvancedMath();
            Console.WriteLine(am.Remainder(7, 3));

            //using asynchronouns method
            GetData();
            
            Console.ReadLine();
        }

        
        //call asynchoronous method
        async static void GetData()
        {
            BankAccount bankAccount = new BankAccount(5000f,"HaiTread");
            Console.WriteLine("Login");
            var task = await bankAccount.GetData();
            Console.WriteLine(task);
        }
        
        interface IOperations
        {
            float Remainder(float dividend, float divisor);
        }

        class SimpleMath
        {
            public static float Add(float n1, float n2)
            {
                return n1 + n2;
            }
        }

        //inheritance and implementing interface
        class AdvancedMath : SimpleMath, IOperations
        {
            public float Remainder(float dividend, float divisor)
            {
                return dividend % divisor; 
            }
        }
    }
}
