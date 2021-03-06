/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.parser.syntax;

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.expressions.*;
import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.DataTypeFactory;
import net.thevpc.upa.expressions.*;
import net.thevpc.upa.impl.upql.QLFunctionExpression;

import java.util.List;
import net.thevpc.upa.types.ManyToOneType;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class UPQLFunctionsFactory {

    public static FunctionExpression createFunction(String name, List<Expression> args) {
        String uniformName = name.toLowerCase();
        if (uniformName.equals("average")) {
            checkArgCount(name, args, 1);
            return new Avg(args.get(0));
        }
        if (uniformName.equals("min")) {
            checkArgCount(name, args, 1);
            return new Min(args.get(0));
        }
        if (uniformName.equals("max")) {
            checkArgCount(name, args, 1);
            return new Max(args.get(0));
        }
        if (uniformName.equals("distinct")) {
            checkArgCount(name, args, 1);
            return new Distinct(args.toArray(new Expression[0]));
        }
        if (uniformName.equals("avg")) {
            checkArgCount(name, args, 1);
            return new Avg(args.get(0));
        }
        if (uniformName.equals("sum")) {
            checkArgCount(name, args, 1);
            return new Sum(args.get(0));
        }
        if (uniformName.equals("count")) {
            checkArgCount(name, args, 1);
            return new Count(args.get(0));
        }

        if (uniformName.equals("tostring")) {
            checkArgCount(name, args, 1);
            return new ToString(args.get(0));
        }
        if (uniformName.equals("concat")) {
            return new Concat(args.toArray(new Expression[0]));
        }
        if (uniformName.equals("cast")) {
            checkArgCount(name, args, 2);
            Expression e = (Expression) args.get(0);
            Expression type = (Expression) args.get(1);
            DataType d = null;
            if (type instanceof Var) {
                final String s = ((Var) type).getName();
                if ("string".equals(s)) {
                    d = DataTypeFactory.STRING;
                } else if ("int".equals(s)) {
                    d = DataTypeFactory.INT;
                } else if ("double".equals(s)) {
                    d = DataTypeFactory.DOUBLE;
                } else if ("float".equals(s)) {
                    d = DataTypeFactory.FLOAT;
                } else if ("long".equals(s)) {
                    d = DataTypeFactory.LONG;
                } else if ("date".equals(s)) {
                    d = DataTypeFactory.DATE;
                } else if ("datetime".equals(s)) {
                    d = DataTypeFactory.DATETIME;
                } else if ("boolean".equals(s)) {
                    d = DataTypeFactory.BOOLEAN;
                } else {
                    d = new ManyToOneType(name, null, name, true, true);
                }
            } else {
                throw new IllegalUPAArgumentException("Unupported cast type");
            }
            return new Cast(e, d);
        }
        if (uniformName.equals("coalesce")) {
            return new Coalesce(args);
        }
        if (uniformName.equals("decode")) {
            return new Decode(args);
        }
        if (uniformName.equals("sign")) {
            checkArgCount(name, args, 1);
            return new Sign(args.get(0));
        }
        if (uniformName.equals("now") || uniformName.equals("currenttimestamp")) {
            checkArgCount(name, args, 0);
            return new CurrentTimestamp();
        }
        if (uniformName.equals("currenttime")) {
            checkArgCount(name, args, 0);
            return new CurrentTime();
        }
        if (uniformName.equals("today") || uniformName.equals("currentdate")) {
            checkArgCount(name, args, 0);
            return new CurrentDate();
        }
        if (uniformName.equals("currentuser")) {
            checkArgCount(name, args, 0);
            return new CurrentUser();
        }
        if (uniformName.equals("currentyear")) {
            checkArgCount(name, args, 0);
            return new DatePart(DatePartType.YEAR, new CurrentDate());
        }
        if (uniformName.equals("currentmonth")) {
            checkArgCount(name, args, 0);
            return new DatePart(DatePartType.MONTH, new CurrentDate());
        }
        if (uniformName.equals("currentday")) {
            checkArgCount(name, args, 0);
            return new DatePart(DatePartType.DAY, new CurrentDate());
        }
        if (uniformName.equals("dateadd")) {
            checkArgCount(name, args, 3);
            Expression type = (Expression) args.get(0);
            Expression count = (Expression) args.get(1);
            Expression date = (Expression) args.get(2);
            return new DateAdd(DatePartType.valueOf(((Var) type).getName().toUpperCase()), count, date);
        }
        if (uniformName.equals("datediff")) {
            checkArgCount(name, args, 3);
            Expression type = (Expression) args.get(0);
            Expression start = (Expression) args.get(1);
            Expression end = (Expression) args.get(2);
            return new DateDiff(DatePartType.valueOf(((Var) type).getName().toUpperCase()), start, end);
        }
        if (uniformName.equals("datetrunc")) {
            checkArgCount(name, args, 2);
            Expression type = (Expression) args.get(0);
            Expression e = (Expression) args.get(1);
            return new DateTrunc(DatePartType.valueOf(((Var) type).getName().toUpperCase()), e);
        }
        if (uniformName.equals("datepart")) {
            checkArgCount(name, args, 2);
            Expression type = (Expression) args.get(0);
            Expression e = (Expression) args.get(1);
            return new DatePart(DatePartType.valueOf(((Var) type).getName().toUpperCase()), e);
        }
        if (uniformName.equals("year")) {
            checkArgCount(name, args, 1);
            Expression e = (Expression) args.get(0);
            return new Year(e);
        }
        if (uniformName.equals("month")) {
            checkArgCount(name, args, 1);
            Expression e = (Expression) args.get(0);
            return new Month(e);
        }
        if (uniformName.equals("day")) {
            checkArgCount(name, args, 1);
            Expression e = (Expression) args.get(0);
            return new Day(e);
        }
        if (uniformName.equals("hour")) {
            checkArgCount(name, args, 1);
            Expression e = (Expression) args.get(0);
            return new Hour(e);
        }
        if (uniformName.equals("minute")) {
            checkArgCount(name, args, 1);
            Expression e = (Expression) args.get(0);
            return new Minute(e);
        }
        if (uniformName.equals("second")) {
            checkArgCount(name, args, 1);
            Expression e = (Expression) args.get(0);
            return new Second(e);
        }
        if (uniformName.equals("monthstart")) {
            switch (args.size()) {
                case 0: {
                    return new MonthStart();
                }
                case 1: {
                    return new MonthStart(args.get(0));
                }
                case 2: {
                    return new MonthStart(args.get(0), args.get(2));
                }
            }
            checkArgCount(name, args, 2);
        }
        if (uniformName.equals("monthend")) {
            switch (args.size()) {
                case 0: {
                    return new MonthEnd();
                }
                case 1: {
                    return new MonthEnd(args.get(0));
                }
                case 2: {
                    return new MonthEnd(args.get(0), args.get(2));
                }
            }
            checkArgCount(name, args, 2);
        }
        if (uniformName.equals("exists")) {
            checkArgCount(name, args, 1);
            return new Exists((QueryStatement) args.get(0));
        }
        if (uniformName.equals("ishierarchydescendant")) {
            switch (args.size()) {
                case 3: {
                    return new IsHierarchyDescendant(args.get(0), args.get(1), args.get(2));
                }
                case 2: {
                    return new IsHierarchyDescendant(args.get(0), args.get(1), null);
                }
                default: {
                    throw new RuntimeException("function " + name + " expects 2 or 3 argument(s) but found " + args.size());
                }
            }
        }
        return new QLFunctionExpression(name, args.toArray(new Expression[0]));
        //throw new IllegalUPAArgumentException("Unknown Function "+name);
    }

    private static void checkArgCount(String name, List<Expression> args, int count) {
        if (args.size() != count) {
            throw new RuntimeException("function " + name + " expects " + count + " argument(s) but found " + args.size());
        }
    }
}
