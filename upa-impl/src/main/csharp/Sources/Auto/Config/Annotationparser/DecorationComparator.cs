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
     * @creationdate 1/7/13 2:27 AM
     */
    public class DecorationComparator : System.Collections.Generic.IComparer<Net.Vpc.Upa.Config.Decoration> {

        public static readonly Net.Vpc.Upa.Impl.Config.Annotationparser.DecorationComparator INSTANCE = new Net.Vpc.Upa.Impl.Config.Annotationparser.DecorationComparator();

        public virtual int Compare(Net.Vpc.Upa.Config.Decoration o1, Net.Vpc.Upa.Config.Decoration o2) {
            return o1.GetConfig().GetOrder().CompareTo(o2.GetConfig().GetOrder());
        }
    }
}
