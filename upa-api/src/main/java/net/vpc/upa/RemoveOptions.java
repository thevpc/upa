package net.vpc.upa;

import net.vpc.upa.expressions.Expression;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 7/18/15.
 */
public final class RemoveOptions {

    private ConditionType conditionType;
    private Object removeCondition;
    private boolean simulate;
    private RemoveTrace removeTrace;
    private boolean followLinks = true;
    private Relationship followRelationship;
    private Map<String,Object> hints;

    public static RemoveOptions forId(Object expr) {
        return new RemoveOptions(ConditionType.ID, expr);
    }

    public static <T> RemoveOptions forIdList(List<T> expr) {
        return new RemoveOptions(ConditionType.ID_LIST, expr);
    }

    public static RemoveOptions forKey(Key expr) {
        return new RemoveOptions(ConditionType.KEY, expr);
    }

    public static RemoveOptions forObject(Object expr) {
        return new RemoveOptions(ConditionType.OBJECT, expr);
    }

    public static RemoveOptions forPrototype(Object expr) {
        if (expr instanceof Document) {
            return new RemoveOptions(ConditionType.DOCUMENT_PROTOTYPE, expr);
        } else {
            return new RemoveOptions(ConditionType.PROTOTYPE, expr);
        }
    }

    public static RemoveOptions forDocument(Document expr) {
        return new RemoveOptions(ConditionType.DOCUMENT, expr);
    }

    public static RemoveOptions forPrototype(Document expr) {
        return new RemoveOptions(ConditionType.DOCUMENT_PROTOTYPE, expr);
    }

    public static RemoveOptions forKeyList(List<Key> expr) {
        return new RemoveOptions(ConditionType.ID_LIST, expr);
    }

    public static RemoveOptions forExpressionList(List<Expression> expr) {
        return new RemoveOptions(ConditionType.EXPRESSION_LIST, expr);
    }

    public static RemoveOptions forExpression(Expression expr) {
        return new RemoveOptions(ConditionType.EXPRESSION, expr);
    }

    public static RemoveOptions forAll() {
        return new RemoveOptions(ConditionType.EXPRESSION, null);
    }

    private RemoveOptions(ConditionType conditionType, Object removeCondition) {
        this.conditionType = conditionType;
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

    public ConditionType getConditionType() {
        return conditionType;
    }

    public Object getRemoveCondition() {
        return removeCondition;
    }

    public Map<String, Object> getHints() {
        return hints;
    }

    public Map<String, Object> getHints(boolean autoCreate) {
        if(hints==null && autoCreate){
            hints=new HashMap<String, Object>();
        }
        return hints;
    }

    public RemoveOptions setHints(Map<String, Object> hints) {
        this.hints = hints;
        return this;
    }

    public RemoveOptions setHint(String name,Object value){
        if(value==null){
           if(hints!=null){
               hints.remove(name);
           }
        }else{
            if(hints==null){
                hints=new HashMap<String, Object>();
            }
            hints.put(name,value);
        }
        return this;
    }
}
