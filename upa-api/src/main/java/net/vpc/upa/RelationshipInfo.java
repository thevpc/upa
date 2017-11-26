package net.vpc.upa;

public class RelationshipInfo extends UPAObjectInfo{
    private boolean nullable;
    private boolean live;
    private String kind;
    private String target;
    private String source;
    private RelationshipType relationshipType;
    private boolean followLinks;
    private boolean askForConfirm;
    private boolean filtered;
    private String sourceField;
    private String[] sourceFields;
    private String targetField;
    private String[] targetFields;

    public RelationshipInfo(String kind) {
        super("relationship");
        this.kind=kind;
    }

    public String getKind() {
        return kind;
    }

    public void setKind(String kind) {

    }

    public boolean isNullable() {
        return nullable;
    }

    public void setNullable(boolean nullable) {
        this.nullable = nullable;
    }

    public boolean isLive() {
        return live;
    }

    public void setLive(boolean live) {
        this.live = live;
    }

    public String getTarget() {
        return target;
    }

    public void setTarget(String target) {
        this.target = target;
    }

    public String getSource() {
        return source;
    }

    public void setSource(String source) {
        this.source = source;
    }


    public RelationshipType getRelationshipType() {
        return relationshipType;
    }

    public void setRelationshipType(RelationshipType relationshipType) {
        this.relationshipType = relationshipType;
    }

    public boolean isFollowLinks() {
        return followLinks;
    }

    public void setFollowLinks(boolean followLinks) {
        this.followLinks = followLinks;
    }

    public boolean isAskForConfirm() {
        return askForConfirm;
    }

    public void setAskForConfirm(boolean askForConfirm) {
        this.askForConfirm = askForConfirm;
    }

    public boolean isFiltered() {
        return filtered;
    }

    public void setFiltered(boolean filtered) {
        this.filtered = filtered;
    }

    public String getSourceField() {
        return sourceField;
    }

    public void setSourceField(String sourceField) {
        this.sourceField = sourceField;
    }

    public String[] getSourceFields() {
        return sourceFields;
    }

    public void setSourceFields(String[] sourceFields) {
        this.sourceFields = sourceFields;
    }

    public String getTargetField() {
        return targetField;
    }

    public void setTargetField(String targetField) {
        this.targetField = targetField;
    }

    public String[] getTargetFields() {
        return targetFields;
    }

    public void setTargetFields(String[] targetFields) {
        this.targetFields = targetFields;
    }
}
