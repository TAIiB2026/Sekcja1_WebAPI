using DAL;
using Models;

namespace Seed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PersonEntity> repository = [
                new PersonEntity() {
                    DayOfBirth = new DateOnly(2000, 5, 31),
                    Email = "adam.nowak@iks.pl",
                    Name = "Adam",
                    Phone = "333822032",
                    Surname = "Nowak",
                    Addresses = [
                            new AddressEntity {
                                City = "Gliwice",
                                PostalCode = "40-198",
                                Street = "Akademicka"
                            },
                            new AddressEntity {
                                City = "Katowice",
                                PostalCode = "41-220",
                                Street = "Hutnicza"
                            },
                            new AddressEntity {
                                City = "Warszawa",
                                PostalCode = "01-333",
                                Street = "Złota"
                            },
                        ]
                },
                new PersonEntity() {
                    DayOfBirth = new DateOnly(1998, 11, 12),
                    Email = "ewa.kowalska@iks.pl",
                    Name = "Ewa",
                    Phone = "501234567",
                    Surname = "Kowalska"
                },

                new PersonEntity() {
                    DayOfBirth = new DateOnly(2001, 3, 7),
                    Email = "piotr.wisniewski@iks.pl",
                    Name = "Piotr",
                    Phone = "602345678",
                    Surname = "Wiśniewski"
                },

                new PersonEntity() {
                    DayOfBirth = new DateOnly(1995, 8, 21),
                    Email = "anna.zielinska@iks.pl",
                    Name = "Anna",
                    Phone = "723456789",
                    Surname = "Zielińska"
                },

                new PersonEntity() {
                    DayOfBirth = new DateOnly(2003, 1, 30),
                    Email = "tomasz.wojcik@iks.pl",
                    Name = "Tomasz",
                    Phone = "834567890",
                    Surname = "Wójcik"
                }
            ];


            using(PeopleContext peopleContext = new PeopleContext())
            {
                peopleContext.AddRange(repository);
                peopleContext.SaveChanges();
            }
        }
    }
}
