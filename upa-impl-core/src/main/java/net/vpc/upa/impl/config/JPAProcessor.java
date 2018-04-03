package net.vpc.upa.impl.config;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.UPA;
import net.vpc.upa.config.ConfigInfo;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.config.DecorationValue;
import net.vpc.upa.config.Ignore;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.config.decorations.SimpleDecoration;

import java.util.HashMap;
import java.util.logging.Level;
import java.util.logging.Logger;

@PortabilityHint(target = "C#", name = "suppress")
public class JPAProcessor {
    private static final Logger log = Logger.getLogger(JPAProcessor.class.getName());
    public static final String[] JPA_ANNOTATIONS={
            "javax.persistence.Entity", "javax.persistence.Id", "javax.persistence.ManyToOne", "javax.annotation.PostConstruct"
    };

    /**
     * transform supported JPA Annotations to UPA Decorations
     */
    public static void processJAVAXAnnotations(DecorationRepository readFrom, DecorationRepository writeTo, boolean noIgnore) {

        int pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.persistence.Entity")) {
            Decoration ignored = noIgnore ? null : readFrom.getTypeDecoration(at.getLocationType(), Ignore.class.getName());
            if (ignored != null) {
                log.log(Level.FINE, "\t Ignored javax.persistence.Entity {0}", at);
                continue;
            }

            HashMap<String, DecorationValue> v = new HashMap<String, DecorationValue>();
            SimpleDecoration s = new SimpleDecoration(
                    net.vpc.upa.config.Entity.class.getName(),
                    at.getDecorationSourceType(),
                    at.getTarget(), at.getLocationType(), at.getLocation(), pos, ConfigInfo.DEFAULT, v);
            s.addPrimitiveAttribute("name",at.getString("name"));
//            readFrom.register(s);
            writeTo.visit(s);
            pos++;
        }
        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.persistence.Id")) {
//            Decoration ignored = repo.getTypeDecoration(at.getType(), Ignore.class.getName());
//            if (ignored != null) {
//                log.log(Level.FINE, "\t Ignored javax.persistence.Id {0}", at);
//                continue;
//            }
            HashMap<String, DecorationValue> v = new HashMap<String, DecorationValue>();
            SimpleDecoration s = new SimpleDecoration(
                    net.vpc.upa.config.Id.class.getName(),
                    at.getDecorationSourceType(),
                    at.getTarget(), at.getLocationType(), at.getLocation(), pos, ConfigInfo.DEFAULT, v);
//            readFrom.register(s);
            writeTo.visit(s);
            pos++;
        }
        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.persistence.ManyToOne")) {
//            Decoration ignored = repo.getTypeDecoration(at.getType(), Ignore.class.getName());
//            if (ignored != null) {
//                log.log(Level.FINE, "\t Ignored javax.persistence.Id javax.persistence.ManyToOne", at);
//                continue;
//            }
            HashMap<String, DecorationValue> v = new HashMap<String, DecorationValue>();
            SimpleDecoration s = new SimpleDecoration(
                    net.vpc.upa.config.ManyToOne.class.getName(),
                    at.getDecorationSourceType(),
                    at.getTarget(), at.getLocationType(), at.getLocation(), pos, ConfigInfo.DEFAULT, v);
//            readFrom.register(s);
            writeTo.visit(s);
            pos++;
        }

        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.annotation.PostConstruct")) {
            HashMap<String, DecorationValue> v = new HashMap<String, DecorationValue>();
            SimpleDecoration s = new SimpleDecoration(
                    net.vpc.upa.config.Init.class.getName(),
                    at.getDecorationSourceType(),
                    at.getTarget(), at.getLocationType(), at.getLocation(), pos, ConfigInfo.DEFAULT, v);
//            readFrom.register(s);
            writeTo.visit(s);
            pos++;
        }
    }

}
