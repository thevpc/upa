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



namespace Net.Vpc.Upa
{


    /**
     * Created by vpc on 7/18/15.
     */
    public sealed class RemoveOptions {

        private Net.Vpc.Upa.ConditionType conditionType;

        private object removeCondition;

        private bool simulate;

        private Net.Vpc.Upa.RemoveTrace removeTrace;

        private bool followLinks = true;

        private Net.Vpc.Upa.Relationship followRelationship;

        private System.Collections.Generic.IDictionary<string , object> hints;

        public static Net.Vpc.Upa.RemoveOptions ForId(object expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.ID, expr);
        }

        public static  Net.Vpc.Upa.RemoveOptions ForIdList<T>(System.Collections.Generic.IList<T> expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.ID_LIST, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForKey(Net.Vpc.Upa.Key expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.KEY, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForObject(object expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.OBJECT, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForPrototype(object expr) {
            if (expr is Net.Vpc.Upa.Record) {
                return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.RECORD_PROTOTYPE, expr);
            } else {
                return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.PROTOTYPE, expr);
            }
        }

        public static Net.Vpc.Upa.RemoveOptions ForRecord(Net.Vpc.Upa.Record expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.RECORD, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForPrototye(Net.Vpc.Upa.Record expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.RECORD_PROTOTYPE, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForKeyList(System.Collections.Generic.IList<Net.Vpc.Upa.Key> expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.ID_LIST, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForExpressionList(System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.EXPRESSION_LIST, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForExpression(Net.Vpc.Upa.Expressions.Expression expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.EXPRESSION, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForAll() {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.ConditionType.EXPRESSION, null);
        }

        private RemoveOptions(Net.Vpc.Upa.ConditionType conditionType, object removeCondition) {
            this.conditionType = conditionType;
            this.removeCondition = removeCondition;
        }

        public bool IsSimulate() {
            return simulate;
        }

        public Net.Vpc.Upa.RemoveOptions SetSimulate(bool simulate) {
            this.simulate = simulate;
            return this;
        }

        public Net.Vpc.Upa.RemoveTrace GetRemoveTrace() {
            return removeTrace;
        }

        public Net.Vpc.Upa.RemoveOptions SetRemoveTrace(Net.Vpc.Upa.RemoveTrace removeTrace) {
            this.removeTrace = removeTrace;
            return this;
        }

        public bool IsFollowLinks() {
            return followLinks;
        }

        public Net.Vpc.Upa.RemoveOptions SetFollowLinks(bool followLinks) {
            this.followLinks = followLinks;
            return this;
        }

        public Net.Vpc.Upa.Relationship GetFollowRelationship() {
            return followRelationship;
        }

        public Net.Vpc.Upa.RemoveOptions SetFollowRelationship(Net.Vpc.Upa.Relationship followRelationship) {
            this.followRelationship = followRelationship;
            return this;
        }

        public Net.Vpc.Upa.ConditionType GetConditionType() {
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

        public Net.Vpc.Upa.RemoveOptions SetHints(System.Collections.Generic.IDictionary<string , object> hints) {
            this.hints = hints;
            return this;
        }

        public Net.Vpc.Upa.RemoveOptions SetHint(string name, object @value) {
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
