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


    public class UPAObjectInfo {

        private System.Collections.Generic.IDictionary<string , object> simpleProperties;

        private string name;

        private string type;

        private string title;

        public UPAObjectInfo(string type) {
            this.type = type;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetSimpleProperties() {
            return simpleProperties;
        }

        public virtual void SetSimpleProperties(System.Collections.Generic.IDictionary<string , object> simpleProperties) {
            this.simpleProperties = simpleProperties;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual void SetType(string type) {
        }

        public virtual string GetType() {
            return type;
        }

        public virtual string GetTitle() {
            return title;
        }

        public virtual void SetTitle(string title) {
            this.title = title;
        }
    }
}
