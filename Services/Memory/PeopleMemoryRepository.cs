using Contracts;
using Contracts.Models;
using Models;

namespace Services.Memory
{
    public class PeopleMemoryRepository : IPeopleService
    {
        private static int ID_GEN = 1;

        private static readonly List<PersonEntity> repository = [
                new PersonEntity() {
                    DayOfBirth = new DateOnly(2000, 5, 31),
                    Email = "adam.nowak@iks.pl",
                    Id = ID_GEN++,
                    Name = "Adam",
                    Phone = "333822032",
                    Surname = "Nowak"
                },
                new PersonEntity() {
                    DayOfBirth = new DateOnly(1998, 11, 12),
                    Email = "ewa.kowalska@iks.pl",
                    Id = ID_GEN++,
                    Name = "Ewa",
                    Phone = "501234567",
                    Surname = "Kowalska"
                },

                new PersonEntity() {
                    DayOfBirth = new DateOnly(2001, 3, 7),
                    Email = "piotr.wisniewski@iks.pl",
                    Id = ID_GEN++,
                    Name = "Piotr",
                    Phone = "602345678",
                    Surname = "Wiśniewski"
                },

                new PersonEntity() {
                    DayOfBirth = new DateOnly(1995, 8, 21),
                    Email = "anna.zielinska@iks.pl",
                    Id = ID_GEN++,
                    Name = "Anna",
                    Phone = "723456789",
                    Surname = "Zielińska"
                },

                new PersonEntity() {
                    DayOfBirth = new DateOnly(2003, 1, 30),
                    Email = "tomasz.wojcik@iks.pl",
                    Id = ID_GEN++,
                    Name = "Tomasz",
                    Phone = "834567890",
                    Surname = "Wójcik"
                }
            ];

        public Task<IEnumerable<PersonDTO>> GetAsync()
        {
            var res = repository.Select(x => EntityToDTO(x));
            return Task.FromResult(res);
        }

        private PersonDTO EntityToDTO(PersonEntity personEntity)
        {
            return new PersonDTO(personEntity.Id, personEntity.Name, personEntity.Surname, personEntity.DayOfBirth);
        }

        public Task<PersonDTO?> GetByIDAsync(int Id)
        {
            PersonDTO? personDTO;

            var res = repository.Find(x => x.Id == Id);
            if (res is null)
            {
                personDTO = null;
            }
            else
            {
                personDTO = EntityToDTO(res);
            }

            return Task.FromResult(personDTO);
        }

        public Task<bool> PostAsync(NewPersonDTO newPersonDTO)
        {
            bool res;

            if(repository.Count >= 10) 
            {
                res = false;
            }
            else
            {
                PersonEntity personEntity = new()
                {
                    DayOfBirth = newPersonDTO.DateOfBirth,
                    Email = null,
                    Id = ID_GEN++,
                    Name = newPersonDTO.Name,
                    Phone = null,
                    Surname = newPersonDTO.Surname
                };

                repository.Add(personEntity);
                res = true;
            }

            return Task.FromResult(res);
        }

        public Task AddAddress(int personID, string postalCode, string city, string street)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressDTO>> GetAddresses(int personID)
        {
            throw new NotImplementedException();
        }
    }
}
