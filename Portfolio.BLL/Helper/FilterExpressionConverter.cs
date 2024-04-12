using System;
using System.Linq.Expressions;

namespace Portfolio.BLL.Helper
{
	public static class FilterExpressionConverter<TEntity, TDto>
	{
		public static Expression<Func<TEntity, bool>> Convert(Expression<Func<TDto, bool>> filter)
		{
			var parameter = Expression.Parameter(typeof(TEntity), filter.Parameters[0].Name);
			var body = new ParameterReplacer(parameter).Visit(filter.Body);
			return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
		}

		private class ParameterReplacer(ParameterExpression parameter) : ExpressionVisitor
		{
			private readonly ParameterExpression _parameter = parameter;

			protected override Expression VisitParameter(ParameterExpression node)
			{
				return _parameter;
			}

			protected override Expression VisitMember(MemberExpression node)
			{
				if (node.Member.DeclaringType == typeof(TDto))
				{
					var member = typeof(TEntity).GetProperty(node.Member.Name);
					return Expression.Property(_parameter, member);
				}
				return base.VisitMember(node);
			}
		}
	}
}
