package net.thevpc.upa.impl.upql.parser.syntax;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.expressions.Expression;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 1:41 AM
 */
@PortabilityHint(target = "C#",name = "suppress")
public class UPQLDecoratedExpression {
    Expression expression;
    String alias;
    boolean desc;
}
