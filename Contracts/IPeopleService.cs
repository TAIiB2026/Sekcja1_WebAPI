using Contracts.Models;

namespace Contracts
{
    public interface IPeopleService
    {
        Task<IEnumerable<PersonDTO>> GetAsync();
        Task<PersonDTO?> GetByIDAsync(int Id);
        Task<bool> PostAsync(NewPersonDTO newPersonDTO);
    }
}
