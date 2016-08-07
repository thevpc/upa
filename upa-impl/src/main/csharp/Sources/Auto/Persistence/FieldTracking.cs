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



namespace Net.Vpc.Upa.Impl.Persistence
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/24/12 11:14 PM
     */
    public class FieldTracking {

        private string name;

        private string setterMethodName;

        private int index;

        public FieldTracking(string name, string setterMethodName, int index) {
            this.name = name;
            this.setterMethodName = setterMethodName;
            this.index = index;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual string GetSetterMethodName() {
            return setterMethodName;
        }

        public virtual int GetIndex() {
            return index;
        }
    }
}
