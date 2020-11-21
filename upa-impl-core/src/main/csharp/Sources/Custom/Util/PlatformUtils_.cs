using System;
using System.IO;


namespace Net.TheVpc.Upa.Impl.Util
{


    public partial class PlatformUtils{

        public static  System.Collections.Generic.IList<object> TypedListToObjectList<T>(System.Collections.IList anyList) {
            if (anyList == null) {
                return null;
            }
            System.Collections.Generic.List<object> list = new System.Collections.Generic.List<object>();
            foreach (Object i in anyList) {
                list.Add(i);
            }
            return list;
        }
    }
}
