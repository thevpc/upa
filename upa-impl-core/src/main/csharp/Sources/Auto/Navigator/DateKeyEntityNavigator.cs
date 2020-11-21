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



namespace Net.TheVpc.Upa.Impl.Navigator
{


    public class DateKeyEntityNavigator : Net.TheVpc.Upa.Impl.Navigator.DefaultEntityNavigator {

        public DateKeyEntityNavigator(Net.TheVpc.Upa.Entity entity)  : base(entity){

        }

        public override object GetNewKey() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entity.CreateId(new Net.TheVpc.Upa.Types.DateTime());
        }
    }
}
