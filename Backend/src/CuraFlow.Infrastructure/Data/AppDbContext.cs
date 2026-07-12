namespace CuraFlow.Infrastructure.Data;

using CuraFlow.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext;