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


namespace Net.Vpc.Upa.Impl
{
    internal sealed class FwkConvertUtils{
        private static System.Random randomNumberGenerator = null;
        public const int PUBLIC = 0x00000001;
        public const int PRIVATE = 0x00000002;
        public const int PROTECTED = 0x00000004;
        public const int STATIC = 0x00000008;
        public const int SEALED = 0x00000010;
        public const int TRANSIENT = 0x00000080;
        public const int INTERFACE = 0x00000200;
        public const int ABSTRACT = 0x00000400;
        public static string LogMessageExceptionFormatter(string message, System.Exception ex, params object[] formatParameters)
        {
            if(ex==null){return message;}
            string m=message+"\n";if (ex!=null){
              m=message+ex.Message+"\n";
              m=message+ex.StackTrace+"\n";
            }
            return m;
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
        public static void SetRemoveRange<E>(System.Collections.Generic.ISet<E> list, System.Collections.Generic.ISet<E> items)
        {
            foreach(E i in items)
            {
              list.Remove(i);
            }
        }
        public static void ListAddRange<E>(System.Collections.Generic.IList<E> list, System.Collections.Generic.IList<E> items)
        {
            foreach(E i in items)
            {
              list.Add(i);
            }
        }
        public static void CollectionAddRange<E>(System.Collections.Generic.ICollection<E> c, System.Collections.Generic.ICollection<E> items)
        {
            foreach(E i in items)
            {
              c.Add(i);
            }
        }
        public static void ListSort<E>(System.Collections.Generic.IList<E> list, System.Collections.Generic.IComparer<E> comparator)
        {
            E[]  arr =new E[list.Count];
            list.CopyTo(arr, 0);
            if(comparator==null)
            {
               System.Array.Sort(arr);
            }else{
               System.Array.Sort(arr,comparator);
            }
            for (int i = 0; i < arr.Length; i++)
            {
               list[i] = arr[i];
            }
        }
        public static System.Type[] GetMethodParameterTypes(System.Reflection.MethodInfo method)
        {
            System.Reflection.ParameterInfo[] p = method.GetParameters();
            System.Type[] r=new System.Type[p.Length];
            for (int i = 0; i < r.Length; i++)
            {
                r[i]=p[i].ParameterType;
            }
            return r;
        }
        public static void PutAllMap<K,V>(System.Collections.Generic.IDictionary<K,V> mapTo, System.Collections.Generic.IDictionary<K,V> mapFrom)
        {
            foreach (System.Collections.Generic.KeyValuePair<K, V> pair in mapFrom){
              mapTo.Add(pair.Key, pair.Value);
            }
        }
        public static System.Array CreateMultiArray(System.Type elementType, params int[] dims)
        {
            if(dims.Length==0)
                        {
                            throw new System.Exception("Invalid Dimensions");
                        }else
                        {
                            System.Type arrayType = elementType;
                            for (int i = 0; i < dims.Length-1;i++ )
                            {
                                arrayType = System.Array.CreateInstance(arrayType, 0).GetType();
                            }
                            System.Array a = System.Array.CreateInstance(arrayType, dims[0]);
                            if (dims.Length > 1 && dims[1]>=0)
                            {
                                int[] newDims = new int[dims.Length - 1];
                                System.Array.Copy(dims, 1, newDims, 0, newDims.Length);
                                for (int i = 0; i < a.Length; i++)
                                {
                                    a.SetValue(CreateMultiArray(elementType, newDims), i);
                                }
                            }
                            return a;
                        }
        }
        public static void ListRemoveRange<E>(System.Collections.Generic.IList<E> list, System.Collections.Generic.IList<E> items)
        {
            foreach(E i in items)
            {
              list.Remove(i);
            }
        }
        public static void ListInsertRange<E>(System.Collections.Generic.IList<E> list, int index, System.Collections.Generic.IList<E> items)
        {
            int x=index;
            foreach(E i in items)
            {
              list.Insert(x++,i);
            }
        }
        public static System.Attribute GetTypeCustomAttribute(System.Type type, System.Type attrType)
        {
            object[] all=type.GetCustomAttributes(attrType, false);
            return all.Length>0?(System.Attribute)all[0]:null;
        }
        public static double Random()
        {
            System.Random rnd = randomNumberGenerator;
            if (rnd == null) rnd = new System.Random();
            return rnd.NextDouble();
        }
        public static int GetMethodModifiers(System.Reflection.MethodInfo method)
        {
            int m = 0;
            if (method.IsPublic){
              m |= PUBLIC;
            }
            if (method.IsPrivate){
              m |= PRIVATE;
            }
            return m;
        }
        public static int GetClassModifiers(System.Type type)
        {
            int m = 0;
            if (type.IsPublic){
              m |= PUBLIC;
            }
            if (type.IsAbstract){
              m |= ABSTRACT;
            }
            if (type.IsInterface){
              m |= INTERFACE;
            }
            return m;
        }
        public static int GetFieldModifiers(System.Reflection.FieldInfo field)
        {
            int m = 0;
            if (field.IsPublic){
              m |= PUBLIC;
            }
            if (field.IsPrivate){
              m |= PRIVATE;
            }
            return m;
        }
        public static E ListRemoveAt<E>(System.Collections.Generic.IList<E> list, int index)
        {
            E r=list[index];
            list.RemoveAt(index);
            return r;
        }
        public static V RemoveMapKey<K,V>(System.Collections.Generic.IDictionary<K,V> map, K key)
        {
            V r=default(V);
            map.TryGetValue(key,out r);
            map.Remove(key);
            return r;
        }
        public static string GetURLProtocol(string url)
        {
            if(string.IsNullOrEmpty(url)){  return "";
            }else if(url.StartsWith("file:"))
            {
              return "file";
            }else if(url.StartsWith("http:"))
            {
              return "http";
            }else
            {
              return "file";
            }
        }
        public static string ConcatFilePath(params string[] path)
        {
            System.Text.StringBuilder s=new System.Text.StringBuilder();
            foreach(var i in path)
            {
              if(!(string.IsNullOrEmpty(i))){;
                if(s.Length>0){;
                  s.Append(@"\");
                };
                s.Append(i);
              };
            }
            return s.ToString();
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
    }
}
