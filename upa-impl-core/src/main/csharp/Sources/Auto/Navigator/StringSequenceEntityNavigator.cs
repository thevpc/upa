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


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class StringSequenceEntityNavigator : Net.TheVpc.Upa.Impl.Navigator.DefaultEntityNavigator {

        /**
             * {yy}{#}
             */
        private string format;

        private string group;

        private string name;

        private int initialValue;

        private int allocationSize;

        public StringSequenceEntityNavigator(Net.TheVpc.Upa.Entity entity, string name, string format, string group, int initialValue, int allocationSize)  : base(entity){

            this.format = format;
            this.group = group;
            this.name = name;
            this.initialValue = initialValue;
            this.allocationSize = allocationSize;
            if (this.format == null) {
                this.format = "{#}";
            }
            if (this.group == null) {
                this.group = format;
            }
        }


        public override object GetNewKey() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return entity.CreateId(GetNewValue(entity.GetPrimaryFields()[0]));
        }

        private string GetNewValue(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = field.GetEntity();
            string idName = field.GetName();
            Net.TheVpc.Upa.Entity seq = entity.GetPersistenceUnit().GetEntity(Net.TheVpc.Upa.Impl.PrivateSequence.ENTITY_NAME);
            Net.TheVpc.Upa.Impl.SequenceManager sm = new Net.TheVpc.Upa.Impl.EntitySequenceManager(seq);
            string sequenceGroup = Eval(field, this.group, "{#}");
            while (true) {
                string nextIdString = Eval(field, this.format, sm.NextValue(name, sequenceGroup, this.initialValue, this.allocationSize));
                long count = entity.GetEntityCount(new Net.TheVpc.Upa.Expressions.Equals(new Net.TheVpc.Upa.Expressions.Var(idName), nextIdString));
                if (count == 0) {
                    return nextIdString;
                }
            }
        }

        private string Eval(Net.TheVpc.Upa.Field field, string pattern, object replacement) {
            return Net.TheVpc.Upa.Impl.Util.PlatformUtils.ReplaceNoDollarVars(pattern, new Net.TheVpc.Upa.Impl.Persistence.SequencePatternEvaluator(field, replacement, null));
        }

        protected internal virtual void SetPattern(string pattern) {
            this.format = pattern;
        }

        protected internal virtual void SetName(string name) {
            this.name = name;
        }
    }
}
