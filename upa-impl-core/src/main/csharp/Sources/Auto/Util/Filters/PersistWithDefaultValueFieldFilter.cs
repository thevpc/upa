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



namespace Net.Vpc.Upa.Impl.Util.Filters
{


    /**
    * Created by vpc on 12/23/13.*/
    public class PersistWithDefaultValueFieldFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {


        public override bool AcceptDynamic() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return false;
        }


        public override bool Accept(Net.Vpc.Upa.Field f) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> effectiveModifiers = f.GetModifiers();
            return effectiveModifiers.Contains(Net.Vpc.Upa.FieldModifier.PERSIST) && !effectiveModifiers.Contains(Net.Vpc.Upa.FieldModifier.ID) && !effectiveModifiers.Contains(Net.Vpc.Upa.FieldModifier.PERSIST_SEQUENCE);
        }
    }
}
