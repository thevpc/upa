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



namespace Net.TheVpc.Upa
{

    /**
     * Created by IntelliJ IDEA.
     * User: vpc
     * Date: 29 janv. 2006
     * Time: 15:26:00
     * To change this template use File | Settings | File Templates.
     */
    public class QLParameter {

        private Net.TheVpc.Upa.QLParameterType type;

        private string typeName;

        private string id;

        private string title;

        private string description;

        private string expression;

        public QLParameter(Net.TheVpc.Upa.QLParameterType QLParameterType, string typeName, string expression, string name, string title, string description) {
            this.type = QLParameterType;
            this.typeName = typeName;
            this.expression = expression;
            this.id = name;
            this.title = title;
            this.description = description;
            this.expression = expression;
        }

        public virtual string GetDescription() {
            return description;
        }

        public virtual string GetId(int index) {
            if (index == 0) {
                return GetId();
            }
            return GetId() + "." + (index + 1);
        }

        public virtual string GetId() {
            return id;
        }

        public virtual string GetTitle() {
            return title;
        }

        public virtual Net.TheVpc.Upa.QLParameterType GetParameterType() {
            return type;
        }

        public virtual string GetTypeName() {
            return typeName;
        }

        public virtual string GetExpression() {
            return expression;
        }

        public virtual Net.TheVpc.Upa.QLParameter Copy() {
            return new Net.TheVpc.Upa.QLParameter(type, typeName, expression, id, title, description);
        }
    }
}
