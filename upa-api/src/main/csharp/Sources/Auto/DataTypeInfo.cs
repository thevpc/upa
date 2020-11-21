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


    public class DataTypeInfo {

        private string name;

        private bool nullable;

        private string unitName;

        private string type;

        private string platformType;

        private System.Collections.Generic.IDictionary<string , string> properties;

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual string GetType() {
            return type;
        }

        public virtual void SetType(string type) {
            this.type = type;
        }

        public virtual string GetUnitName() {
            return unitName;
        }

        public virtual void SetUnitName(string unitName) {
            this.unitName = unitName;
        }

        public virtual string GetPlatformType() {
            return platformType;
        }

        public virtual void SetPlatformType(string platformType) {
            this.platformType = platformType;
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetProperties() {
            return properties;
        }

        public virtual void SetProperties(System.Collections.Generic.IDictionary<string , string> properties) {
            this.properties = properties;
        }

        public virtual bool IsNullable() {
            return nullable;
        }

        public virtual void SetNullable(bool nullable) {
            this.nullable = nullable;
        }
    }
}
