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



namespace Net.TheVpc.Upa.Impl.Util.Filters
{


    /**
    * Created by vpc on 12/23/13.*/
    public class PersistNonNullableFieldFilter : Net.TheVpc.Upa.Filters.AbstractFieldFilter {


        public override bool AcceptDynamic() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return false;
        }


        public override bool Accept(Net.TheVpc.Upa.Field f) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return f.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.PERSIST) && !f.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.ID) && !f.GetDataType().IsNullable();
        }
    }
}
