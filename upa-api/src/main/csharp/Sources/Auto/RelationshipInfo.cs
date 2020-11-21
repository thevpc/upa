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

    public class RelationshipInfo : Net.TheVpc.Upa.UPAObjectInfo {

        private bool nullable;

        private bool live;

        private string kind;

        private string target;

        private string source;

        private Net.TheVpc.Upa.RelationshipType relationshipType;

        private bool followLinks;

        private bool askForConfirm;

        private bool filtered;

        private string sourceField;

        private string[] sourceFields;

        private string targetField;

        private string[] targetFields;

        public RelationshipInfo(string kind)  : base("relationship"){

            this.kind = kind;
        }

        public virtual string GetKind() {
            return kind;
        }

        public virtual void SetKind(string kind) {
        }

        public virtual bool IsNullable() {
            return nullable;
        }

        public virtual void SetNullable(bool nullable) {
            this.nullable = nullable;
        }

        public virtual bool IsLive() {
            return live;
        }

        public virtual void SetLive(bool live) {
            this.live = live;
        }

        public virtual string GetTarget() {
            return target;
        }

        public virtual void SetTarget(string target) {
            this.target = target;
        }

        public virtual string GetSource() {
            return source;
        }

        public virtual void SetSource(string source) {
            this.source = source;
        }

        public virtual Net.TheVpc.Upa.RelationshipType GetRelationshipType() {
            return relationshipType;
        }

        public virtual void SetRelationshipType(Net.TheVpc.Upa.RelationshipType relationshipType) {
            this.relationshipType = relationshipType;
        }

        public virtual bool IsFollowLinks() {
            return followLinks;
        }

        public virtual void SetFollowLinks(bool followLinks) {
            this.followLinks = followLinks;
        }

        public virtual bool IsAskForConfirm() {
            return askForConfirm;
        }

        public virtual void SetAskForConfirm(bool askForConfirm) {
            this.askForConfirm = askForConfirm;
        }

        public virtual bool IsFiltered() {
            return filtered;
        }

        public virtual void SetFiltered(bool filtered) {
            this.filtered = filtered;
        }

        public virtual string GetSourceField() {
            return sourceField;
        }

        public virtual void SetSourceField(string sourceField) {
            this.sourceField = sourceField;
        }

        public virtual string[] GetSourceFields() {
            return sourceFields;
        }

        public virtual void SetSourceFields(string[] sourceFields) {
            this.sourceFields = sourceFields;
        }

        public virtual string GetTargetField() {
            return targetField;
        }

        public virtual void SetTargetField(string targetField) {
            this.targetField = targetField;
        }

        public virtual string[] GetTargetFields() {
            return targetFields;
        }

        public virtual void SetTargetFields(string[] targetFields) {
            this.targetFields = targetFields;
        }
    }
}
