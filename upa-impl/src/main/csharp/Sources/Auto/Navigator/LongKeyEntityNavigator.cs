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


    public class LongKeyEntityNavigator : Net.Vpc.Upa.Impl.Navigator.DefaultEntityNavigator {

        public LongKeyEntityNavigator(Net.Vpc.Upa.Entity entity)  : base(entity){

        }

        public virtual long GetNewValue(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = field.GetEntity();
            Net.Vpc.Upa.Expressions.Select s = new Net.Vpc.Upa.Expressions.Select().From(entity.GetName());
            s.Field(new Net.Vpc.Upa.Expressions.Plus(new Net.Vpc.Upa.Expressions.Coalesce(new Net.Vpc.Upa.Expressions.Max(new Net.Vpc.Upa.Expressions.Var(field.GetName())), new Net.Vpc.Upa.Expressions.Literal(0)), new Net.Vpc.Upa.Expressions.Literal(1)), "next");
            Net.Vpc.Upa.Record next = field.GetPersistenceUnit().CreateQuery(s).GetRecord();
            if (next != null) {
                return next.GetLong("next");
            } else {
                return 0;
            }
        }

        public override object GetNewKey() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entity.CreateId(GetNewValue(entity.GetPrimaryFields()[0]));
        }
    }
}
