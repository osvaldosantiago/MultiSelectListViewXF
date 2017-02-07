using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace MultiSelectListViewXF
{
	public static class Extensions
	{
		public static void SetBinding<T>(this DataTemplate dataTemplate, BindableProperty targetProperty, Expression<Func<T, object>> propertyExpression)
		{
			dataTemplate.SetBinding(targetProperty, GetPropertyName(propertyExpression));
		}

		private static string GetPropertyName<T>(Expression<Func<T, object>> propertyExpression)
		{
			if (propertyExpression == null)
			{
				throw new ArgumentNullException("propertyExpression");
			}

			if (propertyExpression.Body.NodeType != ExpressionType.MemberAccess)
			{
				throw new ArgumentException("Should be a member access lambda expression", "propertyExpression");
			}

			var memberExpression = (MemberExpression)propertyExpression.Body;
			return memberExpression.Member.Name;
		}

		public static IEnumerable<PropertyInfo> GetProperties<T>(Expression<Func<T, object>> propertyExpression)
		{
			return GetProperties(propertyExpression.Body);
		}

		private static IEnumerable<PropertyInfo> GetProperties(Expression expression)
		{
			var memberExpression = expression as MemberExpression;
			if (memberExpression == null) yield break;

			var property = memberExpression.Member as PropertyInfo;
			if (property == null)
			{
				throw new Exception("Expression is not a property accessor");
			}
			foreach (var propertyInfo in GetProperties(memberExpression.Expression))
			{
				yield return propertyInfo;
			}
			yield return property;
		}

		private static string Concat(this IEnumerable<string> items)
		{
			return items.Aggregate("", (agg, item) => agg + item);
		}

		private static IEnumerable<T> Intersperse<T>(this IEnumerable<T> items, T separator)
		{
			var first = true;
			foreach (var item in items)
			{
				if (first) first = false;
				else
				{
					yield return separator;
				}
				yield return item;
			}
		}

		private static string BindTo<T>(Expression<Func<T, object>> propertyExpression)
		{
			var result = (propertyExpression.Body as UnaryExpression).Operand.ToString();
			return result.Substring(2, result.Length - 2);
		}

		public static string BindTo<T>(this T sender, Expression<Func<T, object>> propertyExpression)
		{
			if (propertyExpression.Body is UnaryExpression)
			{
				var result = (propertyExpression.Body as UnaryExpression).Operand.ToString();
				return result.Substring(2, result.Length - 2);
			}
			else if (propertyExpression.Body is MemberExpression)
			{
				return GetProperties<T>(propertyExpression)
					.Select(property => property.Name)
					.Intersperse(".")
					.Concat();
			}

			return String.Empty;
		}
	}
}
