using Contracts;
using Contracts.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Database
{
    public class PeopleDatabaseRepository : IPeopleService
    {
        private readonly PeopleContext peopleContext;

        public PeopleDatabaseRepository(PeopleContext peopleContext)
        {
            this.peopleContext = peopleContext;
        }

        public async Task<IEnumerable<PersonDTO>> GetAsync()
        {
            //var data2 = await peopleContext.peopleDbSet.Select(x => new
            //{
            //    x.Surname,
            //    x.Name,
            //    x.DayOfBirth,
            //    x.Id
            //})
            //.ToListAsync();

            var data = await peopleContext.peopleDbSet.ToListAsync();

            return data.Select(x => new PersonDTO(x.Id, x.Name, x.Surname, x.DayOfBirth));
        }

        public async Task<PersonDTO?> GetByIDAsync(int Id)
        {
            var data = await peopleContext.peopleDbSet.FirstOrDefaultAsync(x => x.Id == Id);

            if(data == null) return null;

            return new PersonDTO(data.Id, data.Name, data.Surname, data.DayOfBirth);
        }

        public async Task<bool> PostAsync(NewPersonDTO newPersonDTO)
        {
            PersonEntity personEntity = new PersonEntity
            {
                DayOfBirth = newPersonDTO.DateOfBirth,
                Surname = newPersonDTO.Surname,
                Name = newPersonDTO.Name,
                Phone = "",
                Email = ""
            };

            await peopleContext.AddAsync(personEntity);

            try
            {
                await peopleContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var data = await peopleContext.peopleDbSet.FindAsync(id);

            if(data is not null)
            {
                peopleContext.Remove(data);
                await peopleContext.SaveChangesAsync();
            }
        }

        public async Task Delete2Async(int id)
        {
            await peopleContext.peopleDbSet.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task AddAddress(int personID, string postalCode, string city, string street)
        {
            PersonEntity personEntity = await peopleContext.peopleDbSet.FindAsync(personID);

            AddressEntity addressEntity = new AddressEntity
            {
                City = city,
                Street = street,
                PostalCode = postalCode,
                PersonEntity = personEntity
            };

            await peopleContext.AddAsync(addressEntity);
            await peopleContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AddressDTO>> GetAddresses(int personID)
        {
            var personEntity = await peopleContext.peopleDbSet
                .Include(x => x.Addresses)
                .FirstOrDefaultAsync(p => p.Id == personID);

            return personEntity.Addresses.Select(x => new AddressDTO(x.PersonEntity.Id, x.PersonEntity.Name, x.PostalCode, x.Street, x.City));
        }
    }
}
