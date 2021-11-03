using Flight_Tracking.Data.Base;
using Flight_Tracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Tracking.Data.Services
{
    public interface IVolService:IEntityBaseRepository<Vol>
    {
        Task<Vol> GetVolByIdAsync(int id);
        
        Task AddNewMovieAsync(Vol data);
    }
}
