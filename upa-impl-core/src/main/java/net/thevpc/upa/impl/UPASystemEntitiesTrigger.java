/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl;

import net.thevpc.upa.impl.ext.PersistenceUnitExt;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.impl.sysentities.LockInfoDesc;
import net.thevpc.upa.impl.sysentities.PrivateSequence;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.Sequence;
import net.thevpc.upa.SequenceStrategy;
import net.thevpc.upa.events.PersistenceUnitEvent;
import net.thevpc.upa.events.PersistenceUnitListener;
import net.thevpc.upa.events.PersistenceUnitListenerAdapter;
import net.thevpc.upa.types.DataType;

import java.util.ArrayList;
import java.util.List;
import net.thevpc.upa.exceptions.UnsupportedUPAFeatureException;

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
                        case DEFAULT:
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
                                throw new UnsupportedUPAFeatureException("UnsupportedGeneratedValueTypeException", field, platformType);
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
                            throw new UnsupportedUPAFeatureException("UnsupportedGeneratedValueStrategyException", field);
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
