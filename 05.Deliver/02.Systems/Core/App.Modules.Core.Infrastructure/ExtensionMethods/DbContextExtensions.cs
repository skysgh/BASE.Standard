﻿// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    // Class to allow for use of EF's Include statement
    // from other assemblies, without needing to take 
    // a direct reference to EF.
    // Ie. App.Modules.Core.Domain Services and any specific Repositories 
    // can use 'Include'. 
    public static class QueryableEFExtgensions
    {
        public static IQueryable Include(this IQueryable source, string path)
        {
            throw new NotImplementedException();
            //return QueryableExtensions.Include(source, path);
        }

        public static IQueryable<T> Include<T>(this IQueryable<T> source, string path)
        {
            throw new NotImplementedException();
            //return QueryableExtensions.Include(source, path);
        }

        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source,
            Expression<Func<T, TProperty>> path)
        {
            throw new NotImplementedException();
            //return QueryableExtensions.Include(source, path);
        }
    }
}