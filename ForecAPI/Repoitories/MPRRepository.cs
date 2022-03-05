using ForecAPI.Enums;
using ForecAPI.Interfaces.Repositories;
using ForecAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ForecAPI.Repoitories
{
    public class MPRRepository:BaseRepository<MPR>, IMPRRepository
    {
        public MPRRepository(ForceDbContext forceDbContext):base(forceDbContext)
        {

        }

        public async Task<(List<MPR>,int)> GetAllMPRWithPagination(Dtos.General.PaginationDto pagination,string statusCode,string mprType)
        {
            var Mprs = _forceDbContext.MPRs.Where(a =>GetMprStatusNumber(a.Status) >= GetMprStatusNumber(statusCode)&&!a.Is_Deleted).OrderByDescending(a=>a.Create_Date);
            if (mprType != null)
                Mprs = Mprs.Where(a => a.Type_Code == mprType).OrderByDescending(a => a.Create_Date);
            int length = Mprs.Count();
            return (await Mprs.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync(), length);
        }
        private int GetMprStatusNumber(string status)
        {
            MPRStausEnum statusEnum = (MPRStausEnum)Enum.Parse(typeof(MPRStausEnum), status);
            return ((int)statusEnum);        
        }
    }
}
