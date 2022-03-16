using Microsoft.EntityFrameworkCore;
using SceletonAPI.Domain.Entities;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SceletonAPI.Application.Interfaces
{
    public interface IVTSDBContext
    {
        DbSet<MasterDataUser> MasterDataUser { set; get; }
        
        IStoredProcBuilder loadStoredProcedureBuilder(string val);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
