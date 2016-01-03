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

        private Net.Vpc.Upa.RemoveType removeType;

        private object removeCondition;

        private bool simulate;

        private Net.Vpc.Upa.RemoveTrace removeTrace;

        private bool followLinks = true;

        private Net.Vpc.Upa.Relationship followRelationship;

        public static Net.Vpc.Upa.RemoveOptions ForId(object expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.RemoveType.ID, expr);
        }

        public static  Net.Vpc.Upa.RemoveOptions ForIdList<T>(System.Collections.Generic.IList<T> expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.RemoveType.ID_LIST, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForKey(Net.Vpc.Upa.Key expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.RemoveType.KEY, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForObject(object expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.RemoveType.OBJECT, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForRecord(Net.Vpc.Upa.Record expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.RemoveType.RECORD, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForKeyList(System.Collections.Generic.IList<Net.Vpc.Upa.Key> expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.RemoveType.ID_LIST, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForExpressionList(System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.RemoveType.EXPRESSION_LIST, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForExpression(Net.Vpc.Upa.Expressions.Expression expr) {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.RemoveType.EXPRESSION, expr);
        }

        public static Net.Vpc.Upa.RemoveOptions ForAll() {
            return new Net.Vpc.Upa.RemoveOptions(Net.Vpc.Upa.RemoveType.EXPRESSION, null);
        }

        private RemoveOptions(Net.Vpc.Upa.RemoveType removeType, object removeCondition) {
            this.removeType = removeType;
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

        public Net.Vpc.Upa.RemoveType GetRemoveType() {
            return removeType;
        }

        public object GetRemoveCondition() {
            return removeCondition;
        }
    }
}
