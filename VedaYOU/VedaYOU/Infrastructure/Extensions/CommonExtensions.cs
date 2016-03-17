using System;
using System.Linq.Expressions;
using System.Reflection;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace VedaYOU.Infrastructure.Extensions
{
    public static class CommonExtensions
    {
        public static TResult GetPropertyValue<TSource, TResult>(this IPublishedContent content,
          Expression<Func<TSource, object>> propertyRefExpr)
        {
            var propertyName = GetUmbracoPropertyAlias(propertyRefExpr);
            var result = content.GetPropertyValue<TResult>(propertyName);
            return result;
        }

        public static string GetUmbracoPropertyAlias<T>(Expression<Func<T, object>> propertyRefExpr)
        {
            var memberInfo = GetPropertyInfo<T>(propertyRefExpr);
            string result = memberInfo.Name;
            result = GetUmbracoPropertyAliasDefault(result);
            return result;
        }

        public static MemberInfo GetPropertyInfo<T>(Expression<Func<T, object>> propertyRefExpr)
        {
            return GetPropertyInfoCore(propertyRefExpr.Body);
        }

        private static MemberInfo GetPropertyInfoCore(Expression propertyRefExpr)
        {
            if (propertyRefExpr == null)
                throw new ArgumentNullException(nameof(propertyRefExpr), "propertyRefExpr is null.");

            MemberExpression memberExpr = propertyRefExpr as MemberExpression;
            if (memberExpr == null)
            {
                UnaryExpression unaryExpr = propertyRefExpr as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                    memberExpr = unaryExpr.Operand as MemberExpression;
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
                return memberExpr.Member;

            throw new ArgumentException("No property reference expression was found.",
                             "propertyRefExpr");
        }

        private static string GetUmbracoPropertyAliasDefault(string result)
        {
            result = Char.ToLowerInvariant(result[0]) + result.Substring(1);
            return result;
        }

    }
}