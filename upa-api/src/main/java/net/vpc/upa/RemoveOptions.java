package net.vpc.upa;

import net.vpc.upa.expressions.Expression;

import java.util.List;

/**
 * Created by vpc on 7/18/15.
 */
public final class RemoveOptions {

    private RemoveType removeType;
    private Object removeCondition;
    private boolean simulate;
    private RemoveTrace removeTrace;
    private boolean followLinks = true;
    private Relationship followRelationship;

    public static RemoveOptions forId(Object expr) {
        return new RemoveOptions(RemoveType.ID, expr);
    }

    public static <T> RemoveOptions forIdList(List<T> expr) {
        return new RemoveOptions(RemoveType.ID_LIST, expr);
    }

    public static RemoveOptions forKey(Key expr) {
        return new RemoveOptions(RemoveType.KEY, expr);
    }

    public static RemoveOptions forObject(Object expr) {
        return new RemoveOptions(RemoveType.OBJECT, expr);
    }

    public static RemoveOptions forPrototype(Object expr) {
        if (expr instanceof Record) {
            return new RemoveOptions(RemoveType.RECORD_PROTOTYPE, expr);
        } else {
            return new RemoveOptions(RemoveType.PROTOTYPE, expr);
        }
    }

    public static RemoveOptions forRecord(Record expr) {
        return new RemoveOptions(RemoveType.RECORD, expr);
    }

    public static RemoveOptions forPrototye(Record expr) {
        return new RemoveOptions(RemoveType.RECORD_PROTOTYPE, expr);
    }

    public static RemoveOptions forKeyList(List<Key> expr) {
        return new RemoveOptions(RemoveType.ID_LIST, expr);
    }

    public static RemoveOptions forExpressionList(List<Expression> expr) {
        return new RemoveOptions(RemoveType.EXPRESSION_LIST, expr);
    }

    public static RemoveOptions forExpression(Expression expr) {
        return new RemoveOptions(RemoveType.EXPRESSION, expr);
    }

    public static RemoveOptions forAll() {
        return new RemoveOptions(RemoveType.EXPRESSION, null);
    }

    private RemoveOptions(RemoveType removeType, Object removeCondition) {
        this.removeType = removeType;
        this.removeCondition = removeCondition;
    }

    public boolean isSimulate() {
        return simulate;
    }

    public RemoveOptions setSimulate(boolean simulate) {
        this.simulate = simulate;
        return this;
    }

    public RemoveTrace getRemoveTrace() {
        return removeTrace;
    }

    public RemoveOptions setRemoveTrace(RemoveTrace removeTrace) {
        this.removeTrace = removeTrace;
        return this;
    }

    public boolean isFollowLinks() {
        return followLinks;
    }

    public RemoveOptions setFollowLinks(boolean followLinks) {
        this.followLinks = followLinks;
        return this;
    }

    public Relationship getFollowRelationship() {
        return followRelationship;
    }

    public RemoveOptions setFollowRelationship(Relationship followRelationship) {
        this.followRelationship = followRelationship;
        return this;
    }

    public RemoveType getRemoveType() {
        return removeType;
    }

    public Object getRemoveCondition() {
        return removeCondition;
    }
}
