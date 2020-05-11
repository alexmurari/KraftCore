﻿namespace Repositive.Contracts
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    ///     Provides methods for coordinately committing changes between repositories.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         As the objective of this contract is to coordinate commit operations between different
    ///         repositories, no commit operation should be made directly from a repository that uses the
    ///         unit of work pattern, but rather use the methods provided by this interface for committing.
    ///     </para>
    ///     <para>
    ///         Avoid making the <see cref="ISaveableRepository"/> contract available in repositories
    ///         that use unit of work, as all commit operations should be made through this interface.
    ///     </para>
    /// </remarks>
    public interface IUnitOfWork
    {
        /// <summary>
        ///     Commits all changes made in this unit of work context to the database.
        /// </summary>
        /// <returns>The number of affected rows in the database.</returns>
        int Commit();

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
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}