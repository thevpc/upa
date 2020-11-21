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



namespace Net.TheVpc.Upa.Types
{

    public class ConstraintsException : System.Exception {

        private string name;

        private object[] parameters;

        public ConstraintsException() {
        }

        public ConstraintsException(System.Exception cause)  : base("Error", cause){

        }

        public ConstraintsException(string message, System.Exception cause)  : base(message, cause){

        }

        public virtual string ToString2() {
            string content = "";
            if (name != null) {
                content = content + "(" + name + ")";
            }
            if (Message != null) {
                content = content + ":" + Message;
            }
            return content;
        }


        public override string ToString() {
            return Message;
        }

        public ConstraintsException(string msg)  : base(msg){

        }

        public ConstraintsException(string msg, string name, string description, object @value, params object [] parameters)  : base(msg){

            this.name = name;
            object[] allParameters;
            if (parameters == null || parameters.Length == 0) {
                allParameters = new object[] { name, description, @value };
            } else {
                allParameters = new object[parameters.Length + 3];
                allParameters[0] = name;
                allParameters[1] = description;
                allParameters[2] = @value;
                System.Array.Copy(parameters, 0, allParameters, 3, parameters.Length);
            }
            this.parameters = allParameters;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual object[] GetParameters() {
            return parameters;
        }
    }
}
