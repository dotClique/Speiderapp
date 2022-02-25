using System.Linq;

namespace SpeiderappAPI.Models.Interfaces
{
    public static class ISoftDeleteExtensions
    {
        public static IQueryable<TSoftDeletable> ExcludeDeleted<TSoftDeletable>(
            this IQueryable<TSoftDeletable> queryable) where TSoftDeletable : ISoftDeletable
        {
            return queryable.Where(e => e.DeletedAt == null);
        }

        public static IQueryable<TSoftDeletable> OnlyDeleted<TSoftDeletable>(this IQueryable<TSoftDeletable> queryable)
            where TSoftDeletable : ISoftDeletable
        {
            return queryable.Where(e => e.DeletedAt != null);
        }
    }
}
