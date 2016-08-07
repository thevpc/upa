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



using System.Linq;
namespace Net.Vpc.Upa.Exceptions
{


    public class EntityException : Net.Vpc.Upa.Exceptions.UPAException {

        public EntityException(string message)  : base(message){

        }

        public EntityException(Net.Vpc.Upa.Entity entity, string operationName)  : base(entity.GetI18NString().Append(operationName), entity.GetI18NString()){

        }

        public EntityException(Net.Vpc.Upa.Entity entity, string operationName, params object [] @params)  : base(entity.GetI18NString().Append(operationName), CombineParams(entity.GetI18NString(), @params)){

        }

        public EntityException(System.Exception cause, Net.Vpc.Upa.Entity entity, string operationName, params object [] @params)  : base(cause, entity.GetI18NString().Append(operationName), CombineParams(entity.GetI18NString(), @params)){

        }

        public EntityException() {
        }

        public EntityException(string message, params object [] parameters)  : base(message, parameters){

        }

        public EntityException(Net.Vpc.Upa.Types.I18NString message, params object [] parameters)  : base(message, parameters){

        }

        public EntityException(System.Exception cause, Net.Vpc.Upa.Types.I18NString messageId, params object [] parameters)  : base(cause, messageId, parameters){

        }

        private static object[] CombineParams(Net.Vpc.Upa.Types.I18NString entityTitle, object[] @params) {
            System.Collections.Generic.List<object> a = new System.Collections.Generic.List<object>(@params.Length + 1);
            a.Add(entityTitle);
            Net.Vpc.Upa.FwkConvertUtils.CollectionAddRange(a, new System.Collections.Generic.List<object>(@params));
            return a.ToArray();
        }

        public override string ToString() {
            string s = (GetType()).FullName;
            string message = Message;
            return (message != null) ? (message) : s;
        }
    }
}
