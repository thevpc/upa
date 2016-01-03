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



namespace Net.Vpc.Upa
{

    public enum FieldModifier {

        /**
             * ID fields defines the Entity Identifier's fields witch is mapped to the
             * Table's primary key. An Entity may define zero or many ID fields but is
             * is recommended to define at least one ID field. When many fields are
             * defines as ID, the order in which fields are defines happens to be the
             * same order the primary keys definition. An ID field may be a compound
             * field but could not be dynamic field. ID fields could not be transient
             * (QUERY, VIEW, ...)
             */
        ID, /**
             * Main field is the user friendly field that helps distinguishing distinct
             * entities. This is, in most cases the "name" or "label" of the entity such
             * as Client name or Company name. An Entity may define zero or one MAIN
             * Field but is is recommended to de define exactly one MAIN field. If many
             * MAIN fields (more than one) are defined, only the first one is to be
             * considered as MAIN
             */
        MAIN, /**
             * HEAD field is a field that "summaries" and "highlights" significant
             * information needed to be known a first degree. HEAD fields are less
             * important than MAIN field be should be more significant than other
             * fields. An Entity may define zero or more HEAD Fields. a "COMPUTER"
             * Product's mark maybe considered as a "HEAD" information, an other example
             * is an "Email"'s "sender" may also be considered as "HEAD" field. Dynamic
             * UI builder frameworks may use this information to force "Listing" of such
             * fields along with MAIN field.
             */
        SUMMARY, /**
             * FOREIGN Fields are fields that appear in a Relationship Detail Role that's to
             * say fields that references primary key of another Entity FOREIGN fields
             * are managed by the framework and should never be set directly by
             * application. FOREIGN fields always points to REFERENCED fields
             */
        FOREIGN, PERSIST, PERSIST_DEFAULT, PERSIST_FORMULA, PERSIST_SEQUENCE, UPDATE, UPDATE_DEFAULT, UPDATE_FORMULA, UPDATE_SEQUENCE, SELECT, SELECT_DEFAULT, SELECT_LIVE, SELECT_COMPILED, SELECT_CUSTOM, REFERENCED, SYSTEM, TRANSIENT
    }
}
