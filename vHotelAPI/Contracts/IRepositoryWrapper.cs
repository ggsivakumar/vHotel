using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vHotelAPI.Contracts
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        void Save();

    }
}
