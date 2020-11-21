package net.thevpc.upa.impl.jpa;

import net.thevpc.upa.config.*;
import net.thevpc.upa.impl.config.decorations.DecorationRepository;
import net.thevpc.upa.impl.config.decorations.SimpleDecoration;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.config.*;

import java.util.logging.Level;
import java.util.logging.Logger;

@PortabilityHint(target = "C#", name = "suppress")
public class JPAAnnotationsAdapter {
    private static final Logger log = Logger.getLogger(JPAAnnotationsAdapter.class.getName());
    public static final String[] JPA_ANNOTATIONS={
            "javax.persistence.Entity",
            "javax.persistence.Id",
            "javax.persistence.ManyToOne",
            "javax.persistence.Temporal",
            "javax.persistence.GeneratedValue",
            "javax.persistence.SequenceGenerator",
            "javax.persistence.Table",
            "javax.persistence.Column",
            "javax.annotation.PostConstruct"
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
            SimpleDecoration s = new SimpleDecoration(Entity.class,at, pos);
            s.copyAttributes(at,"name");
            writeTo.visit(s);
            pos++;
        }
        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.persistence.Id")) {
            SimpleDecoration s = new SimpleDecoration(Id.class,at, pos);
            writeTo.visit(s);
            pos++;
        }
        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.persistence.ManyToOne")) {
            SimpleDecoration s = new SimpleDecoration(ManyToOne.class,at, pos);
            writeTo.visit(s);
            pos++;
        }

        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.annotation.PostConstruct")) {
            SimpleDecoration s = new SimpleDecoration(Init.class,at, pos);
            writeTo.visit(s);
            pos++;
        }
        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.annotation.ManyToOne")) {
            SimpleDecoration s = new SimpleDecoration(ManyToOne.class,at, pos);
            writeTo.visit(s);
            pos++;
        }
        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.annotation.OneToOne")) {
            SimpleDecoration s = new SimpleDecoration(OneToOne.class,at, pos);
            writeTo.visit(s);
            pos++;
        }
        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.annotation.Temporal")) {
            SimpleDecoration s = new SimpleDecoration(Temporal.class,at, pos);
            writeTo.visit(s);
            pos++;
        }

        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.annotation.SequenceGenerator")) {
            DecorationValue name=at.get("name");
            DecorationValue sequenceName=at.get("sequenceName");
            DecorationValue catalog=at.get("catalog");
            DecorationValue schema=at.get("schema");
            DecorationValue initialValue=at.get("initialValue");
            DecorationValue allocationSize=at.get("allocationSize");
            if(at.getTarget()== DecorationTarget.FIELD || at.getTarget()== DecorationTarget.FIELD) {
                SimpleDecoration s = new SimpleDecoration(Sequence.class, at, pos);
                s.addAttribute("name", name);
                s.addAttribute("initialValue", initialValue);
                s.addAttribute("allocationSize", allocationSize);
                writeTo.visit(s);
                pos++;
            }else{
                // @Target(Type
                log.log(Level.SEVERE, "Unsupported @javax.annotation.SequenceGenerator on Class. Still to be done...");
            }
        }

        pos = 0;
        for (Decoration at : readFrom.getDeclaredDecorations("javax.annotation.GeneratedValue")) {
            DecorationValue strategy=at.get("strategy");
            DecorationValue generator=at.get("generator");
            if(at.getTarget()== DecorationTarget.FIELD || at.getTarget()== DecorationTarget.FIELD) {
                SimpleDecoration s = new SimpleDecoration(Sequence.class, at, pos);
//                s.addAttribute("name", name);
                writeTo.visit(s);
                pos++;
            }else{
                // @Target(Type
            }
        }
    }

}
