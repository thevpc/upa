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



namespace Net.Vpc.Upa.Impl.Persistence.Result
{

    /**
     * Created by vpc on 6/29/16.
     */
    public class ResultColumn {

        private object @value;

        private string label;

        public ResultColumn() {
        }

        public virtual object GetValue() {
            return @value;
        }

        public virtual void SetValue(object @value) {
            this.@value = @value;
        }

        public virtual string GetLabel() {
            return label;
        }

        public virtual void SetLabel(string label) {
            this.label = label;
        }
    }
}
