/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/


namespace Net.Vpc.Upa
{
    internal sealed class FwkConvertUtils{
        public static void ListAddRange<E>(System.Collections.Generic.IList<E> list, System.Collections.Generic.ICollection<E> items)
        {
            foreach(E i in items)
            {
              list.Add(i);
            }
        }
        public static bool ObjectEquals(object a, object b)
        {
            return (a == b) || (a != null && a.Equals(b));;
        }
        public static System.IO.Stream OpenURLStream(string url)
        {
            if(string.IsNullOrEmpty(url)){  throw new System.Exception("Empty URL");
            }else if(url.StartsWith("file:"))
            {
              string localPath = url.Substring("file://".Length).Replace("/", "\\");
              return new System.IO.FileStream(localPath, System.IO.FileMode.Open);
            }else if(url.StartsWith("http:"))
            {
              return System.Net.WebRequest.Create(url).GetResponse().GetResponseStream();
            }else
            {
              return new System.IO.FileStream(url, System.IO.FileMode.Open);
            }
        }
        public static string GetURLPath(string url)
        {
            if(string.IsNullOrEmpty(url)){  throw new System.Exception("Empty URL");
            }else if(url.StartsWith("file:"))
            {
              return url.Substring("file://".Length).Replace("/", "\\");
            }else if(url.StartsWith("http:"))
            {
              return url.Substring("http://".Length);
            }else if(url.StartsWith("https:"))
            {
              return url.Substring("https://".Length);
            }else if(url.StartsWith("ftp:"))
            {
              return url.Substring("ftp://".Length);
            }else
            {
              return url;
            }
        }
        public static V GetMapValue<K,V>(System.Collections.Generic.IDictionary<K,V> map, K key)
        {
            V r=default(V);
            map.TryGetValue(key,out r);
            return r;
        }
        public static System.Numerics.BigInteger CreateBigInteger(string value)
        {
            System.Numerics.BigInteger i;
            bool success=System.Numerics.BigInteger.TryParse(value, out i);
            if(!success){
              throw new System.Exception("Invalid BigInt value");
            }
            return i;
        }
        public static void CollectionAddRange<E>(System.Collections.Generic.ICollection<E> c, System.Collections.Generic.ICollection<E> items)
        {
            foreach(E i in items)
            {
              c.Add(i);
            }
        }
        public static string LogMessageExceptionFormatter(string message, System.Exception ex, params object[] formatParameters)
        {
            if(ex==null){return message;}
            string m=message+"\n";if (ex!=null){
              m=message+ex.Message+"\n";
              m=message+ex.StackTrace+"\n";
            }
            return m;
        }
        public static void PutAllMap<K,V>(System.Collections.Generic.IDictionary<K,V> mapTo, System.Collections.Generic.IDictionary<K,V> mapFrom)
        {
            foreach (System.Collections.Generic.KeyValuePair<K, V> pair in mapFrom){
              mapTo.Add(pair.Key, pair.Value);
            }
        }
    }
}
