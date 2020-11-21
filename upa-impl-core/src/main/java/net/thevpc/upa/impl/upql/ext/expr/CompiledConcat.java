package net.thevpc.upa.impl.upql.ext.expr;



import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

public final class CompiledConcat extends CompiledFunction
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledConcat() {
        super("Concat");
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.STRING;
    }

    public CompiledConcat(CompiledExpressionExt... expressions) {
        this();
        for (CompiledExpressionExt expression : expressions) {
            add(expression);
        }
    }

    public CompiledConcat clear() {
        protectedClear();
        return this;
    }

    public CompiledConcat addAll(CompiledConcat other) {
        for (int i = 0; i < other.getArgumentsCount(); i++) {
            add((CompiledExpressionExt) other.getArgument(i));
        }

        return this;
    }

    public CompiledConcat add(CompiledExpressionExt expression) {
        if (expression == this) {
            throw new IllegalUPAArgumentException("NullExpression");
        } else {
            protectedAddArgument(expression);
            return this;
        }
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledConcat o = new CompiledConcat();
        protectedCopyTo(o);
        return o;
    }

//    public String getDescription() {
//        String d = super.getDescription();
//        if (d != null || elements.size() == 0) {
//            return d;
//        }
//        StringBuilder sb = new StringBuilder(elements.get(0).getDescription());
//        for (int i = 1; i < elements.size(); i++) {
//            sb.append(" ");
//            sb.append(" and ");
//            sb.append(" ");
//            sb.append(elements.get(i).getDescription());
//        }
//        return sb.toString();
//    }
}
