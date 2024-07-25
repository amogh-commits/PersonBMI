using System;

namespace PersonBMI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] persons =  {
                new Person (1, "Ram", 23, 5.12, 70),
                new Person(2, "Raj", 45, 6, 70),
                new Person (3, "Ajay", 22, 5.8, 94),
                new Person(4,"Shyam",25)
            };
            Person selectedPerson = Person.PersonWithMaximumBMI(persons);

            Console.WriteLine("Person With Maximum BMI:");
            selectedPerson.PrintDetails();

            Console.WriteLine("Other People are:");
            Person.PrintAllPersons(persons);
        }
    }
}
