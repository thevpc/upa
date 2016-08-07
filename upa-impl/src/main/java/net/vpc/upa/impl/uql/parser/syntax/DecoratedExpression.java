package net.vpc.upa.impl.uql.parser.syntax;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.expressions.Expression;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 1:41 AM
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DecoratedExpression {
    Expression expression;
    String alias;
    boolean desc;
}
