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



namespace Net.Vpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
     * this template use File | Settings | File Templates.
     */
    public class LiteralSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public LiteralSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) oo;
            Net.Vpc.Upa.Impl.Util.ExprTypeInfo ei = Net.Vpc.Upa.Impl.Util.UPAUtils.ResolveExprTypeInfo(o);
            object objectValue = o.GetValue();
            Net.Vpc.Upa.Types.DataTypeTransform d = null;
            if (ei.GetOldReferrer() != null) {
                Net.Vpc.Upa.Field oldField = (Net.Vpc.Upa.Field) ei.GetOldReferrer();
                if (oldField.GetDataType() is Net.Vpc.Upa.Types.EntityType) {
                    Net.Vpc.Upa.Types.EntityType et = (Net.Vpc.Upa.Types.EntityType) oldField.GetDataType();
                    objectValue = et.GetRelationship().GetTargetEntity().GetBuilder().EntityToId(objectValue);
                }
            } else if (ei.GetReferrer() != null && ei.GetReferrer() is Net.Vpc.Upa.Field) {
                Net.Vpc.Upa.Field field = (Net.Vpc.Upa.Field) ei.GetReferrer();
                if (field.GetDataType() is Net.Vpc.Upa.Types.EntityType) {
                    Net.Vpc.Upa.Types.EntityType et = (Net.Vpc.Upa.Types.EntityType) field.GetDataType();
                    objectValue = et.GetRelationship().GetTargetEntity().GetBuilder().EntityToId(objectValue);
                    System.Collections.Generic.IList<Net.Vpc.Upa.Field> tf = et.GetRelationship().GetTargetEntity().GetPrimaryFields();
                    if ((tf).Count != 1) {
                        throw new System.ArgumentException ("Unsupported");
                    }
                    d = Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(tf[0]);
                }
            }
            if (d == null) {
                d = o.GetEffectiveDataType();
            }
            Net.Vpc.Upa.Impl.Persistence.TypeMarshaller mm = sqlManager.GetMarshallManager().GetTypeMarshaller(d);
            return mm.ToSQLLiteral(objectValue);
        }
    }
}
