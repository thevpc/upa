package net.vpc.upa.impl.persistence.shared.sql;

import java.util.List;
import net.vpc.upa.Field;
import net.vpc.upa.Relationship;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.vpc.upa.impl.util.ExprTypeInfo;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.ManyToOneType;

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
