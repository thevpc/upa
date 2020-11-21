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



namespace Net.TheVpc.Upa.Expressions
{


    public class QueryScript {

        private System.Collections.Generic.List<string> lines;

        public QueryScript() {
            lines = new System.Collections.Generic.List<string>();
        }

        public virtual void AddStatement(string stmt) {
            if (stmt != null) {
                lines.Add(stmt);
            }
        }

        public virtual void AddScript(Net.TheVpc.Upa.Expressions.QueryScript script) {
            if (script != null) {
                for (int i = 0; i < script.Size(); i++) {
                    AddStatement(script.GetStatement(i));
                }
            }
        }

        public virtual string GetStatement(int i) {
            return lines[i];
        }

        public virtual int Size() {
            return (lines).Count;
        }

        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < (lines).Count; i++) {
                if (i > 0) {
                    sb.Append("\n");
                }
                sb.Append(lines[i]);
            }
            return sb.ToString();
        }
    }
}
