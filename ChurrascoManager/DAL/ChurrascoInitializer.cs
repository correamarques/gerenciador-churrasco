using ChurrascoManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurrascoManager.DAL
{
    public class ChurrascoInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ChurrascoContext>
    {
        protected override void Seed(ChurrascoContext context)
        {
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
            string defaultObservationOfEvent = "Vamos comprar as coisas tudo no mercado";
            var events = new List<Event>
            {
                new Event { Date = DateTime.Parse("2017-12-13"), Description = "Churraso final de ano", Observation = defaultObservationOfEvent },
                new Event { Date = DateTime.Parse("2018-01-05"), Description = "Churraso de ano novo", Observation = defaultObservationOfEvent },
                new Event { Date = DateTime.Parse("2018-04-17"), Description = "Aniversário do Fabian", Observation = defaultObservationOfEvent },
            };

            // company month birthdays
            for (int i = 1; i < 12; i++)
            {
                string dateToParse = string.Format("2018-{0}-01", i.ToString().PadLeft(2, '0'));
                events.Add(new Event
                {
                    Date = Helpers.hDateTime.GetLastFridayOfTheMonth(DateTime.Parse(dateToParse)),
                    Description = "Churraso aniversariantes do mês",
                    Observation = defaultObservationOfEvent
                });
            }
            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();
            #endregion

            #region Enrollments
            var enrollments = new List<Enrollment>();

            foreach (var item in events)
            {
                // vamos randomizar a quantidade de participantes em cada evento
                Random random = new Random();
                var participants = persons.Take(random.Next(3, persons.Count));

                foreach (var person in participants)
                {
                    enrollments.Add(new Enrollment
                    {
                        EventID = item.ID,
                        PersonID = person.ID,
                        Paid = random.Next(2) == 0,
                        Drink = random.Next(2) == 0,
                        Amount = random.Next(10, 60)
                    });
                }
            }
            enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();
            #endregion
        }
    }
}