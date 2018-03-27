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



namespace Net.Vpc.Upa.Impl.Navigator
{


    public class DateKeyEntityNavigator : Net.Vpc.Upa.Impl.Navigator.DefaultEntityNavigator {

        public DateKeyEntityNavigator(Net.Vpc.Upa.Entity entity)  : base(entity){

        }

        public override object GetNewKey() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entity.CreateId(new Net.Vpc.Upa.Types.DateTime());
        }
    }
}
