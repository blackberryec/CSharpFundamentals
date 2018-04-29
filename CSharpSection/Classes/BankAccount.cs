using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpSection.Classes
{
    public class BankAccount
    {
        //variable
        private float balance;

        //property
        public float Balance
        {
            get
            {
                return balance;
            }
            private set
            {
                if (value >= 0)
                {
                    balance = value;
                }
                else
                {
                    balance = 0;
                }
            }
        }

        private string owner;

        //overload contructor 
        public BankAccount(float balance, string owner)
        {
            Balance = balance;
            this.owner = owner;
        }

        //method
        //virtual to able overriding
        public virtual float AddBalance(float balanceToBeAdded)
        {
            Balance = balance + balanceToBeAdded;
            return Balance;
        }

        //overload method : same name but differance signature
        //virtual to able overriding
        public virtual float AddBalance(float balanceToBeAdded, bool balanceCanBeNagative)
        {
            if (balanceCanBeNagative)
            {
                balance = balance + balanceToBeAdded;
            }
            else
            {
                Balance = balance + balanceToBeAdded;
            }
            return Balance;
        }
        
        //Asynchronouns method
        public async Task<string> GetData()
        {
            Thread.Sleep(2000);
            return "Completed";
        }
    }

    //Inheritance
    public class ChildBankAccount : BankAccount
    {
        public string Parent { get; set; }
        public ChildBankAccount(float balance, string owner, string parent) : base(balance, owner)
        {
            Parent = parent;
        }

        //override method had abled by virtual
        public override float AddBalance(float balanceToBeAdded)
        {
            if (balanceToBeAdded >= -10)
            {
                return base.AddBalance(balanceToBeAdded);
            }
            else
            {
                return Balance;
            }
        }

        //override method had abled by virtual
        public override float AddBalance(float balanceToBeAdded, bool balanceCanBeNagative)
        {
            if (balanceToBeAdded >= -10)
            {
                return base.AddBalance(balanceToBeAdded, balanceCanBeNagative);
            }
            else
            {
                return Balance;
            }
        }
    }
}
