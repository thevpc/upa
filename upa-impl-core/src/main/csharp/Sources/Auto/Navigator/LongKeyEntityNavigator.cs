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


    public class LongKeyEntityNavigator : Net.TheVpc.Upa.Impl.Navigator.DefaultEntityNavigator {

        public LongKeyEntityNavigator(Net.TheVpc.Upa.Entity entity)  : base(entity){

        }

        public virtual long GetNewValue(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = field.GetEntity();
            Net.TheVpc.Upa.Expressions.Select s = new Net.TheVpc.Upa.Expressions.Select().From(entity.GetName());
            s.Field(new Net.TheVpc.Upa.Expressions.Plus(new Net.TheVpc.Upa.Expressions.Coalesce(new Net.TheVpc.Upa.Expressions.Max(new Net.TheVpc.Upa.Expressions.Var(field.GetName())), new Net.TheVpc.Upa.Expressions.Literal(0)), new Net.TheVpc.Upa.Expressions.Literal(1)), "next");
            Net.TheVpc.Upa.Record next = field.GetPersistenceUnit().CreateQuery(s).GetRecord();
            if (next != null) {
                return next.GetLong("next");
            } else {
                return 0;
            }
        }

        public override object GetNewKey() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entity.CreateId(GetNewValue(entity.GetPrimaryFields()[0]));
        }
    }
}
