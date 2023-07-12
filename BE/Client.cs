using System;

namespace BE
{
    [path(@"clients.xml", "Client", "Credit_card")]
    public class Client
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Address Address { get; set; }

        public string Credit_card { get; set; }

        public float overdraft { get; set; }// יתרה(כמות של כסף לביזבוז במסעדה) 

        public override string ToString()

        {

            return string.Format("Client\nname: {0}, address: {1}, credit card number: { 2}\n", Name, Address, Credit_card);

        }

        public Client()

        {
            Address = new Address();
            overdraft = 1000;
            Random r=new Random();
            for (int i = 0; i < 7; i++)
            {
                Credit_card += r.Next(0, 10);
            }

        }
    }
}
