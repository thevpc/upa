package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.PersistenceUnit;

import java.util.ArrayList;
import java.util.Arrays;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.DataTypeTransform;

public final class CompiledStrFormat extends DefaultCompiledExpressionImpl
        implements Cloneable, CompiledExpandableExpression {

    private static final long serialVersionUID = 1L;
    private CompiledExpressionExt[] expressions;
    private CompiledCst pattern;

    public CompiledStrFormat(String pattern, CompiledExpressionExt... expressions) {
        this.pattern = new CompiledCst(pattern);
        bindChildren(this.pattern);
        this.expressions = expressions;
        bindChildren(expressions);
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.STRING;
    }

    @Override
    public boolean isValid() {
        return true;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledExpressionExt[] expressions1 = new CompiledExpressionExt[expressions.length];
        for (int i = 0; i < expressions.length; i++) {
            expressions1[i] = expressions[i].copy();
        }

        CompiledStrFormat o = new CompiledStrFormat((String)pattern.getValue(),expressions1);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
    //    @Override
//    public String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        throw new IllegalArgumentException("Not supported");
//    }

    @Override
    public CompiledExpressionExt expand(PersistenceUnit PersistenceUnit) {
        CompiledConcat c = new CompiledConcat();

        int i=0;
        int varPos = 0;
        String str=(String)pattern.getValue();
        while (i>=0 && i<str.length()){
            int j = str.indexOf("{", i);
            if(j<0){
                c.add(new CompiledLiteral(str.substring(i)));
                i=-1;
            }else{
                c.add(new CompiledLiteral(str.substring(i,j)));
                int k = str.indexOf("}", j+1);
                String varName=null;
                if(k<0) {
                    varName = str.substring(j + 1);
                    i=-1;
                }else{
                    varName=(str.substring(j+1,k));
                    i=k+1;
                }
                if (varName.equals("?")) {
                    c.add(expressions[varPos]);
                } else if (PlatformUtils.isInt32(varName)) {
                    c.add(expressions[Integer.parseInt(varName)]);
                } else {
                    throw new IllegalArgumentException("Unsupported");
                }
                varPos++;
            }
        }
        return c;
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        ArrayList<CompiledExpressionExt> all=new ArrayList<CompiledExpressionExt>();
        all.add(pattern);
        all.addAll(Arrays.asList(expressions));
        return all.toArray(new CompiledExpressionExt[all.size()]);
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        if(index==0){
            unbindChildren(this.pattern);
            pattern=(CompiledCst)expression;
            bindChildren(expression);
        }else{
            unbindChildren(this.expressions[index-1]);
            expressions[index-1]=expression;
            bindChildren(expression);
        }
    }
    
    
}
