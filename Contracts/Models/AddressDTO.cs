using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public record AddressDTO(int PersonID, string PersonName, string PostalCode, string Street, string City);
}
