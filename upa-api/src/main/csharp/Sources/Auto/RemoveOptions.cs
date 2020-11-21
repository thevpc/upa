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
     * Created by vpc on 7/18/15.
     */
    public sealed class RemoveOptions {

        private Net.TheVpc.Upa.ConditionType conditionType;

        private object removeCondition;

        private bool simulate;

        private Net.TheVpc.Upa.RemoveTrace removeTrace;

        private bool followLinks = true;

        private Net.TheVpc.Upa.Relationship followRelationship;

        private System.Collections.Generic.IDictionary<string , object> hints;

        public static Net.TheVpc.Upa.RemoveOptions ForId(object expr) {
            return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.ID, expr);
        }

        public static  Net.TheVpc.Upa.RemoveOptions ForIdList<T>(System.Collections.Generic.IList<T> expr) {
            return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.ID_LIST, expr);
        }

        public static Net.TheVpc.Upa.RemoveOptions ForKey(Net.TheVpc.Upa.Key expr) {
            return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.KEY, expr);
        }

        public static Net.TheVpc.Upa.RemoveOptions ForObject(object expr) {
            return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.OBJECT, expr);
        }

        public static Net.TheVpc.Upa.RemoveOptions ForPrototype(object expr) {
            if (expr is Net.TheVpc.Upa.Document) {
                return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.DOCUMENT_PROTOTYPE, expr);
            } else {
                return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.PROTOTYPE, expr);
            }
        }

        public static Net.TheVpc.Upa.RemoveOptions ForDocument(Net.TheVpc.Upa.Document expr) {
            return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.DOCUMENT, expr);
        }

        public static Net.TheVpc.Upa.RemoveOptions ForPrototype(Net.TheVpc.Upa.Document expr) {
            return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.DOCUMENT_PROTOTYPE, expr);
        }

        public static Net.TheVpc.Upa.RemoveOptions ForKeyList(System.Collections.Generic.IList<Net.TheVpc.Upa.Key> expr) {
            return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.ID_LIST, expr);
        }

        public static Net.TheVpc.Upa.RemoveOptions ForExpressionList(System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> expr) {
            return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.EXPRESSION_LIST, expr);
        }

        public static Net.TheVpc.Upa.RemoveOptions ForExpression(Net.TheVpc.Upa.Expressions.Expression expr) {
            return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.EXPRESSION, expr);
        }

        public static Net.TheVpc.Upa.RemoveOptions ForAll() {
            return new Net.TheVpc.Upa.RemoveOptions(Net.TheVpc.Upa.ConditionType.EXPRESSION, null);
        }

        private RemoveOptions(Net.TheVpc.Upa.ConditionType conditionType, object removeCondition) {
            this.conditionType = conditionType;
            this.removeCondition = removeCondition;
        }

        public bool IsSimulate() {
            return simulate;
        }

        public Net.TheVpc.Upa.RemoveOptions SetSimulate(bool simulate) {
            this.simulate = simulate;
            return this;
        }

        public Net.TheVpc.Upa.RemoveTrace GetRemoveTrace() {
            return removeTrace;
        }

        public Net.TheVpc.Upa.RemoveOptions SetRemoveTrace(Net.TheVpc.Upa.RemoveTrace removeTrace) {
            this.removeTrace = removeTrace;
            return this;
        }

        public bool IsFollowLinks() {
            return followLinks;
        }

        public Net.TheVpc.Upa.RemoveOptions SetFollowLinks(bool followLinks) {
            this.followLinks = followLinks;
            return this;
        }

        public Net.TheVpc.Upa.Relationship GetFollowRelationship() {
            return followRelationship;
        }

        public Net.TheVpc.Upa.RemoveOptions SetFollowRelationship(Net.TheVpc.Upa.Relationship followRelationship) {
            this.followRelationship = followRelationship;
            return this;
        }

        public Net.TheVpc.Upa.ConditionType GetConditionType() {
            return conditionType;
        }

        public object GetRemoveCondition() {
            return removeCondition;
        }

        public System.Collections.Generic.IDictionary<string , object> GetHints() {
            return hints;
        }

        public System.Collections.Generic.IDictionary<string , object> GetHints(bool autoCreate) {
            if (hints == null && autoCreate) {
                hints = new System.Collections.Generic.Dictionary<string , object>();
            }
            return hints;
        }

        public Net.TheVpc.Upa.RemoveOptions SetHints(System.Collections.Generic.IDictionary<string , object> hints) {
            this.hints = hints;
            return this;
        }

        public Net.TheVpc.Upa.RemoveOptions SetHint(string name, object @value) {
            if (@value == null) {
                if (hints != null) {
                    hints.Remove(name);
                }
            } else {
                if (hints == null) {
                    hints = new System.Collections.Generic.Dictionary<string , object>();
                }
                hints[name]=@value;
            }
            return this;
        }
    }
}
