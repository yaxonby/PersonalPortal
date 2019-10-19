﻿using Microsoft.EntityFrameworkCore;

public class RepositoryContextFactory : IRepositoryContextFactory
{
    public RepositoryContext CreateDbContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new RepositoryContext(optionsBuilder.Options);
    }
}