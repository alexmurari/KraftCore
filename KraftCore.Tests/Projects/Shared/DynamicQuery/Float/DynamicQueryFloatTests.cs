﻿namespace KraftCore.Tests.Projects.Shared.DynamicQuery.Float
{
    using System;
    using System.Linq;
    using KraftCore.Shared.DynamicQuery;
    using KraftCore.Shared.Expressions;
    using KraftCore.Tests.Projects.Shared.DynamicQuery.Float.Contracts;
    using KraftCore.Tests.Utilities;
    using Xunit;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="float"/> type queries.
    /// </summary>
    public class DynamicQueryFloatTests : DynamicQueryTestBase, IDynamicQueryFloatTests
    {
        // Float

        /// <summary>
        ///     Asserts that an <see cref="float"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.Float), randomHydra.Float, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => Math.Abs(t.Float - randomHydra.Float) < 0.01);
            Assert.DoesNotContain(result, t => Math.Abs(t.Float - randomHydra.Float) > 0.01);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.Float), randomHydra.Float, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => Math.Abs(t.Float - randomHydra.Float) > 0.01);
            Assert.DoesNotContain(result, t => Math.Abs(t.Float - randomHydra.Float) < 0.01);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/> <see cref="ExpressionOperator.LessThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Less_Than_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.Float), randomHydra.Float, ExpressionOperator.LessThan));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Float < randomHydra.Float);
            Assert.DoesNotContain(result, t => t.Float >= randomHydra.Float);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/> <see cref="ExpressionOperator.LessThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Less_Than_Or_Equal_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.Float), randomHydra.Float, ExpressionOperator.LessThanOrEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Float <= randomHydra.Float);
            Assert.DoesNotContain(result, t => t.Float > randomHydra.Float);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/> <see cref="ExpressionOperator.GreaterThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Greater_Than_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.Float), randomHydra.Float, ExpressionOperator.GreaterThan));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Float > randomHydra.Float);
            Assert.DoesNotContain(result, t => t.Float <= randomHydra.Float);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/> <see cref="ExpressionOperator.GreaterThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Greater_Than_Or_Equal_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.Float), randomHydra.Float, ExpressionOperator.GreaterThanOrEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Float >= randomHydra.Float);
            Assert.DoesNotContain(result, t => t.Float < randomHydra.Float);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/> <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Contains_On_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomFloats = Utilities.GetRandomItems(HydraArmy.Select(t => t.Float));
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.Float), randomFloats, ExpressionOperator.ContainsOnValue));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomFloats.Contains(t.Float));
            Assert.DoesNotContain(result, t => randomFloats.Contains(t.Float) == false);
        }

        // Float Array

        /// <summary>
        ///     Asserts that an array of <see cref="float"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Array_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.FloatArray), randomHydra.FloatArray, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FloatArray.SequenceEqual(randomHydra.FloatArray));
            Assert.DoesNotContain(result, t => t.FloatArray.SequenceEqual(randomHydra.FloatArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="float"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Array_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.FloatArray), randomHydra.FloatArray, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FloatArray.SequenceEqual(randomHydra.FloatArray) == false);
            Assert.DoesNotContain(result, t => t.FloatArray.SequenceEqual(randomHydra.FloatArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="float"/> <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.FloatArray), randomHydra.FloatArray.ToList(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FloatArray.SequenceEqual(randomHydra.FloatArray));
            Assert.DoesNotContain(result, t => t.FloatArray.SequenceEqual(randomHydra.FloatArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="float"/> <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.FloatArray), randomHydra.FloatArray.ToList(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FloatArray.SequenceEqual(randomHydra.FloatArray) == false);
            Assert.DoesNotContain(result, t => t.FloatArray.SequenceEqual(randomHydra.FloatArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="float"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Array_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomFloat = Utilities.GetRandomItem(HydraArmy.Select(t => t.FloatArray)).FirstOrDefault();
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.FloatArray), randomFloat, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FloatArray.Contains(randomFloat));
            Assert.DoesNotContain(result, t => t.FloatArray.Contains(randomFloat) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="float"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Collection_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.FloatCollection), randomHydra.FloatCollection, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FloatCollection.SequenceEqual(randomHydra.FloatCollection));
            Assert.DoesNotContain(result, t => t.FloatCollection.SequenceEqual(randomHydra.FloatCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="float"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Collection_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.FloatCollection), randomHydra.FloatCollection, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FloatCollection.SequenceEqual(randomHydra.FloatCollection) == false);
            Assert.DoesNotContain(result, t => t.FloatCollection.SequenceEqual(randomHydra.FloatCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="float"/> <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.FloatCollection), randomHydra.FloatCollection.ToArray(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FloatCollection.SequenceEqual(randomHydra.FloatCollection));
            Assert.DoesNotContain(result, t => t.FloatCollection.SequenceEqual(randomHydra.FloatCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="float"/> <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.FloatCollection), randomHydra.FloatCollection.ToArray(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FloatCollection.SequenceEqual(randomHydra.FloatCollection) == false);
            Assert.DoesNotContain(result, t => t.FloatCollection.SequenceEqual(randomHydra.FloatCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="float"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Float_Collection_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomFloat = Utilities.GetRandomItem(HydraArmy.Select(t => t.FloatCollection)).FirstOrDefault();
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.FloatCollection), randomFloat, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FloatCollection.Contains(randomFloat));
            Assert.DoesNotContain(result, t => t.FloatCollection.Contains(randomFloat) == false);
        }
    }
}