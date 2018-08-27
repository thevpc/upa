package net.vpc.upa.impl.extension;

import net.vpc.upa.SingletonExtensionDefinition;
import net.vpc.upa.persistence.EntityOperationManager;
import net.vpc.upa.types.IntType;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.EntityExtensionDefinition;
import net.vpc.upa.SingletonExtension;

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
        if (entity.getIdFields().isEmpty()) {

            Field field = entity.addField(new DefaultFieldBuilder().setName("SGLcode")
                    .addModifier(UserFieldModifier.ID)
                    .setDefaultObject(0)
                    .setDataType(new IntType(0, 0, false, false))
                    .setProtectionLevel(ProtectionLevel.PRIVATE)
                    .setPersistFormula(new Sequence(SequenceStrategy.AUTO)));
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
