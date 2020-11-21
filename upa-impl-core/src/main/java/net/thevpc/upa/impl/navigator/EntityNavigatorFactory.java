package net.thevpc.upa.impl.navigator;

import net.thevpc.upa.Entity;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/24/12 9:22 PM
 */
public class EntityNavigatorFactory {
    public static final DefaultEntityNavigator createDefaultNavigator(Entity e){ return new DefaultEntityNavigator(e);}
    public static final StringKeyEntityNavigator createStringNavigator(Entity e){ return new StringKeyEntityNavigator(e);}
    public static final StringSequenceEntityNavigator createStringSequenceNavigator(Entity entity, String name, String format, String group, int initialValue, int allocationSize){
        return new StringSequenceEntityNavigator(entity, name, format, group, initialValue, allocationSize);
    }
    public static final IntegerKeyEntityNavigator createIntegerNavigator(Entity e){ return new IntegerKeyEntityNavigator (e);}
    public static final DateKeyEntityNavigator createDateNavigator(Entity e){ return new DateKeyEntityNavigator(e);}
    public static final LongKeyEntityNavigator createLongNavigator(Entity e){ return new LongKeyEntityNavigator (e);}

}
