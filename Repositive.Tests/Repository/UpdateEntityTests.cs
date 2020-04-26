﻿namespace Repositive.Tests.Repository
{
    using Repositive.Domain.Contracts.Repository;
    using Repositive.Tests.Utilities;
    using Repositive.Tests.Utilities.Repositories.Contracts;
    using Xunit;

    /// <summary>
    ///     Tests the repository methods responsible for updating entities.
    /// </summary>
    public class UpdateEntityTests
    {
        /// <summary>
        ///     The person repository.
        /// </summary>
        private readonly IPersonRepository _personRepository;

        /// <summary>
        ///     The database helper.
        /// </summary>
        private readonly DatabaseHelper _databaseHelper;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UpdateEntityTests"/> class.
        /// </summary>
        /// <param name="personRepository">
        ///     The person repository.
        /// </param>
        /// <param name="databaseHelper">
        ///     The database helper.
        /// </param>
        public UpdateEntityTests(IPersonRepository personRepository, DatabaseHelper databaseHelper)
        {
            _personRepository = personRepository;
            _databaseHelper = databaseHelper;
        }

        /// <summary>
        ///     Asserts that the <see cref="IGenericRepository{TEntity}.Update"/> is operating correctly when ignoring related entities.
        /// </summary>
        [Fact]
        public void Assert_Update_Entity_Without_Related_Entities_Is_Successful()
        {
            // Arrange
            var person = DataGenerator.PickRandomItem(_databaseHelper.GetPersons());

            // Act
            _personRepository.Update(person, false);
            var affectedRows = _personRepository.SaveChanges();

            // Assert
            Assert.Equal(1, affectedRows);
        }

        /// <summary>
        ///     Asserts that the <see cref="IGenericRepository{TEntity}.UpdateRange"/> is operating correctly when ignoring related entities.
        /// </summary>
        [Fact]
        public void Assert_Update_Entity_Range_Without_Related_Entities_Is_Successful()
        {
            // Arrange
            var persons = DataGenerator.PickRandomItemRange(_databaseHelper.GetPersons(), 50);

            // Act
            _personRepository.UpdateRange(persons, false);
            var affectedRows = _personRepository.SaveChanges();

            // Assert
            Assert.Equal(persons.Count, affectedRows);
        }

        /// <summary>
        ///     Asserts that the <see cref="IGenericRepository{TEntity}.Update"/> is operating correctly when considering related entities.
        /// </summary>
        [Fact]
        public void Assert_Update_Entity_With_Related_Entities_Is_Successful()
        {
            // Arrange
            var person = DataGenerator.PickRandomItem(_databaseHelper.GetPersons());

            // Act
            _personRepository.Update(person);
            var affectedRows = _personRepository.SaveChanges();

            // Assert
            Assert.True(affectedRows > 1);
        }

        /// <summary>
        ///     Asserts that the <see cref="IGenericRepository{TEntity}.UpdateRange"/> is operating correctly when considering related entities.
        /// </summary>
        [Fact]
        public void Assert_Update_Entity_Range_With_Related_Entities_Is_Successful()
        {
            // Arrange
            var persons = DataGenerator.PickRandomItemRange(_databaseHelper.GetPersons(), 50);

            // Act
            _personRepository.UpdateRange(persons);
            var affectedRows = _personRepository.SaveChanges();

            // Assert
            Assert.True(affectedRows > persons.Count);
        }
    }
}
