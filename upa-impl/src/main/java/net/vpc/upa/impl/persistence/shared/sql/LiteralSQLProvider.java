package net.vpc.upa.impl.persistence.shared.sql;

import java.util.List;
import net.vpc.upa.Field;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.TypeMarshaller;
import net.vpc.upa.impl.persistence.shared.sql.AbstractSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLiteral;
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
            if (oldField.getDataType() instanceof ManyToOneType) {
                ManyToOneType et = (ManyToOneType) oldField.getDataType();
                objectValue = et.getRelationship().getTargetEntity().getBuilder().objectToId(objectValue);
            }
        }else if (ei.getReferrer() != null && ei.getReferrer() instanceof Field) {
            Field field = (Field) ei.getReferrer();
            if (field.getDataType() instanceof ManyToOneType) {
                ManyToOneType et = (ManyToOneType) field.getDataType();
                objectValue = et.getRelationship().getTargetEntity().getBuilder().objectToId(objectValue);
                List<Field> tf = et.getRelationship().getTargetEntity().getPrimaryFields();
                if(tf.size()!=1){
                    throw new IllegalArgumentException("Unsupported");
                }
                d = UPAUtils.getTypeTransformOrIdentity(tf.get(0));
            }
        }
        if(d==null){
            d = o.getEffectiveDataType();
        }
        final TypeMarshaller mm = sqlManager.getMarshallManager().getTypeMarshaller(d);
        return mm.toSQLLiteral(objectValue);
    }
}
