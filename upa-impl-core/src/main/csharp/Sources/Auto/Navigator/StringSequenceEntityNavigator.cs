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


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class StringSequenceEntityNavigator : Net.Vpc.Upa.Impl.Navigator.DefaultEntityNavigator {

        /**
             * {yy}{#}
             */
        private string format;

        private string group;

        private string name;

        private int initialValue;

        private int allocationSize;

        public StringSequenceEntityNavigator(Net.Vpc.Upa.Entity entity, string name, string format, string group, int initialValue, int allocationSize)  : base(entity){

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


        public override object GetNewKey() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return entity.CreateId(GetNewValue(entity.GetPrimaryFields()[0]));
        }

        private string GetNewValue(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = field.GetEntity();
            string idName = field.GetName();
            Net.Vpc.Upa.Entity seq = entity.GetPersistenceUnit().GetEntity(Net.Vpc.Upa.Impl.PrivateSequence.ENTITY_NAME);
            Net.Vpc.Upa.Impl.SequenceManager sm = new Net.Vpc.Upa.Impl.EntitySequenceManager(seq);
            string sequenceGroup = Eval(field, this.group, "{#}");
            while (true) {
                string nextIdString = Eval(field, this.format, sm.NextValue(name, sequenceGroup, this.initialValue, this.allocationSize));
                long count = entity.GetEntityCount(new Net.Vpc.Upa.Expressions.Equals(new Net.Vpc.Upa.Expressions.Var(idName), nextIdString));
                if (count == 0) {
                    return nextIdString;
                }
            }
        }

        private string Eval(Net.Vpc.Upa.Field field, string pattern, object replacement) {
            return Net.Vpc.Upa.Impl.Util.PlatformUtils.ReplaceNoDollarVars(pattern, new Net.Vpc.Upa.Impl.Persistence.SequencePatternEvaluator(field, replacement, null));
        }

        protected internal virtual void SetPattern(string pattern) {
            this.format = pattern;
        }

        protected internal virtual void SetName(string name) {
            this.name = name;
        }
    }
}
