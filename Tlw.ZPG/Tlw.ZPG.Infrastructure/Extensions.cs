using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tlw.ZPG.Infrastructure
{
    public static class Extensions
    {
        public static Expression<Func<TEntity, TResult>> GetMember<TEntity, TResult>(String memberName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "p");
            MemberExpression member = Expression.MakeMemberAccess(parameter, typeof(TEntity).GetMember(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Single());
            Expression<Func<TEntity, TResult>> expression = Expression.Lambda<Func<TEntity, TResult>>(member, parameter);
            return (expression);
        }
    }
}
