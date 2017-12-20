using ChurrascoManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurrascoManager.DAL
{
    public class ChurrascoInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ChurrascoContext>
    {
        protected override void Seed(ChurrascoContext context)
        {
            Random random = new Random();

            #region Persons
            var persons = new List<Person>
            {
                new Person { Name = "Fabian" },
                new Person { Name = "Roberta" },
                new Person { Name = "Tania" },
                new Person { Name = "Kahuê" },
                new Person { Name = "Henery" },
                new Person { Name = "Paulo" },
                new Person { Name = "Gui" },
                new Person { Name = "Luine" },
            };
            persons.ForEach(p => context.Persons.Add(p));
            context.SaveChanges();
            #endregion

            #region Events
            StringBuilder lorem = new StringBuilder();
            lorem.Append("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ");
            lorem.Append("Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ");
            lorem.Append("Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. ");
            lorem.Append("Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            string defaultObservationOfEvent = lorem.ToString();
            var events = new List<Event>
            {
                new Event { Date = DateTime.Parse("2017-12-13"), Description = "Churraso final de ano", Observation = defaultObservationOfEvent, SpentDrink = random.Next(120, 380), SpentFood = random.Next(120, 380) },
                new Event { Date = DateTime.Parse("2018-01-05"), Description = "Churraso de ano novo", Observation = defaultObservationOfEvent, SpentDrink = random.Next(120, 380), SpentFood = random.Next(120, 380) },
                new Event { Date = DateTime.Parse("2018-04-17"), Description = "Aniversário do Fabian", Observation = defaultObservationOfEvent, SpentDrink = random.Next(120, 380), SpentFood = random.Next(120, 380) },
            };

            // company month birthdays
            for (int i = 1; i < 12; i++)
            {
                string dateToParse = string.Format("2018-{0}-01", i.ToString().PadLeft(2, '0'));
                events.Add(new Event
                {
                    Date = Helpers.hDateTime.GetLastFridayOfTheMonth(DateTime.Parse(dateToParse)),
                    Description = "Churraso aniversariantes do mês",
                    Observation = defaultObservationOfEvent,
                    SpentDrink = random.Next(120, 380),
                    SpentFood = random.Next(120, 380)
                });
            }
            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();
            #endregion

            #region Enrollments
            var enrollments = new List<Enrollment>();
            string defaultObservationOfEnrollment = "Fico só até as ";

            foreach (var item in events)
            {
                // vamos randomizar a quantidade de participantes em cada evento
                var participants = persons.Take(random.Next(3, persons.Count));

                foreach (var person in participants)
                {
                    enrollments.Add(new Enrollment
                    {
                        EventID = item.ID,
                        PersonID = person.ID,
                        Paid = random.Next(2) == 0,
                        Drink = random.Next(2) == 0,
                        Amount = random.Next(10, 60),
                        // adiciona uma observação randomica
                        Observation = person.ID % 2 == 1 ? defaultObservationOfEnrollment + random.Next(24) : null
                    });
                }
            }
            enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();
            #endregion
        }
    }
}