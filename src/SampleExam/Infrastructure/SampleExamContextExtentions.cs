using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SampleExam.Infrastructure
{
    public static class SampleExamContextExtentions
    {
        public static async Task<IEnumerable<Domain.Tag>> SaveTagsAsync(this SampleExamContext context,
            IEnumerable<string> tagList,
            CancellationToken cancellationToken)
        {
            var tags = new List<Domain.Tag>();
            foreach (var tag in tagList)
            {
                var t = await context.Tags.FindAsync(tag);
                if (t == null)
                {
                    t = new Domain.Tag()
                    {
                        TagId = tag
                    };
                    await context.Tags.AddAsync(t, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                }
                tags.Add(t);
            }

            return tags;
        }

        public static bool IsModified(this SampleExamContext context, object entity)
        {
            return context.ChangeTracker.Entries().First(x => x.Entity == entity)
            .State == EntityState.Modified;
        }
    }
}