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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    [Net.TheVpc.Upa.Config.Entity(Name = Net.TheVpc.Upa.Impl.PrivateSequence.ENTITY_NAME, Modifiers = new[] {Net.TheVpc.Upa.EntityModifier.SYSTEM})]
    [Net.TheVpc.Upa.Config.Ignore]
    public class PrivateSequence {

        public const string ENTITY_NAME = "PrivateSequence";

        [Net.TheVpc.Upa.Config.Id]
        [Net.TheVpc.Upa.Config.Field(Max = "4000")]
        private string name;

        [Net.TheVpc.Upa.Config.Id]
        [Net.TheVpc.Upa.Config.Field(Max = "4000")]
        private string group;

        private bool locked;

        private Net.TheVpc.Upa.Types.DateTime lockDate;

        [Net.TheVpc.Upa.Config.Field(Max = "128")]
        private string lockUserId;

        private int @value;

        private int increment;

        public virtual string GetGroup() {
            return group;
        }

        public virtual void SetGroup(string group) {
            this.group = group;
        }

        public virtual bool IsLocked() {
            return locked;
        }

        public virtual void SetLocked(bool locked) {
            this.locked = locked;
        }

        public virtual Net.TheVpc.Upa.Types.DateTime GetLockDate() {
            return lockDate;
        }

        public virtual void SetLockDate(Net.TheVpc.Upa.Types.DateTime lockDate) {
            this.lockDate = lockDate;
        }

        public virtual string GetLockUserId() {
            return lockUserId;
        }

        public virtual void SetLockUserId(string lockUserId) {
            this.lockUserId = lockUserId;
        }

        public virtual int GetValue() {
            return @value;
        }

        public virtual void SetValue(int @value) {
            this.@value = @value;
        }

        public virtual int GetIncrement() {
            return increment;
        }

        public virtual void SetIncrement(int increment) {
            this.increment = increment;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }
    }
}
