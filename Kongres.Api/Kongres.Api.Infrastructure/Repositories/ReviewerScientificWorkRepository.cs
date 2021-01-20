﻿using System.Collections.Generic;
using Kongres.Api.Domain.Entities;
using Kongres.Api.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;
using Kongres.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kongres.Api.Infrastructure.Repositories
{
    public class ReviewerScientificWorkRepository : IReviewerScientificWorkRepository
    {
        private readonly KongresDbContext _context;

        public ReviewerScientificWorkRepository(KongresDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ScientificWork> GetListOfWorksForReviewer(uint reviewerId)
            => _context.ReviewersScienceWorks.Include(x => x.ScientificWork)
                                                .ThenInclude(x => x.Versions)
                                             .Include(x => x.ScientificWork)
                                                .ThenInclude(x => x.MainAuthor)
                                             .Where(x => x.User.Id == reviewerId)
                                             .Select(x => x.ScientificWork);
        public async Task AddAsync(IEnumerable<ReviewersScienceWork> reviewersScienceWorks)
        {
            await _context.ReviewersScienceWorks.AddRangeAsync(reviewersScienceWorks);
            await _context.SaveChangesAsync();
        }
    }
}
