﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UsersApp.Domain;

namespace UsersApp.Infrastructure
{
	public class AppDbContext: DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}

