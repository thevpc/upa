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



using System.Linq;
namespace Net.TheVpc.Upa.Exceptions
{


    public class EntityException : Net.TheVpc.Upa.Exceptions.UPAException {

        public EntityException(string message)  : base(message){

        }

        public EntityException(Net.TheVpc.Upa.Entity entity, string operationName)  : base(entity.GetI18NTitle().Append(operationName), entity.GetI18NTitle()){

        }

        public EntityException(Net.TheVpc.Upa.Entity entity, string operationName, params object [] @params)  : base(entity.GetI18NTitle().Append(operationName), CombineParams(entity.GetI18NTitle(), @params)){

        }

        public EntityException(System.Exception cause, Net.TheVpc.Upa.Entity entity, string operationName, params object [] @params)  : base(cause, entity.GetI18NTitle().Append(operationName), CombineParams(entity.GetI18NTitle(), @params)){

        }

        public EntityException() {
        }

        public EntityException(string message, params object [] parameters)  : base(message, parameters){

        }

        public EntityException(Net.TheVpc.Upa.Types.I18NString message, params object [] parameters)  : base(message, parameters){

        }

        public EntityException(System.Exception cause, Net.TheVpc.Upa.Types.I18NString messageId, params object [] parameters)  : base(cause, messageId, parameters){

        }

        private static object[] CombineParams(Net.TheVpc.Upa.Types.I18NString entityTitle, object[] @params) {
            System.Collections.Generic.List<object> a = new System.Collections.Generic.List<object>(@params.Length + 1);
            a.Add(entityTitle);
            Net.TheVpc.Upa.FwkConvertUtils.CollectionAddRange(a, new System.Collections.Generic.List<object>(@params));
            return a.ToArray();
        }

        public override string ToString() {
            string s = (GetType()).FullName;
            string message = Message;
            return (message != null) ? (message) : s;
        }
    }
}
