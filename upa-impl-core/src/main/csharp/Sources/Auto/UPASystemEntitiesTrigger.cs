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


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    internal class UPASystemEntitiesTrigger : Net.Vpc.Upa.Callbacks.PersistenceUnitListenerAdapter {

        private readonly Net.Vpc.Upa.Impl.DefaultPersistenceUnit outer;

        public UPASystemEntitiesTrigger(Net.Vpc.Upa.Impl.DefaultPersistenceUnit outer) {
            this.outer = outer;
        }


        public override void OnPreModelChanged(Net.Vpc.Upa.Callbacks.PersistenceUnitEvent @event) {
            foreach (Net.Vpc.Upa.Entity entity in outer.GetEntities()) {
                if (entity.GetShield().IsLockingSupported()) {
                    if (!outer.ContainsEntity(Net.Vpc.Upa.Impl.LockInfoDesc.LOCK_INFO_ENTITY_NAME)) {
                        outer.AddEntity(typeof(Net.Vpc.Upa.Impl.LockInfoDesc));
                    }
                    outer.AddLockingSupport(entity);
                }
                System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = entity.GetFields();
                bool privateSeq = false;
                foreach (Net.Vpc.Upa.Field field in fields) {
                    System.Collections.Generic.List<Net.Vpc.Upa.Sequence> seqs = new System.Collections.Generic.List<Net.Vpc.Upa.Sequence>();
                    if ((field.GetPersistFormula() is Net.Vpc.Upa.Sequence)) {
                        seqs.Add((Net.Vpc.Upa.Sequence) field.GetPersistFormula());
                    }
                    if ((field.GetUpdateFormula() is Net.Vpc.Upa.Sequence)) {
                        seqs.Add((Net.Vpc.Upa.Sequence) field.GetUpdateFormula());
                    }
                    foreach (Net.Vpc.Upa.Sequence sequence in seqs) {
                        Net.Vpc.Upa.SequenceStrategy strategy = sequence.GetStrategy();
                        string g = sequence.GetGroup();
                        string f = sequence.GetFormat();
                        switch(strategy) {
                            case Net.Vpc.Upa.SequenceStrategy.UNSPECIFIED:
                            case Net.Vpc.Upa.SequenceStrategy.AUTO:
                            case Net.Vpc.Upa.SequenceStrategy.IDENTITY:
                                {
                                    Net.Vpc.Upa.Types.DataType d = (field.GetDataType());
                                    System.Type platformType = d.GetPlatformType();
                                    bool ofIntegerType = Net.Vpc.Upa.Impl.Util.PlatformUtils.IsAnyInteger(platformType);
                                    if (ofIntegerType) {
                                        if (field.IsId() && g == null) {
                                            privateSeq = false;
                                        } else {
                                            privateSeq = true;
                                        }
                                    } else if (typeof(string).Equals(platformType)) {
                                        privateSeq = true;
                                    } else {
                                        throw new Net.Vpc.Upa.Exceptions.UPAException("UnsupportedGeneratedValueTypeException", field, platformType);
                                    }
                                    break;
                                }
                            case Net.Vpc.Upa.SequenceStrategy.SEQUENCE:
                                {
                                    privateSeq = true;
                                    break;
                                }
                            case Net.Vpc.Upa.SequenceStrategy.TABLE:
                                {
                                    privateSeq = true;
                                    break;
                                }
                            default:
                                {
                                    throw new Net.Vpc.Upa.Exceptions.UPAException("UnsupportedGeneratedValueStrategyException", field);
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
                if (privateSeq && !outer.ContainsEntity(Net.Vpc.Upa.Impl.PrivateSequence.ENTITY_NAME)) {
                    outer.AddEntity(typeof(Net.Vpc.Upa.Impl.PrivateSequence));
                }
            }
        }
    }
}
