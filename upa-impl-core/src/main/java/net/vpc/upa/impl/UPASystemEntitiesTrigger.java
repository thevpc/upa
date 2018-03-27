/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.Sequence;
import net.vpc.upa.SequenceStrategy;
import net.vpc.upa.callbacks.PersistenceUnitEvent;
import net.vpc.upa.callbacks.PersistenceUnitListener;
import net.vpc.upa.callbacks.PersistenceUnitListenerAdapter;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.ext.PersistenceUnitExt;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.DataType;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
class UPASystemEntitiesTrigger extends PersistenceUnitListenerAdapter implements PersistenceUnitListener {

    private final PersistenceUnitExt pu;

    public UPASystemEntitiesTrigger(PersistenceUnitExt pu) {
        this.pu = pu;
    }

    @Override
    public void onPreModelChanged(PersistenceUnitEvent event) {
        for (Entity entity : pu.getEntities()) {
            if (entity.getShield().isLockingSupported()) {
                if (!pu.containsEntity(LockInfoDesc.LOCK_INFO_ENTITY_NAME)) {
                    pu.addEntity(LockInfoDesc.class);
                }
                pu.addLockingSupport(entity);
            }
            List<Field> fields = entity.getFields();
            boolean privateSeq = false;
            for (Field field : fields) {
                ArrayList<Sequence> seqs = new ArrayList<Sequence>();
                if ((UPAUtils.getPersistFormula(field) instanceof Sequence)) {
                    seqs.add((Sequence) UPAUtils.getPersistFormula(field));
                }
                if ((UPAUtils.getUpdateFormula(field) instanceof Sequence)) {
                    seqs.add((Sequence) UPAUtils.getUpdateFormula(field));
                }
                for (Sequence sequence : seqs) {
                    SequenceStrategy strategy = sequence.getStrategy();
                    String g = sequence.getGroup();
                    String f = sequence.getFormat();
                    switch (strategy) {
                        case UNSPECIFIED:
                        case AUTO:
                        case IDENTITY: {
                            DataType d = (field.getDataType());
                            Class platformType = d.getPlatformType();
                            boolean ofIntegerType = PlatformUtils.isAnyInteger(platformType);
                            if (ofIntegerType) {
                                if (field.isId() && g == null) {
                                    privateSeq = false;
                                } else {
                                    privateSeq = true;
                                }
                            } else if (String.class.equals(platformType)) {
                                privateSeq = true;
                            } else {
                                throw new UPAException("UnsupportedGeneratedValueTypeException", field, platformType);
                            }
                            break;
                        }
                        case SEQUENCE: {
                            privateSeq = true;
                            break;
                        }
                        case TABLE: {
                            privateSeq = true;
                            break;
                        }
                        default: {
                            throw new UPAException("UnsupportedGeneratedValueStrategyException", field);
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
            if (privateSeq && !pu.containsEntity(PrivateSequence.ENTITY_NAME)) {
                pu.addEntity(PrivateSequence.class);
            }
        }

    }
}
