﻿using Kongres.Api.Domain.Entities;
using Kongres.Api.Infrastructure.Context;
using Kongres.Api.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kongres.Api.Infrastructure.Repositories
{
    public class ScientificWorkRepository : IScientificWorkRepository
    {
        private readonly KongresDbContext _context;

        public ScientificWorkRepository(KongresDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ScientificWork scienceWork)
        {
            await _context.ScientificWorks.AddAsync(scienceWork);
            await _context.SaveChangesAsync();
        }

        public async Task<ScientificWork> GetByAuthorIdAsync(uint userId)
            => await _context.ScientificWorks.FirstOrDefaultAsync(x => x.MainAuthor.Id == userId);

        public async Task<IEnumerable<ScientificWork>> GetApprovedWorksAsync()
            => await _context.ScientificWorks.Include(x => x.MainAuthor)
                                             .Include(x => x.Versions)
                                             .ToListAsync();

        public async Task<ScientificWork> GetWorkByIdAsync(uint scientificWorkId)
            => await _context.ScientificWorks.Include(x => x.MainAuthor)
                                             .Include(x => x.Versions)
                                             .SingleOrDefaultAsync(x => x.Id == scientificWorkId);

        // get information, if the user is a author of work which includes the reviewer
        public async Task<bool> IsAuthorOfScientificWorkByReviewIdAsync(uint userId, uint reviewOfWorkId)
            => await _context.ScientificWorks.Include(x => x.MainAuthor)
                                             .Include(x => x.Versions)
                                                .ThenInclude(x => x.Reviews)
                                             .AnyAsync(x => x.MainAuthor.Id == userId &&
                                                            x.Versions.Any(y => y.Reviews.Any(k => k.Id == reviewOfWorkId)));

        public async Task<bool> IsReviewerOfScientificWorkAsync(uint userId, uint scientificWorkId)
            => await _context.ReviewersScienceWorks.Include(x => x.ScientificWork)
                                                   .Include(x => x.User)
                                                   .AnyAsync(x => x.User.Id == userId &&
                                                                  x.ScientificWork.Id == scientificWorkId);

        public async Task<IEnumerable<ScientificWork>> GetAllBySpecializationAsync(string specialization)
            => await _context.ScientificWorks.Include(x => x.MainAuthor)
                                             .Where(x => x.Specialization == specialization)
                                             .ToListAsync();

        public async Task<byte> GetNumberOfVersionsByAuthorIdAsync(uint userId)
        {
            var scientificWork = await _context.ScientificWorks.Include(x => x.MainAuthor)
                                                               .Include(x => x.Versions)
                                                               .SingleAsync(x => x.MainAuthor.Id == userId);
            return scientificWork.Versions.Last().Version;
        }

        public async Task<uint> GetIdOfWorkByAuthorIdAsync(uint authorId)
            => await _context.ScientificWorks.Where(x => x.MainAuthor.Id == authorId)
                                             .Select(x => x.Id)
                                             .SingleAsync();
    }
}
