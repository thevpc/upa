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
import net.vpc.upa.types.DataType;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
class UPASystemEntitiesTrigger extends PersistenceUnitListenerAdapter implements PersistenceUnitListener {

    private final PersistenceUnitExt outer;

    public UPASystemEntitiesTrigger(final PersistenceUnitExt outer) {
        this.outer = outer;
    }

    @Override
    public void onPreModelChanged(PersistenceUnitEvent event) {
        for (Entity entity : outer.getEntities()) {
            if (entity.getShield().isLockingSupported()) {
                if (!outer.containsEntity(LockInfoDesc.LOCK_INFO_ENTITY_NAME)) {
                    outer.addEntity(LockInfoDesc.class);
                }
                outer.addLockingSupport(entity);
            }
            List<Field> fields = entity.getFields();
            boolean privateSeq = false;
            for (Field field : fields) {
                ArrayList<Sequence> seqs = new ArrayList<Sequence>();
                if ((field.getPersistFormula() instanceof Sequence)) {
                    seqs.add((Sequence) field.getPersistFormula());
                }
                if ((field.getUpdateFormula() instanceof Sequence)) {
                    seqs.add((Sequence) field.getUpdateFormula());
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
            if (privateSeq && !outer.containsEntity(PrivateSequence.ENTITY_NAME)) {
                outer.addEntity(PrivateSequence.class);
            }
        }

    }
}
