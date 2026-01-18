using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Portfolio.UI.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    //public async Task<MyObject> GetData(string id)
    //{
    //    using var ctx = this.contextFactory.CreateDbContext();
    //    return await ctx.MyDataObjects.FirstOrDefaultAsync(p => p.Id == id);
    //}
}