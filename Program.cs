using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleEF
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DeleteCurrency();
            //UpdateCurrency();
            //InsertNewCurrency();
            // DisplayCountOfEmployeeAndPerson();
            // QueryFilterPerson();
            Console.ReadLine();
        }

        static void DeleteCurrency()
        {
            using (PeopleContext context = new PeopleContext())
            {
                Currency currency = (from c in context.Currencies
                                     where c.Code == "!!!"
                                     select c).Single();
                context.Currencies.Remove(currency);
                context.SaveChanges();
            }
        }

        static void UpdateCurrency()
        {
            using (PeopleContext context = new PeopleContext())
            {
                IEnumerable<Currency> currencies = context.Currencies;

                foreach (Currency currency in currencies)
                {
                    currency.Name += "!";
                }

                context.SaveChanges();
            }
        }

        static void InsertNewCurrency()
        {
            using (PeopleContext context = new PeopleContext())
            {
                Currency newCurrency = new Currency();
                newCurrency.Code = "!!!";
                newCurrency.Name = "THE BEST CURRENCY EVER!!!";
                context.Currencies.Add(newCurrency);
                context.SaveChanges();
            }
        }

        static void DisplayCountOfEmployeeAndPerson()
        {
            using (PeopleContext context = new PeopleContext())
            {
                Console.WriteLine(context.People.Count());
                Console.WriteLine(context.Employees.Count());

                Employee employee = context.Employees.OrderByDescending(e => e.Id).First();
                Console.WriteLine($"{employee.Id} {employee.LastName} {employee.JobTitle}");

                Person person = context.People.OrderByDescending(p => p.Id).First();
                Console.WriteLine($"{person.Id} {person.LastName}");
            }
        }

        static void QueryFilterPerson()
        {
            string firstLetter = "S";

            using (PeopleContext context = new PeopleContext())
            {
                //IEnumerable<Person> query = context.People
                //    .Where(p => p.LastName.StartsWith(firstLetter) 
                //                && p.ModifiedDate >= new DateTime(2008, 5, 1)
                //                && p.ModifiedDate <= new DateTime(2008, 5, 30))
                //    .OrderBy(p => p.ModifiedDate)
                //    .ThenBy(p => p.LastName)
                //    .ThenBy(p => p.FirstName);

                IEnumerable<Person> query = from p in context.People
                                            where p.LastName.StartsWith(firstLetter)
                                               && p.ModifiedDate >= new DateTime(2008, 5, 1)
                                               && p.ModifiedDate <= new DateTime(2008, 5, 30)
                                            orderby p.ModifiedDate, p.LastName, p.FirstName
                                            select p;
                
                foreach (Person p in query)
                {
                    if (p.MiddleName != null)
                    {
                        Console.WriteLine($"{p.LastName,12}, {p.FirstName,12} {p.MiddleName.Substring(0, 1)}. : {p.ModifiedDate.ToString("MM/dd/yyyy")}");
                    }
                    else
                    {
                        Console.WriteLine($"{p.LastName,12}, {p.FirstName,12}    : {p.ModifiedDate.ToString("MM/dd/yyyy")}");
                    }
                }
            }
        }
    }
}
