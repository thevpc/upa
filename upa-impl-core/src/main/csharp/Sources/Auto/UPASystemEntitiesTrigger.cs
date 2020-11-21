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
    internal class UPASystemEntitiesTrigger : Net.TheVpc.Upa.Callbacks.PersistenceUnitListenerAdapter {

        private readonly Net.TheVpc.Upa.Impl.DefaultPersistenceUnit outer;

        public UPASystemEntitiesTrigger(Net.TheVpc.Upa.Impl.DefaultPersistenceUnit outer) {
            this.outer = outer;
        }


        public override void OnPreModelChanged(Net.TheVpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            foreach (Net.TheVpc.Upa.Entity entity in outer.GetEntities()) {
                if (entity.GetShield().IsLockingSupported()) {
                    if (!outer.ContainsEntity(Net.TheVpc.Upa.Impl.LockInfoDesc.LOCK_INFO_ENTITY_NAME)) {
                        outer.AddEntity(typeof(Net.TheVpc.Upa.Impl.LockInfoDesc));
                    }
                    outer.AddLockingSupport(entity);
                }
                System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields = entity.GetFields();
                bool privateSeq = false;
                foreach (Net.TheVpc.Upa.Field field in fields) {
                    System.Collections.Generic.List<Net.TheVpc.Upa.Sequence> seqs = new System.Collections.Generic.List<Net.TheVpc.Upa.Sequence>();
                    if ((field.GetPersistFormula() is Net.TheVpc.Upa.Sequence)) {
                        seqs.Add((Net.TheVpc.Upa.Sequence) field.GetPersistFormula());
                    }
                    if ((field.GetUpdateFormula() is Net.TheVpc.Upa.Sequence)) {
                        seqs.Add((Net.TheVpc.Upa.Sequence) field.GetUpdateFormula());
                    }
                    foreach (Net.TheVpc.Upa.Sequence sequence in seqs) {
                        Net.TheVpc.Upa.SequenceStrategy strategy = sequence.GetStrategy();
                        string g = sequence.GetGroup();
                        string f = sequence.GetFormat();
                        switch(strategy) {
                            case Net.TheVpc.Upa.SequenceStrategy.UNSPECIFIED:
                            case Net.TheVpc.Upa.SequenceStrategy.AUTO:
                            case Net.TheVpc.Upa.SequenceStrategy.IDENTITY:
                                {
                                    Net.TheVpc.Upa.Types.DataType d = (field.GetDataType());
                                    System.Type platformType = d.GetPlatformType();
                                    bool ofIntegerType = Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsAnyInteger(platformType);
                                    if (ofIntegerType) {
                                        if (field.IsId() && g == null) {
                                            privateSeq = false;
                                        } else {
                                            privateSeq = true;
                                        }
                                    } else if (typeof(string).Equals(platformType)) {
                                        privateSeq = true;
                                    } else {
                                        throw new Net.TheVpc.Upa.Exceptions.UPAException("UnsupportedGeneratedValueTypeException", field, platformType);
                                    }
                                    break;
                                }
                            case Net.TheVpc.Upa.SequenceStrategy.SEQUENCE:
                                {
                                    privateSeq = true;
                                    break;
                                }
                            case Net.TheVpc.Upa.SequenceStrategy.TABLE:
                                {
                                    privateSeq = true;
                                    break;
                                }
                            default:
                                {
                                    throw new Net.TheVpc.Upa.Exceptions.UPAException("UnsupportedGeneratedValueStrategyException", field);
                                }
                        }
                        if (privateSeq) {
                            break;
                        }
                    }
                    if (privateSeq) {
                        break;
                    }
                }
                if (privateSeq && !outer.ContainsEntity(Net.TheVpc.Upa.Impl.PrivateSequence.ENTITY_NAME)) {
                    outer.AddEntity(typeof(Net.TheVpc.Upa.Impl.PrivateSequence));
                }
            }
        }
    }
}
