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



namespace Net.TheVpc.Upa.Impl.Persistence
{

    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ColumnDesc {

        private string schemaName;

        private string catalogName;

        private string tableName;

        private string columnName;

        private string defaultExpression;

        private string sqlTypeName;

        private int sqlTypeCode;

        private int columnSize;

        private int decimalDigits;

        private bool? autoIncrement;

        private bool? generated;

        private bool? nullable;

        public ColumnDesc() {
        }

        public virtual string GetSchemaName() {
            return schemaName;
        }

        public virtual void SetSchemaName(string schemaName) {
            this.schemaName = schemaName;
        }

        public virtual string GetCatalogName() {
            return catalogName;
        }

        public virtual void SetCatalogName(string catalogName) {
            this.catalogName = catalogName;
        }

        public virtual string GetTableName() {
            return tableName;
        }

        public virtual void SetTableName(string tableName) {
            this.tableName = tableName;
        }

        public virtual string GetColumnName() {
            return columnName;
        }

        public virtual void SetColumnName(string columnName) {
            this.columnName = columnName;
        }

        public virtual bool? IsNullable() {
            return nullable;
        }

        public virtual void SetNullable(bool? nullable) {
            this.nullable = nullable;
        }

        public virtual string GetDefaultExpression() {
            return defaultExpression;
        }

        public virtual void SetDefaultExpression(string defaultExpression) {
            this.defaultExpression = defaultExpression;
        }

        public virtual string GetSqlTypeName() {
            return sqlTypeName;
        }

        public virtual void SetSqlTypeName(string sqlTypeName) {
            this.sqlTypeName = sqlTypeName;
        }

        public virtual int GetSqlTypeCode() {
            return sqlTypeCode;
        }

        public virtual void SetSqlTypeCode(int sqlTypeCode) {
            this.sqlTypeCode = sqlTypeCode;
        }

        public virtual int GetColumnSize() {
            return columnSize;
        }

        public virtual void SetColumnSize(int columnSize) {
            this.columnSize = columnSize;
        }

        public virtual int GetDecimalDigits() {
            return decimalDigits;
        }

        public virtual void SetDecimalDigits(int decimalDigits) {
            this.decimalDigits = decimalDigits;
        }

        public virtual bool? IsAutoIncrement() {
            return autoIncrement;
        }

        public virtual void SetAutoIncrement(bool? autoIncrement) {
            this.autoIncrement = autoIncrement;
        }

        public virtual bool? IsGenerated() {
            return generated;
        }

        public virtual void SetGenerated(bool? generated) {
            this.generated = generated;
        }
    }
}
