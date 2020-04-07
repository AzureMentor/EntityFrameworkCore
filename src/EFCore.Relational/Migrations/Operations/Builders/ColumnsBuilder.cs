// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Microsoft.EntityFrameworkCore.Migrations.Operations.Builders
{
    /// <summary>
    ///     A builder for <see cref="ColumnOperation" /> operations.
    /// </summary>
    public class ColumnsBuilder
    {
        private readonly CreateTableOperation _createTableOperation;

        /// <summary>
        ///     Constructs a builder for the given <see cref="CreateTableOperation" />.
        /// </summary>
        /// <param name="createTableOperation"> The operation. </param>
        public ColumnsBuilder([NotNull] CreateTableOperation createTableOperation)
        {
            Check.NotNull(createTableOperation, nameof(createTableOperation));

            _createTableOperation = createTableOperation;
        }

        /// <summary>
        ///     <para>
        ///         Adds a <see cref="AddColumnOperation" /> to the <see cref="CreateTableOperation" />.
        ///     </para>
        ///     <para>
        ///         Note that for nullable parameters a <c>null</c> value means not-specified.
        ///     </para>
        /// </summary>
        /// <typeparam name="T"> The CLR type of the column. </typeparam>
        /// <param name="type"> The database type of the column. </param>
        /// <param name="unicode"> Indicates whether or not the column will store Unicode data. </param>
        /// <param name="maxLength"> The maximum length for data in the column. </param>
        /// <param name="rowVersion"> Indicates whether or not the column will act as a rowversion/timestamp concurrency token. </param>
        /// <param name="name"> The column name. </param>
        /// <param name="nullable"> Indicates whether or not the column can store <c>NULL</c> values. </param>
        /// <param name="defaultValue"> The default value for the column. </param>
        /// <param name="defaultValueSql"> The SQL expression to use for the column's default constraint. </param>
        /// <param name="computedColumnSql"> The SQL expression to use to compute the column value. </param>
        /// <param name="fixedLength"> Indicates whether or not the column is constrained to fixed-length data. </param>
        /// <param name="comment"> A comment to be applied to the table. </param>
        /// <param name="precision"> The maximum number of digits for data in the column. </param>
        /// <param name="scale"> The maximum number of decimal places for data in the column. </param>
        /// <returns> The same builder so that multiple calls can be chained. </returns>
        public virtual OperationBuilder<AddColumnOperation> Column<T>(
            [CanBeNull] string type = null,
            bool? unicode = null,
            int? maxLength = null,
            bool rowVersion = false,
            [CanBeNull] string name = null,
            bool nullable = false,
            [CanBeNull] object defaultValue = null,
            [CanBeNull] string defaultValueSql = null,
            [CanBeNull] string computedColumnSql = null,
            bool? fixedLength = null,
            [CanBeNull] string comment = null,
            int? precision = null,
            int? scale = null)
        {
            var operation = new AddColumnOperation
            {
                Schema = _createTableOperation.Schema,
                Table = _createTableOperation.Name,
                Name = name,
                ClrType = typeof(T),
                ColumnType = type,
                IsUnicode = unicode,
                MaxLength = maxLength,
                IsRowVersion = rowVersion,
                IsNullable = nullable,
                DefaultValue = defaultValue,
                DefaultValueSql = defaultValueSql,
                ComputedColumnSql = computedColumnSql,
                IsFixedLength = fixedLength,
                Comment = comment,
                Precision = precision,
                Scale = scale
            };
            _createTableOperation.Columns.Add(operation);

            return new OperationBuilder<AddColumnOperation>(operation);
        }

        #region Hidden System.Object members

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns> A string that represents the current object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///     Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object. </param>
        /// <returns> true if the specified object is equal to the current object; otherwise, false. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        /// <returns> A hash code for the current object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        #endregion
    }
}
