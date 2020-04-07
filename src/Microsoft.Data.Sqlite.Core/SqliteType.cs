// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using static SQLitePCL.raw;

namespace Microsoft.Data.Sqlite
{
    /// <summary>
    ///     Represents the type affinities used by columns in SQLite tables.
    /// </summary>
    /// <seealso href="https://docs.microsoft.com/dotnet/standard/data/sqlite/types">Data Types</seealso>
    public enum SqliteType
    {
        /// <summary>
        ///     A signed integer.
        /// </summary>
        Integer = SQLITE_INTEGER,

        /// <summary>
        ///     A floating point value.
        /// </summary>
        Real = SQLITE_FLOAT,

        /// <summary>
        ///     A text string.
        /// </summary>
        Text = SQLITE_TEXT,

        /// <summary>
        ///     A blob of data.
        /// </summary>
        Blob = SQLITE_BLOB
    }
}
