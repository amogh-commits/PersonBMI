using System;

namespace PersonBMI
{
    public class Person
    {
        public const double FORMULA = 0.3048;
        public const double DEFAULT_HEIGHT = 5;
        public const double DEFAULT_WEIGHT = 50;

        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int PersonAge { get; set; }
        public double PersonHeight { get; set; }
        public double PersonWeight { get; set; }
        public double PersonBmi { get; private set; }

        public Person(int personId, string personName, int personAge)
        {
            PersonId = personId;
            PersonName = personName;
            PersonAge = personAge;
            PersonHeight = DEFAULT_HEIGHT;
            PersonWeight = DEFAULT_WEIGHT;
            PersonBmi = BmiIndex(); 
        }

        public Person(int personId, string personName, int personAge, double personHeight, double personWeight)
            : this(personId, personName, personAge)
        {
            PersonHeight = personHeight;
            PersonWeight = personWeight;
            PersonBmi = BmiIndex(); 
        }

        private double BmiIndex()
        {
            double heightMeters = PersonHeight * FORMULA;
            double bmiIndex = PersonWeight / (heightMeters * heightMeters);
            return bmiIndex;
        }

        public enum BodyType
        {
            Underweight,
            NormalWeight,
            Overweight,
            Obesity
        }

        public BodyType DetermineBodyType()
        {
            if (PersonBmi < 18.5)
            {
                return BodyType.Underweight;
            }
            else if (PersonBmi >= 18.5 && PersonBmi <= 24.9)
            {
                return BodyType.NormalWeight;
            }
            else if (PersonBmi >= 25 && PersonBmi <= 29.9)
            {
                return BodyType.Overweight;
            }
            else
            {
                return BodyType.Obesity;
            }
        }
        public void PrintDetails()
        {
            Console.WriteLine($"Person Id: {PersonId}");
            Console.WriteLine($"Person Name: {PersonName}");
            Console.WriteLine($"Person Age: {PersonAge}");
            Console.WriteLine($"Person Height: {PersonHeight} feet");
            Console.WriteLine($"Person Weight: {PersonWeight} kg");
            Console.WriteLine($"Person BMI Index: {PersonBmi:F2}");
            Console.WriteLine($"Person Body Type: {DetermineBodyType()}");
            Console.WriteLine();
        }
        public static Person PersonWithMaximumBMI(Person[] persons)
        {
            Person selectedPerson = null;
            double maxBmiIndex = 0;
            foreach (var person in persons)
            {
                if (person.PersonBmi > maxBmiIndex)
                {
                    maxBmiIndex = person.PersonBmi;
                    selectedPerson = person;
                }
            }
            return selectedPerson;
        }
        public static void PrintAllPersons(Person[] persons)
        {
            foreach (var person in persons)
            {
                person.PrintDetails();
            }
        }

    }
}
