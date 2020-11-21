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



namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     * Created by vpc on 5/17/16.
     */
    public class PlatformLenientType : Net.TheVpc.Upa.Impl.Util.LenientType {

        private string typeName;

        private System.Type type;

        public PlatformLenientType(string typeName) {
            this.typeName = typeName;
        }

        public virtual bool IsValid() {
            return GetValidType() != null;
        }

        public virtual System.Type GetValidTypeOrError() {
            System.Type c = GetValidType();
            if (c == null) {
                throw new System.Exception("Invalid Type");
            }
            return c;
        }

        public virtual System.Type GetValidType() {
            if (type == null) {
                try {
                    type = System.Type.GetType(typeName);
                } catch (System.Exception e) {
                    System.Console.WriteLine(e);
                    type = typeof(void);
                }
            }
            if (typeof(void).Equals(type)) {
                return null;
            }
            return type;
        }

        public virtual object NewInstance() {
            try {
                return System.Activator.CreateInstance(GetValidTypeOrError());
            } catch (System.Exception e) {
                throw Net.TheVpc.Upa.Impl.Util.PlatformUtils.CreateRuntimeException(e);
            }
        }

        public virtual object InvokeInstance(object instance, string method, System.Type[] types, object[] args) {
            try {
                return GetValidTypeOrError().GetMethod(method, types).Invoke(instance, args);
            } catch (System.Exception e) {
                throw Net.TheVpc.Upa.Impl.Util.PlatformUtils.CreateRuntimeException(e);
            }
        }

        public virtual object InvokeStatic(string method, System.Type[] types, object[] args) {
            try {
                return GetValidTypeOrError().GetMethod(method, types).Invoke(null, args);
            } catch (System.Exception e) {
                throw Net.TheVpc.Upa.Impl.Util.PlatformUtils.CreateRuntimeException(e);
            }
        }
    }
}
