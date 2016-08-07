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



namespace Net.Vpc.Upa.Impl.Config.Annotationparser
{

    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 11/15/12 11:50 AM*/
    internal class OverriddenValue<T> {

        internal bool specified;

        internal int order = System.Int32.MinValue;

        internal T @value;

        public OverriddenValue() {
        }

        public virtual void SetValue(T newValue) {
            specified = true;
            @value = newValue;
        }

        public virtual void SetBetterValue(T newValue, int order) {
            if (order >= this.order) {
                SetValue(newValue);
            }
        }

        public virtual T GetValue(T unspecifiedValue) {
            if (!specified) {
                return unspecifiedValue;
            }
            return @value;
        }
    }
}
