using Microsoft.EntityFrameworkCore;
using Test_task.Entities;

namespace Test_task.Data
{
    public class CandidateBbContext(DbContextOptions<CandidateBbContext> options)
          : DbContext(options)
    {
        public DbSet<Candidate> Candidates => Set<Candidate>();

    }
}
