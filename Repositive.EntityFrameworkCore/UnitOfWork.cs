﻿namespace Repositive.EntityFrameworkCore
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Repositive.Contracts;
    using Repositive.EntityFrameworkCore.Extensions;

    /// <summary>
    ///     Implements the unit of work pattern and provides methods for coordinately committing changes between repositories.
    /// </summary>
    /// <typeparam name="TContext">
    ///     The type used as the database context.
    ///     Must be of <see cref="DbContext"/> type or derive from it.
    /// </typeparam>
    public sealed class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitOfWork{TContext}"/> class.
        /// </summary>
        /// <param name="context">
        ///     The database context.
        /// </param>
        public UnitOfWork(TContext context)
        {
            Context = context.ThrowIfNull(nameof(context));
        }

        /// <summary>
        ///     Gets the database context.
        /// </summary>
        internal TContext Context { get; }

        /// <summary>
        ///     Commits all changes made in this unit of work context to the database.
        /// </summary>
        /// <returns>The number of affected rows in the database.</returns>
        public int Commit()
        {
            return Context.SaveChanges();
        }

        /// <summary>
        ///     Asynchronously commits all changes made in this unit of work context to the database.
        /// </summary>
        /// <param name="cancellationToken">
        ///     The token that propagates a cancellation request to interrupt the operation.
        /// </param>
        /// <returns>
        ///     A task that represents the asynchronous commit operation.
        ///     The task result contains the number of affected rows in the database.
        /// </returns>
        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}