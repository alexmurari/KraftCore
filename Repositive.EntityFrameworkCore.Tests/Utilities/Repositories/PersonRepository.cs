﻿namespace Repositive.EntityFrameworkCore.Tests.Utilities.Repositories
{
    using Repositive.EntityFrameworkCore.Tests.Utilities.Context;
    using Repositive.EntityFrameworkCore.Tests.Utilities.Entities;
    using Repositive.EntityFrameworkCore.Tests.Utilities.Repositories.Contracts;

    /// <summary>
    ///     Provides a repository pattern implementation for querying and saving <see cref="Person"/> instances.
    /// </summary>
    internal class PersonRepository : Repository<Person, RepositiveContext>, IPersonRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        /// <param name="context">
        ///     The database context.
        /// </param>
        public PersonRepository(RepositiveContext context) : base(context)
        {
        }
    }
}
