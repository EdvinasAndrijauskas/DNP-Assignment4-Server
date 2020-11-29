using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment3.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Managing_Adults.Data.Impl
{
    public class SqliteAdultService : IAdultService
        {
            private AdultContext ctx;

            public SqliteAdultService(AdultContext ctx)
            {
                this.ctx = ctx;
            }

            public async Task<IList<Adult>> GetAdultAsync()
            {
                return await ctx.Adults.ToListAsync();
            }

            public async Task<Adult> AddAdult(Adult todo)
            {
                EntityEntry<Adult> newlyAdded = await ctx.Adults.AddAsync(todo);
                await ctx.SaveChangesAsync();
                return newlyAdded.Entity;
            }

            public async Task<Adult> RemoveAdultAsync(int todoId)
            {
                Adult toDelete = await ctx.Adults.FirstOrDefaultAsync(t => t.Id == todoId);
                if (toDelete != null)
                {
                    ctx.Adults.Remove(toDelete);
                    await ctx.SaveChangesAsync();
                }
                return toDelete;
            }
        }
    }