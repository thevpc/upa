/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



using System.Linq;
namespace Net.TheVpc.Upa.Impl.Uql.Parser.Syntax
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FunctionFactory {

        public static Net.TheVpc.Upa.Expressions.FunctionExpression CreateFunction(string name, System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> args) {
            string uniformName = name.ToLower();
            if (uniformName.Equals("average")) {
                CheckArgCount(name, args, 1);
                return new Net.TheVpc.Upa.Expressions.Avg(args[0]);
            }
            if (uniformName.Equals("min")) {
                CheckArgCount(name, args, 1);
                return new Net.TheVpc.Upa.Expressions.Min(args[0]);
            }
            if (uniformName.Equals("max")) {
                CheckArgCount(name, args, 1);
                return new Net.TheVpc.Upa.Expressions.Max(args[0]);
            }
            if (uniformName.Equals("sum")) {
                CheckArgCount(name, args, 1);
                return new Net.TheVpc.Upa.Expressions.Sum(args[0]);
            }
            if (uniformName.Equals("count")) {
                CheckArgCount(name, args, 1);
                return new Net.TheVpc.Upa.Expressions.Count(args[0]);
            }
            if (uniformName.Equals("d2v")) {
                CheckArgCount(name, args, 1);
                return new Net.TheVpc.Upa.Expressions.D2V(args[0]);
            }
            if (uniformName.Equals("i2v")) {
                CheckArgCount(name, args, 1);
                return new Net.TheVpc.Upa.Expressions.I2V(args[0]);
            }
            if (uniformName.Equals("concat")) {
                return new Net.TheVpc.Upa.Expressions.Concat(args.ToArray());
            }
            if (uniformName.Equals("cast")) {
                CheckArgCount(name, args, 2);
                Net.TheVpc.Upa.Expressions.Expression e = (Net.TheVpc.Upa.Expressions.Expression) args[0];
                Net.TheVpc.Upa.Expressions.Expression type = (Net.TheVpc.Upa.Expressions.Expression) args[1];
                Net.TheVpc.Upa.Types.DataType d = null;
                if (type is Net.TheVpc.Upa.Expressions.Var) {
                    string s = ((Net.TheVpc.Upa.Expressions.Var) type).GetName();
                    if ("string".Equals(s)) {
                        d = Net.TheVpc.Upa.Types.TypesFactory.STRING;
                    } else if ("int".Equals(s)) {
                        d = Net.TheVpc.Upa.Types.TypesFactory.INT;
                    } else if ("double".Equals(s)) {
                        d = Net.TheVpc.Upa.Types.TypesFactory.DOUBLE;
                    } else if ("float".Equals(s)) {
                        d = Net.TheVpc.Upa.Types.TypesFactory.FLOAT;
                    } else if ("long".Equals(s)) {
                        d = Net.TheVpc.Upa.Types.TypesFactory.LONG;
                    } else if ("date".Equals(s)) {
                        d = Net.TheVpc.Upa.Types.TypesFactory.DATE;
                    } else if ("datetime".Equals(s)) {
                        d = Net.TheVpc.Upa.Types.TypesFactory.DATETIME;
                    } else if ("boolean".Equals(s)) {
                        d = Net.TheVpc.Upa.Types.TypesFactory.BOOLEAN;
                    } else {
                        d = new Net.TheVpc.Upa.Types.ManyToOneType(name, null, name, true, true);
                    }
                } else {
                    throw new System.ArgumentException ("Unupported cast type");
                }
                return new Net.TheVpc.Upa.Expressions.Cast(e, d);
            }
            if (uniformName.Equals("coalesce")) {
                return new Net.TheVpc.Upa.Expressions.Coalesce(args);
            }
            if (uniformName.Equals("decode")) {
                return new Net.TheVpc.Upa.Expressions.Decode(args);
            }
            if (uniformName.Equals("sign")) {
                CheckArgCount(name, args, 1);
                return new Net.TheVpc.Upa.Expressions.Sign(args[0]);
            }
            if (uniformName.Equals("now") || uniformName.Equals("currenttimestamp")) {
                CheckArgCount(name, args, 0);
                return new Net.TheVpc.Upa.Expressions.CurrentTimestamp();
            }
            if (uniformName.Equals("currenttime")) {
                CheckArgCount(name, args, 0);
                return new Net.TheVpc.Upa.Expressions.CurrentTime();
            }
            if (uniformName.Equals("today") || uniformName.Equals("currentdate")) {
                CheckArgCount(name, args, 0);
                return new Net.TheVpc.Upa.Expressions.CurrentDate();
            }
            if (uniformName.Equals("currentuser")) {
                CheckArgCount(name, args, 0);
                return new Net.TheVpc.Upa.Expressions.CurrentUser();
            }
            if (uniformName.Equals("dateadd")) {
                CheckArgCount(name, args, 3);
                Net.TheVpc.Upa.Expressions.Expression type = (Net.TheVpc.Upa.Expressions.Expression) args[0];
                Net.TheVpc.Upa.Expressions.Expression count = (Net.TheVpc.Upa.Expressions.Expression) args[1];
                Net.TheVpc.Upa.Expressions.Expression date = (Net.TheVpc.Upa.Expressions.Expression) args[2];
                return new Net.TheVpc.Upa.Expressions.DateAdd((Net.TheVpc.Upa.Expressions.DatePartType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Expressions.DatePartType),((Net.TheVpc.Upa.Expressions.Var) type).GetName().ToUpper())), count, date);
            }
            if (uniformName.Equals("datediff")) {
                CheckArgCount(name, args, 3);
                Net.TheVpc.Upa.Expressions.Expression type = (Net.TheVpc.Upa.Expressions.Expression) args[0];
                Net.TheVpc.Upa.Expressions.Expression start = (Net.TheVpc.Upa.Expressions.Expression) args[1];
                Net.TheVpc.Upa.Expressions.Expression end = (Net.TheVpc.Upa.Expressions.Expression) args[2];
                return new Net.TheVpc.Upa.Expressions.DateDiff((Net.TheVpc.Upa.Expressions.DatePartType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Expressions.DatePartType),((Net.TheVpc.Upa.Expressions.Var) type).GetName().ToUpper())), start, end);
            }
            if (uniformName.Equals("datetrunc")) {
                CheckArgCount(name, args, 2);
                Net.TheVpc.Upa.Expressions.Expression type = (Net.TheVpc.Upa.Expressions.Expression) args[0];
                Net.TheVpc.Upa.Expressions.Expression e = (Net.TheVpc.Upa.Expressions.Expression) args[1];
                return new Net.TheVpc.Upa.Expressions.DateTrunc((Net.TheVpc.Upa.Expressions.DatePartType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Expressions.DatePartType),((Net.TheVpc.Upa.Expressions.Var) type).GetName().ToUpper())), e);
            }
            if (uniformName.Equals("datepart")) {
                CheckArgCount(name, args, 2);
                Net.TheVpc.Upa.Expressions.Expression type = (Net.TheVpc.Upa.Expressions.Expression) args[0];
                Net.TheVpc.Upa.Expressions.Expression e = (Net.TheVpc.Upa.Expressions.Expression) args[1];
                return new Net.TheVpc.Upa.Expressions.DatePart((Net.TheVpc.Upa.Expressions.DatePartType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Expressions.DatePartType),((Net.TheVpc.Upa.Expressions.Var) type).GetName().ToUpper())), e);
            }
            if (uniformName.Equals("monthstart")) {
                switch((args).Count) {
                    case 0:
                        {
                            return new Net.TheVpc.Upa.Expressions.MonthStart();
                        }
                    case 1:
                        {
                            return new Net.TheVpc.Upa.Expressions.MonthStart(args[0]);
                        }
                    case 2:
                        {
                            return new Net.TheVpc.Upa.Expressions.MonthStart(args[0], args[2]);
                        }
                }
                CheckArgCount(name, args, 2);
            }
            if (uniformName.Equals("monthend")) {
                switch((args).Count) {
                    case 0:
                        {
                            return new Net.TheVpc.Upa.Expressions.MonthEnd();
                        }
                    case 1:
                        {
                            return new Net.TheVpc.Upa.Expressions.MonthEnd(args[0]);
                        }
                    case 2:
                        {
                            return new Net.TheVpc.Upa.Expressions.MonthEnd(args[0], args[2]);
                        }
                }
                CheckArgCount(name, args, 2);
            }
            if (uniformName.Equals("exists")) {
                CheckArgCount(name, args, 1);
                return new Net.TheVpc.Upa.Expressions.Exists((Net.TheVpc.Upa.Expressions.QueryStatement) args[0]);
            }
            if (uniformName.Equals("ishierarchydescendant")) {
                if ((args).Count == 3) {
                    return new Net.TheVpc.Upa.Expressions.IsHierarchyDescendent(args[0], args[1], args[2]);
                } else if ((args).Count == 2) {
                    return new Net.TheVpc.Upa.Expressions.IsHierarchyDescendent(args[0], args[1], null);
                } else {
                    throw new System.Exception("function " + name + " expects 2 or 3 argument(s) but found " + (args).Count);
                }
            }
            return new Net.TheVpc.Upa.Impl.Uql.QLFunctionExpression(name, args.ToArray());
        }

        private static void CheckArgCount(string name, System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> args, int count) {
            if ((args).Count != count) {
                throw new System.Exception("function " + name + " expects " + count + " argument(s) but found " + (args).Count);
            }
        }
    }
}
