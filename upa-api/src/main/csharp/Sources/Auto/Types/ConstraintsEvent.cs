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
namespace Net.Vpc.Upa.Types
{


    public class ConstraintsEvent {

        private System.Collections.Generic.IList<Net.Vpc.Upa.Types.ConstraintsException> errors = new System.Collections.Generic.List<Net.Vpc.Upa.Types.ConstraintsException>();

        /**
             * The object on which the Event initially occurred.
             */
        protected internal object source;

        /**
             * Constructs a prototypical Event.
             *
             * @param source The object on which the Event initially occurred.
             * @throws IllegalArgumentException if source is null.
             */
        public ConstraintsEvent(object source) {
            if (source == null) throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("null source");
            this.source = source;
        }

        /**
             * The object on which the Event initially occurred.
             *
             * @return The object on which the Event initially occurred.
             */
        public virtual object GetSource() {
            return source;
        }

        public virtual Net.Vpc.Upa.Types.ConstraintsEvent Add(Net.Vpc.Upa.Types.ConstraintsException e) {
            errors.Add(e);
            return this;
        }

        public virtual Net.Vpc.Upa.Types.ConstraintsEvent Remove(Net.Vpc.Upa.Types.ConstraintsException e) {
            errors.Remove(e);
            return this;
        }

        public virtual int CountErrors() {
            return (errors).Count;
        }

        public virtual Net.Vpc.Upa.Types.ConstraintsException GetConstraints(int pos) {
            return (Net.Vpc.Upa.Types.ConstraintsException) errors[pos];
        }


        public override string ToString() {
            return "ConstraintsEvent{" + (GetType()).FullName + "[source=" + source + "]" + __concatPaths(errors.ToArray(), ",\n", true) + '}';
        }

        private static string __concatPaths(object[] paths, string separator, bool ignoreNull) {
            if (paths == null || paths.Length == 0) {
                return "";
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (paths[0] != null && (paths[0].ToString()).Length > 0) {
                sb.Append(paths[0]);
            } else if (!ignoreNull) {
                sb.Append(separator);
            }
            for (int i = 1; i < paths.Length; i++) {
                if (paths[i] != null && (paths[i].ToString()).Length != 0 || !ignoreNull) {
                    int x = 0;
                    if ((sb).Length > (separator).Length - 1 && sb.ToString().Substring((sb).Length - (separator).Length).Equals(separator)) {
                        x++;
                    }
                    if (paths[i].ToString().Substring(0, (separator).Length).Equals(separator)) {
                        x += 2;
                    }
                    switch(x) {
                        case 0:
                            sb.Append(separator).Append(paths[i]);
                            break;
                        case 1:
                        case 2:
                            sb.Append(paths[i]);
                            break;
                        case 3:
                            sb.Remove((sb).Length - 1, 1).Append(paths[i]);
                            break;
                    }
                }
            }
            return sb.ToString();
        }
    }
}
