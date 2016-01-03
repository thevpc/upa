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



namespace Net.Vpc.Upa.Impl
{


    /**
    * Created by vpc on 12/23/13.*/
    internal class InsertNonNullableFieldFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {


        public override bool AcceptDynamic() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return false;
        }


        public override bool Accept(Net.Vpc.Upa.Field f) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return f.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.PERSIST) && !f.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.ID) && !f.GetDataType().IsNullable();
        }
    }
}
