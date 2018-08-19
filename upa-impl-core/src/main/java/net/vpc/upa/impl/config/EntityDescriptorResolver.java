package net.vpc.upa.impl.config;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.EntityDescriptor;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.config.annotationparser.DecorationEntityDescriptorResolver;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.Collections;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.impl.config.annotationparser.DecorationComparator;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.util.StringUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/29/12 12:08 AM
 */
public class EntityDescriptorResolver {

    private static final Logger log = Logger.getLogger(EntityDescriptorResolver.class.getName());
    private DecorationRepository decorationRepository;
    private DecorationEntityDescriptorResolver annotationParser;
    private PersistenceUnit persistenceUnit;

    public EntityDescriptorResolver(PersistenceUnit persistenceUnit, DecorationRepository decorationRepository) {
        this.persistenceUnit = persistenceUnit;
        this.decorationRepository = decorationRepository;
        this.annotationParser = new DecorationEntityDescriptorResolver(decorationRepository, persistenceUnit.getFactory());
    }

    public EntityDescriptor[] resolveAll(Object[] source) throws UPAException {
        List<EntityDescriptor> all = new ArrayList<>();
        Map<String, Set<Class>> entityClassesByName = new LinkedHashMap<String, Set<Class>>();
        for (Object item : source) {
            if (item instanceof Class) {
                Class tt = (Class) item;
                log.log(Level.FINE, "\t Detected Entity Class {0}", tt);
                Object[] nameAndType = resolveEntityNameAndType(tt);
                String foundName = (String) nameAndType[0];
                Class foundType = (Class) nameAndType[1];
                if (!StringUtils.isNullOrEmpty(foundName)) {
                    //okkay
                } else if (foundType != null) {
                    Object[] nameAndType2 = resolveEntityNameAndType(foundType);
                    String foundName2 = (String) nameAndType2[0];
                    Class foundType2 = (Class) nameAndType2[1];
                    if (foundName2 == null && foundType2 == null) {
                        //this is a link to a plain type!
                        foundName = tt.getSimpleName();
                    }
                } else {
                    foundName = tt.getSimpleName();
                    foundType = tt;
                }
                Set<Class> s = entityClassesByName.get(foundName);
                if (s == null) {
                    s = new HashSet<>();
                    entityClassesByName.put(foundName, s);
                }
                s.add(tt);
            } else if (item instanceof EntityDescriptor) {
                all.add((EntityDescriptor) item);
            } else {
                throw new UPAIllegalArgumentException("Unsupported");
            }
        }
        for (Set<Class> set : entityClassesByName.values()) {
            EntityDescriptor y = resolve(set);
            all.add(y);
        }
        return all.toArray(new EntityDescriptor[all.size()]);
    }

    private Object[] resolveEntityNameAndType(Class tt) {
        List<Decoration> all = new ArrayList<>();
        all.addAll(Arrays.asList(decorationRepository.getTypeDecorations(tt.getName(), net.vpc.upa.config.Entity.class.getName())));
        all.addAll(Arrays.asList(decorationRepository.getTypeDecorations(tt.getName(), net.vpc.upa.config.View.class.getName())));
        all.addAll(Arrays.asList(decorationRepository.getTypeDecorations(tt.getName(), net.vpc.upa.config.UnionEntity.class.getName())));
        all.addAll(Arrays.asList(decorationRepository.getTypeDecorations(tt.getName(), net.vpc.upa.config.Singleton.class.getName())));
        Collections.sort(all, DecorationComparator.INSTANCE);
        String foundName = null;
        Class foundType = null;
        for (Decoration decoration : all) {
            if (decoration.contains("name") && !StringUtils.isNullOrEmpty(decoration.getString("name"))) {
                foundName = StringUtils.trim(decoration.getString("name"));
            } else if (decoration.contains("entityType") && decoration.getType("entityType") != null) {
                foundType = decoration.getType("entityType");
            }
        }
        if (all.size() > 0 && foundName == null) {
            foundName = tt.getSimpleName();
        }
        return new Object[]{foundName, foundType};
    }

    public EntityDescriptor resolve(Object source) throws UPAException {
        if (source == null) {
            throw new UPAIllegalArgumentException("null entity descriptor");
        }
        if (source instanceof EntityDescriptor) {
            return (EntityDescriptor) source;
        }
        if (source instanceof Class) {
            ArrayList<Class> classesColl = new ArrayList<Class>();
            classesColl.add((Class) source);
            source = classesColl;
        } else if (source instanceof Class[]) {
            ArrayList<Class> classesColl = new ArrayList<Class>();
            for (Object o : (Class[]) source) {
                if (o instanceof Class) {
                    classesColl.add((Class) o);
                } else {
                    classesColl = null;
                    break;
                }
            }
            source = classesColl;
        } else if (isCollection(source)) {
            ArrayList<Class> classesColl = new ArrayList<Class>();
            for (Object o : (Collection<Object>) source) {
                if (o instanceof Class) {
                    classesColl.add((Class) o);
                } else {
                    throw new UPAException(new I18NString("ExpectedEntityDescriptorOrAnnotatedClass"));
                }
            }
        }

        if (isCollection(source)) {
            Collection<Class> classesColl = (Collection<Class>) source;
            if (classesColl.isEmpty()) {
                throw new UPAException(new I18NString("ExpectedEntityDescriptorOrAnnotatedClass"));
            }
            Class[] classes = classesColl.toArray(new Class[classesColl.size()]);
            persistenceUnit.scan(persistenceUnit.getPersistenceGroup().getContext().getFactory().createClassScanSource(classes).setNoIgnore(true), null, false);
            return annotationParser.resolve(classes);
        }
        throw new UPAException(new I18NString("ExpectedEntityDescriptorOrAnnotatedClass"));
    }

    protected boolean isCollection(Object o) {
        boolean ok = false;
        /**
         * @PortabilityHint(target="C#", name="replace") ok=o is
         * System.Collections.ICollection;
         */
        ok = o instanceof Collection;
        return ok;
    }
}
