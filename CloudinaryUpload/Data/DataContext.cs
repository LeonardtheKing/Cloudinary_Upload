using CloudinaryUpload.Entity;
using Microsoft.EntityFrameworkCore;

namespace CloudinaryUpload.Data;

public class DataContext:DbContext
{

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }


    public DbSet<Photo> Photos { get; set; } = null!;
}
