/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.parser.syntax;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.TypesFactory;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.uql.QLFunctionExpression;

import java.util.List;
import net.vpc.upa.types.ManyToOneType;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class FunctionFactory {

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
        if (uniformName.equals("sum")) {
            checkArgCount(name, args, 1);
            return new Sum(args.get(0));
        }
        if (uniformName.equals("count")) {
            checkArgCount(name, args, 1);
            return new Count(args.get(0));
        }

        if (uniformName.equals("d2v")) {
            checkArgCount(name, args, 1);
            return new D2V(args.get(0));
        }
        if (uniformName.equals("i2v")) {
            checkArgCount(name, args, 1);
            return new I2V(args.get(0));
        }
        if (uniformName.equals("concat")) {
            return new Concat(args.toArray(new Expression[args.size()]));
        }
        if (uniformName.equals("cast")) {
            checkArgCount(name, args, 2);
            Expression e = (Expression) args.get(0);
            Expression type = (Expression) args.get(1);
            DataType d = null;
            if (type instanceof Var) {
                final String s = ((Var) type).getName();
                if ("string".equals(s)) {
                    d = TypesFactory.STRING;
                } else if ("int".equals(s)) {
                    d = TypesFactory.INT;
                } else if ("double".equals(s)) {
                    d = TypesFactory.DOUBLE;
                } else if ("float".equals(s)) {
                    d = TypesFactory.FLOAT;
                } else if ("long".equals(s)) {
                    d = TypesFactory.LONG;
                } else if ("date".equals(s)) {
                    d = TypesFactory.DATE;
                } else if ("datetime".equals(s)) {
                    d = TypesFactory.DATETIME;
                } else if ("boolean".equals(s)) {
                    d = TypesFactory.BOOLEAN;
                } else {
                    d = new ManyToOneType(name, null, name, true, true);
                }
            } else {
                throw new UPAIllegalArgumentException("Unupported cast type");
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
            if (args.size() == 3) {
                return new IsHierarchyDescendant(args.get(0), args.get(1), args.get(2));
            } else if (args.size() == 2) {
                return new IsHierarchyDescendant(args.get(0), args.get(1), null);
            } else {
                throw new RuntimeException("function " + name + " expects 2 or 3 argument(s) but found " + args.size());
            }
        }
        return new QLFunctionExpression(name, args.toArray(new Expression[args.size()]));
        //throw new UPAIllegalArgumentException("Unknown Function "+name);
    }

    private static void checkArgCount(String name, List<Expression> args, int count) {
        if (args.size() != count) {
            throw new RuntimeException("function " + name + " expects " + count + " argument(s) but found " + args.size());
        }
    }
}
