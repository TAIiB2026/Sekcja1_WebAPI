using Contracts.Models;

namespace Contracts
{
    public interface IPeopleService
    {
        Task AddAddress(int personID, string postalCode, string city, string street);
        Task<IEnumerable<PersonDTO>> GetAsync();
        Task<PersonDTO?> GetByIDAsync(int Id);
        Task<bool> PostAsync(NewPersonDTO newPersonDTO);
        Task<IEnumerable<AddressDTO>> GetAddresses(int personID);
    }
}
