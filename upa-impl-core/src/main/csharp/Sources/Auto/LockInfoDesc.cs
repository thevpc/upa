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


    [Net.TheVpc.Upa.Config.Entity(Name = Net.TheVpc.Upa.Impl.LockInfoDesc.LOCK_INFO_ENTITY_NAME, ShortName = "LKNF", IdType = typeof(Net.TheVpc.Upa.Key), EntityType = typeof(Net.TheVpc.Upa.Record))]
    [Net.TheVpc.Upa.Config.Ignore]
    public class LockInfoDesc {

        public const string LOCK_INFO_ENTITY_NAME = "UPALockInfo";

        [Net.TheVpc.Upa.Config.Id]
        [Net.TheVpc.Upa.Config.Field(Type = typeof(string), Max = "64", Nullable = Net.TheVpc.Upa.Config.BoolEnum.TRUE, Path = "lock_infos")]
        private Net.TheVpc.Upa.Config.FieldDesc lockedEntity;

        [Net.TheVpc.Upa.Config.Field(Type = typeof(string), Max = "64", Nullable = Net.TheVpc.Upa.Config.BoolEnum.TRUE, Path = "lock_infos")]
        private Net.TheVpc.Upa.Config.FieldDesc lockId;

        [Net.TheVpc.Upa.Config.Field(Type = typeof(Net.TheVpc.Upa.Types.DateTime), Nullable = Net.TheVpc.Upa.Config.BoolEnum.TRUE, Path = "lock_infos")]
        private Net.TheVpc.Upa.Config.FieldDesc lockTime;
    }
}
