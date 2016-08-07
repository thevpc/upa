package net.vpc.upa.impl.extension;

import net.vpc.upa.extensions.SingletonExtensionDefinition;
import net.vpc.upa.persistence.EntityOperationManager;
import net.vpc.upa.types.IntType;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.extensions.EntityExtensionDefinition;
import net.vpc.upa.persistence.SingletonExtension;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 12:39 AM
 */
public class DefaultSingletonExtension extends AbstractEntityExtension implements SingletonExtension {

    @Override
    public void install(Entity entity, EntityOperationManager entityOperationManager, EntityExtensionDefinition extension) throws UPAException {
        super.install(entity, entityOperationManager, extension);
    }

    @Override
    public void commitModelChanges() throws UPAException {
        Entity entity = getEntity();
        if (entity.getPrimaryFields().isEmpty()) {
            Field field = entity.addField("SGLcode", null, FlagSets.of(UserFieldModifier.ID), null, 0, new IntType(0, 0, false, false), -1);
            field.setAccessLevel(AccessLevel.PRIVATE);
            field.setPersistFormula(new Sequence(SequenceStrategy.AUTO));
        }
        if (!entity.getUserExcludeModifiers().contains(EntityModifier.NAVIGATE)) {
            entity.getModifiers().add(EntityModifier.NAVIGATE);
        }
    }

    @Override
    public boolean isAutoCreate() {
        SingletonExtensionDefinition entitySpec = (SingletonExtensionDefinition) getDefinition();
        return entitySpec.isAutoCreate();
    }

}
