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
    public class PersistWithDefaultValueFieldFilter : Net.TheVpc.Upa.Filters.AbstractFieldFilter {


        public override bool AcceptDynamic() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return false;
        }


        public override bool Accept(Net.TheVpc.Upa.Field f) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> effectiveModifiers = f.GetModifiers();
            return effectiveModifiers.Contains(Net.TheVpc.Upa.FieldModifier.PERSIST) && !effectiveModifiers.Contains(Net.TheVpc.Upa.FieldModifier.ID) && !effectiveModifiers.Contains(Net.TheVpc.Upa.FieldModifier.PERSIST_SEQUENCE);
        }
    }
}
