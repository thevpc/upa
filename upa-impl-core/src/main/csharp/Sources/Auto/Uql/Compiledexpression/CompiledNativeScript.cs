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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{


    public class CompiledNativeScript {

        public CompiledNativeScript() {
            lines = new System.Collections.Generic.List<string>();
        }

        public virtual void AddStatement(string stmt) {
            if (stmt != null) {
                lines.Add(stmt);
            }
        }

        public virtual void AddScript(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNativeScript script) {
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

        public virtual string ToSql() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < (lines).Count; i++) {
                if (i > 0) {
                    sb.Append("\n");
                }
                string s = lines[i];
                if (s != null) {
                    sb.Append(s);
                    if (!s.EndsWith(";")) {
                        sb.Append(" ;");
                    }
                }
            }
            return sb.ToString();
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

        private System.Collections.Generic.List<string> lines;
    }
}
