package net.thevpc.upa.impl.persistence.shared.sql;

import java.util.List;
import net.thevpc.upa.Field;
import net.thevpc.upa.Relationship;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.persistence.TypeMarshaller;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.thevpc.upa.impl.util.ExprTypeInfo;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
 * this template use File | Settings | File Templates.
 */
public class LiteralSQLProvider extends AbstractSQLProvider {

    public LiteralSQLProvider() {
        super(CompiledLiteral.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        CompiledLiteral o = (CompiledLiteral) oo;
        ExprTypeInfo ei = UPAUtils.resolveExprTypeInfo(o);
        Object objectValue = o.getValue();
        DataTypeTransform d=null;
        if (ei.getOldReferrer() != null) {
            Field oldField = (Field) ei.getOldReferrer();
            Relationship manyToOneRelationship = oldField.getManyToOneRelationship();
            if (manyToOneRelationship!=null) {
                objectValue = manyToOneRelationship.getTargetEntity().getBuilder().objectToId(objectValue);
            }
        }else if (ei.getReferrer() != null && ei.getReferrer() instanceof Field) {
            Field field = (Field) ei.getReferrer();
            Relationship manyToOneRelationship = field.getManyToOneRelationship();
            if (manyToOneRelationship!=null) {
                objectValue = manyToOneRelationship.getTargetEntity().getBuilder().objectToId(objectValue);
                List<Field> tf = manyToOneRelationship.getTargetEntity().getIdFields();
                if(tf.size()!=1){
                    throw new IllegalUPAArgumentException("Unsupported");
                }
                d = tf.get(0).getEffectiveTypeTransform();
            }
        }
        if(d==null){
            d = o.getEffectiveDataType();
        }
        final TypeMarshaller mm = sqlManager.getMarshallManager().getTypeMarshaller(d);
        return mm.toSQLLiteral(objectValue);
    }
}
