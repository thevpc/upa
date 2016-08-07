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



namespace Net.Vpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/24/12 3:01 AM
     */
    public class ClassesScanSource : Net.Vpc.Upa.Impl.Config.BaseScanSource {

        private readonly System.Type[] classes;

        private bool noIgnore;

        public ClassesScanSource(System.Type[] classes, bool noIgnore) {
            this.classes = classes;
            this.noIgnore = noIgnore;
        }

        public override bool IsNoIgnore() {
            return noIgnore;
        }

        public virtual System.Type[] GetClasses() {
            return classes;
        }


        public override string ToString() {
            return (GetType()).Name + "{" + System.Convert.ToString(classes) + "}";
        }


        public override System.Collections.Generic.IEnumerable<System.Type> ToIterable(object context) {
            return new System.Collections.Generic.List<System.Type>(classes);
        }
    }
}
