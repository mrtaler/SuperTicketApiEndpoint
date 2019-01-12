namespace SuperTicketApi.Domain.MainContext.Mssql.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;

    /// <summary>
    /// The predicate builder.
    /// </summary>
    public static class SqlParametrBuilder
    {
        /// <summary>
        /// The and.
        /// </summary>
        private const string And = " and ";

        /// <summary>
        /// The or.
        /// </summary>
        private const string Or = " or ";

        /// <summary>
        /// The ops.
        /// </summary>
        private static Dictionary<ExpressionType, string> ops = new Dictionary<ExpressionType, string>();

        static SqlParametrBuilder()
        {
            ops.Add(ExpressionType.Equal, " = ");
            ops.Add(ExpressionType.NotEqual, " != ");
            ops.Add(ExpressionType.GreaterThan, " > ");
            ops.Add(ExpressionType.GreaterThanOrEqual, " >= ");
            ops.Add(ExpressionType.LessThan, " <  ");
            ops.Add(ExpressionType.LessThanOrEqual, " <=  ");
            ops.Add(ExpressionType.And, " and  ");
            ops.Add(ExpressionType.AndAlso, " and  ");
            ops.Add(ExpressionType.Or, " or  ");
            ops.Add(ExpressionType.OrElse, " or  ");
        }

        public static string MakeFilter<T>(Expression<Func<T, bool>> predicate)
        {
            var qq = predicate.Compile();
            var member = predicate.Body as BinaryExpression;
            if (predicate == null || member == null)
            {
                throw new ArgumentNullException("Your predicate is not in correct format!!!");
            }

            var sql = CheckExpression(member);
            return sql;

        }

        static string MakeMethodCallPredicate(MethodCallExpression expression)
        {
            StringBuilder sql = new StringBuilder();
            if (expression.Method.Name == "StartsWith")
            {
                sql.Append(string.Format("{0} like '{1}%'", (expression.Object as MemberExpression).Member.Name, expression.Arguments[0]).Replace("\"", string.Empty));

            }

            return sql.ToString();
        }

        static string MakeOperationPredicate(BinaryExpression expression)
        {
            StringBuilder sql = new StringBuilder();
            if (expression.Left.NodeType == ExpressionType.MemberAccess)
            {
                sql.Append((expression.Left as MemberExpression).Member.Name);

            }

            if (expression.Left.NodeType == ExpressionType.Constant)
            {
                sql.Append((expression.Left as ConstantExpression).Value);
            }

            sql.Append(ops[expression.NodeType]);


            if (expression.Right.NodeType == ExpressionType.MemberAccess)
            {
                /*  var www = (expression.Right as MemberExpression).Expression;
            var value = getValue(www as ConstantExpression);*/
                sql.Append((expression.Right as MemberExpression).Member.Name);
            }

            if (expression.Right.NodeType == ExpressionType.Constant)
            {
                var value = GetValue(expression.Right as ConstantExpression);

                if (value == "null")
                {
                    sql.Replace("=", "is");
                }

                sql.Append(value);
            }

            return sql.ToString();
        }

        static object GetValue(ConstantExpression expression)
        {

            switch (expression.Type.ToString())
            {
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                    return expression.Value;
                case "System.Object":
                    return "null";
                default:
                    return "'" + expression.Value + "'";
            }
        }

        static string CheckExpression(BinaryExpression expression)
        {
            StringBuilder sql = new StringBuilder();
            if (IsOperation(expression.NodeType))
            {
                sql.Append(MakeOperationPredicate(expression));
            }

            if (expression.Left.NodeType == ExpressionType.AndAlso)
            {
                sql.Append(CheckExpression(expression.Left as BinaryExpression));
            }

            if (expression.Left.NodeType == ExpressionType.OrElse)
            {
                sql.Append(CheckExpression(expression.Left as BinaryExpression));
            }

            if (expression.Left.NodeType == ExpressionType.Call)
            {
                sql.Append(MakeMethodCallPredicate(expression.Left as MethodCallExpression));
            }

            if (IsOperation(expression.Left.NodeType))
            {
                sql.Append(MakeOperationPredicate(expression.Left as BinaryExpression));
            }

            if (expression.NodeType == ExpressionType.OrElse)
            {
                sql.Append(Or);
            }

            if (expression.NodeType == ExpressionType.AndAlso)
            {
                sql.Append(And);
            }

            if (expression.Right.NodeType == ExpressionType.AndAlso)
            {
                sql.Append(CheckExpression(expression.Right as BinaryExpression));
            }

            if (expression.Right.NodeType == ExpressionType.OrElse)
            {
                sql.Append(CheckExpression(expression.Right as BinaryExpression));
            }

            if (expression.Right.NodeType == ExpressionType.Call)
            {

                sql.Append(MakeMethodCallPredicate(expression.Right as MethodCallExpression));
            }

            if (IsOperation(expression.Right.NodeType))
            {
                sql.Append(MakeOperationPredicate(expression.Right as BinaryExpression));
            }

            return sql.ToString();
        }

        static bool IsOperation(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.Equal:

                case ExpressionType.NotEqual:

                case ExpressionType.GreaterThan:

                case ExpressionType.GreaterThanOrEqual:

                case ExpressionType.LessThan:

                case ExpressionType.LessThanOrEqual:
                    return true;

            }
            return false;
        }
    }
}
