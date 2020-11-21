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


    public class IntegerKeyEntityNavigator : Net.TheVpc.Upa.Impl.Navigator.DefaultEntityNavigator {

        public IntegerKeyEntityNavigator(Net.TheVpc.Upa.Entity entity)  : base(entity){

        }

        public virtual int GetNewValue(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = field.GetEntity();
            Net.TheVpc.Upa.Expressions.Select s = new Net.TheVpc.Upa.Expressions.Select().From(entity.GetName());
            s.Field(new Net.TheVpc.Upa.Expressions.Plus(new Net.TheVpc.Upa.Expressions.Coalesce(new Net.TheVpc.Upa.Expressions.Max(new Net.TheVpc.Upa.Expressions.Var(field.GetName())), new Net.TheVpc.Upa.Expressions.Literal(0)), new Net.TheVpc.Upa.Expressions.Literal(1)), "nextValue");
            Net.TheVpc.Upa.Record next = field.GetPersistenceUnit().CreateQuery(s).GetRecord();
            if (next != null) {
                return next.GetInt("nextValue");
            } else {
                return 0;
            }
        }

        public override object GetNewKey() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entity.CreateId(GetNewValue(entity.GetPrimaryFields()[0]));
        }
    }
}
