using System;
using System.Threading.Tasks;
using Data.EFRepository.Base;
using Survey.Core.Abstract.Repository;


namespace Survey.Repository
{
    public partial class AppEfRepository : EntityFrameworkRepository<AppDbContext>, IAppRepository
    {
        public AppEfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
