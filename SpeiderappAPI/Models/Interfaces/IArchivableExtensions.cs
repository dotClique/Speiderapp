using System.Linq;

namespace SpeiderappAPI.Models.Interfaces
{
    public static class IArchivableExtensions
    {
        public static IQueryable<TArchivable> ExcludeArchived<TArchivable>(this IQueryable<TArchivable> queryable)
            where TArchivable : IArchivable
        {
            return queryable.Where(e => e.ArchivedAt == null);
        }

        public static IQueryable<TArchivable> OnlyArchived<TArchivable>(IQueryable<TArchivable> queryable)
            where TArchivable : IArchivable
        {
            return queryable.Where(e => e.ArchivedAt != null);
        }
    }
}
