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



namespace Net.Vpc.Upa.Impl
{


    [Net.Vpc.Upa.Config.Entity(Name = Net.Vpc.Upa.Impl.LockInfoDesc.LOCK_INFO_ENTITY_NAME, ShortName = "LKNF", IdType = typeof(Net.Vpc.Upa.Key), EntityType = typeof(Net.Vpc.Upa.Record))]
    [Net.Vpc.Upa.Config.Ignore]
    public class LockInfoDesc {

        public const string LOCK_INFO_ENTITY_NAME = "UPALockInfo";

        [Net.Vpc.Upa.Config.Id]
        [Net.Vpc.Upa.Config.Field(Type = typeof(string), Max = "64", Nullable = Net.Vpc.Upa.Config.BoolEnum.TRUE, Path = "lock_infos")]
        private Net.Vpc.Upa.Config.FieldDesc lockedEntity;

        [Net.Vpc.Upa.Config.Field(Type = typeof(string), Max = "64", Nullable = Net.Vpc.Upa.Config.BoolEnum.TRUE, Path = "lock_infos")]
        private Net.Vpc.Upa.Config.FieldDesc lockId;

        [Net.Vpc.Upa.Config.Field(Type = typeof(Net.Vpc.Upa.Types.DateTime), Nullable = Net.Vpc.Upa.Config.BoolEnum.TRUE, Path = "lock_infos")]
        private Net.Vpc.Upa.Config.FieldDesc lockTime;
    }
}
