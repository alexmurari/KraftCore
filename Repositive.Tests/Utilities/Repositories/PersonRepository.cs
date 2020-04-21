﻿namespace Repositive.Tests.Utilities.Repositories
{
    using Repositive.Repository;
    using Repositive.Tests.Utilities.Context;
    using Repositive.Tests.Utilities.Entities;
    using Repositive.Tests.Utilities.Repositories.Contracts;

    /// <summary>
    ///     Provides an <see cref="IPersonRepository"/> implementation for querying and saving instances of <see cref="Person"/>.
    /// </summary>
    internal class PersonRepository : GenericEfRepository<Person>, IPersonRepository
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