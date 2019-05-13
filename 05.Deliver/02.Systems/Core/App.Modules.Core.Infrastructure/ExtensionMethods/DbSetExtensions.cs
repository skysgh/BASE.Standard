﻿using App.Modules.Core.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using FlexLabs.EntityFrameworkCore;

namespace App
{
    public static class DbSetExtensions
    {


        private static DbContext GetContext<TEntity>(this DbSet<TEntity> dbSet)
where TEntity : class
        {
            return (DbContext)dbSet
                .GetType().GetTypeInfo()
                .GetField("_context", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(dbSet);
        }


        public static void AddOrUpdateBasedOnId<TModel>(this DbSet<TModel> dbSet, Expression<Func<TModel, object>> identifierExpression, params TModel[] entities)
            where TModel : class
        {
            foreach (var entity in entities) {
                dbSet.Upsert(entity).On(identifierExpression);
            }
        }

        public static void AddOrUpdateBasedOnId<TModel>(this DbSet<TModel> dbSet,  params TModel[] entities)
            where TModel :class, IHasId<Guid>
        {
            DbContext dbContext = dbSet.GetContext();

            foreach (var entity in entities)
            {
                var existingEntity = dbSet.Find(entity.Id);
                if (existingEntity == null)
                {
                    dbContext.Add(entity);
                }
                else
                {
                    dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                }
            }
        }
    }
}