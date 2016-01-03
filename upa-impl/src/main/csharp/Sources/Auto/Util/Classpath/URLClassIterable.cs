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



namespace Net.Vpc.Upa.Impl.Util.Classpath
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/16/12 1:00 PM
     */

    public partial class URLClassIterable : System.Collections.Generic.IEnumerable<System.Type> {

        protected internal static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterable)).FullName);

        public string[] urls;

        public Net.Vpc.Upa.Impl.Util.Classpath.ClassPathFilter configFilter;

        public Net.Vpc.Upa.Impl.Util.Classpath.ClassFilter classFilter;

        public int nameStrategyModelConfigOrder = System.Int32.MinValue;



        public URLClassIterable(string[] urls, Net.Vpc.Upa.Impl.Util.Classpath.ClassPathFilter configFilter, Net.Vpc.Upa.Impl.Util.Classpath.ClassFilter classFilter) {
            this.urls = urls;
            this.configFilter = configFilter;
            this.classFilter = classFilter;
        }

        public virtual System.Collections.Generic.IEnumerator<System.Type> Iterator() {
            return new Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterableIterator(this);
        }


    }
}
