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



namespace Net.TheVpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
     * this template use File | Settings | File Templates.
     */
    public class LiteralSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public LiteralSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral)){

        }


        public override string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral) oo;
            Net.TheVpc.Upa.Impl.Util.ExprTypeInfo ei = Net.TheVpc.Upa.Impl.Util.UPAUtils.ResolveExprTypeInfo(o);
            object objectValue = o.GetValue();
            Net.TheVpc.Upa.Types.DataTypeTransform d = null;
            if (ei.GetOldReferrer() != null) {
                Net.TheVpc.Upa.Field oldField = (Net.TheVpc.Upa.Field) ei.GetOldReferrer();
                if (oldField.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType) {
                    Net.TheVpc.Upa.Types.ManyToOneType et = (Net.TheVpc.Upa.Types.ManyToOneType) oldField.GetDataType();
                    objectValue = et.GetRelationship().GetTargetEntity().GetBuilder().ObjectToId(objectValue);
                }
            } else if (ei.GetReferrer() != null && ei.GetReferrer() is Net.TheVpc.Upa.Field) {
                Net.TheVpc.Upa.Field field = (Net.TheVpc.Upa.Field) ei.GetReferrer();
                if (field.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType) {
                    Net.TheVpc.Upa.Types.ManyToOneType et = (Net.TheVpc.Upa.Types.ManyToOneType) field.GetDataType();
                    objectValue = et.GetRelationship().GetTargetEntity().GetBuilder().ObjectToId(objectValue);
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Field> tf = et.GetRelationship().GetTargetEntity().GetPrimaryFields();
                    if ((tf).Count != 1) {
                        throw new System.ArgumentException ("Unsupported");
                    }
                    d = Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(tf[0]);
                }
            }
            if (d == null) {
                d = o.GetEffectiveDataType();
            }
            Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller mm = sqlManager.GetMarshallManager().GetTypeMarshaller(d);
            return mm.ToSQLLiteral(objectValue);
        }
    }
}
