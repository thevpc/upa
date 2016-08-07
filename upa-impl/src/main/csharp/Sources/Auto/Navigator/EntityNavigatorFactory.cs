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
     * @creationdate 8/24/12 9:22 PM
     */
    public class EntityNavigatorFactory {

        public static Net.Vpc.Upa.Impl.Navigator.DefaultEntityNavigator CreateDefaultNavigator(Net.Vpc.Upa.Entity e) {
            return new Net.Vpc.Upa.Impl.Navigator.DefaultEntityNavigator(e);
        }

        public static Net.Vpc.Upa.Impl.Navigator.StringKeyEntityNavigator CreateStringNavigator(Net.Vpc.Upa.Entity e) {
            return new Net.Vpc.Upa.Impl.Navigator.StringKeyEntityNavigator(e);
        }

        public static Net.Vpc.Upa.Impl.Navigator.StringSequenceEntityNavigator CreateStringSequenceNavigator(Net.Vpc.Upa.Entity entity, string name, string format, string group, int initialValue, int allocationSize) {
            return new Net.Vpc.Upa.Impl.Navigator.StringSequenceEntityNavigator(entity, name, format, group, initialValue, allocationSize);
        }

        public static Net.Vpc.Upa.Impl.Navigator.IntegerKeyEntityNavigator CreateIntegerNavigator(Net.Vpc.Upa.Entity e) {
            return new Net.Vpc.Upa.Impl.Navigator.IntegerKeyEntityNavigator(e);
        }

        public static Net.Vpc.Upa.Impl.Navigator.DateKeyEntityNavigator CreateDateNavigator(Net.Vpc.Upa.Entity e) {
            return new Net.Vpc.Upa.Impl.Navigator.DateKeyEntityNavigator(e);
        }

        public static Net.Vpc.Upa.Impl.Navigator.LongKeyEntityNavigator CreateLongNavigator(Net.Vpc.Upa.Entity e) {
            return new Net.Vpc.Upa.Impl.Navigator.LongKeyEntityNavigator(e);
        }
    }
}
