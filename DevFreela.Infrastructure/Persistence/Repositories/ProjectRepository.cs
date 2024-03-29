﻿using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;


namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public  class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectRepository(DevFreelaDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Project>> GetAll()
        {
            return await _dbContext.Projects.ToListAsync();
        }

    }
}
