# upa,  "The Unstructured Persistence API"


Unstructured Persistence API, referred to as UPA, is a genuine effort to raise programming language frameworks managing relational data in applications using Java Platform, Standard Edition and Java Platform, Enterprise Edition and Dot Net Framework equally to the next level of handling ORM for mutable data structures. UPA is intended to provide a solid reflection mechanisms to the mapped data structures while affording to make changes at runtime of those data structures. Besides, UPA has learned considerably of the leading ORM (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few) failures to satisfy very common even known to be trivial requirement in enterprise applications. UPA claims to be a better tool when used in critical conditions for the following reasons: 

# Unique Features

## Reflexion API
Large applications need better reflexion mechanisms to handle general purpose use cases. This feature enables developers to be aware of used data model at runtime : entities, fields, datatypes, ...
## Dynamic data definition and alteration
One unique feature is to enable at runtime data structure alteration by creating new entities or altering existing entities by introducing new fields, removing some fields etc. This feature makes UPA helpful for dynamic model based applications that usually uses vertical tables (columns as rows) which are of very little performance.
## Comprehensive model structuring
UPA provides a special model structuring beyond traditional persistence units organized as simple entities of fields. With new concepts of "package", "module", "entity","section" and "field" concepts , software architects can enforce their application modularity by organizing their data model according to their business model and helps creating real application fragments.
## Generated & Formula fields
UPA supports natively customizable formula fields. Formula fields are fields for which values are generated according to custom expressions and conditions. Formula field can be used either for generated identifiers or any other field. Generated identifiers may be of any type (not only integers). Other usage of Formula fields include total fields, special incremental fields such as line indices in invoice.
## Ready to use Entity Patterns
UPA supports natively Tree Entities for entities referencing them selves with full optimized deep searching. Singleton entities are also supported in a very clean manner mapped as a single row table. Union Entities is another pattern that makes is possible to uniformize search and updates from distinct entities.
## Uniform persistence context access
The API can be used in the very same way from Java desktop application, Web containers, EJB containers, Spring container, .Net Destop applications, ASP.Net Web Forms applications, ASP.Net Web MVC applications.
## Shared Model
The very same persistence model can be used on multiple database schemas at the same time. Therefore Entity classes are not attached to a specific persistence unit and can be mutualized. Besides, the same classes can be used for mapping different tables in the same schema at the entity definition time. Even better, generic classes can be specified at search time to hold information of some existing entities. One example is to use a generic class holder "NamedEntity" (with solely id and name) to use for all drop down components.
## Dynamic Lazy/Partial loading
UPA enables the runtime selection of needed fields/relations for retrieval. this is obviously helpful for performance tuning. In most cases, listing entities does not require retrieval of all information. However entity editing should handle all updatable fields.
## Very flexible persistence processing
Entities may be configured to retrieve information from one table, insert to a second table delete using a stored procedure and update using a custom Java class for instance.
## Rich Callback System
UPA defines a rich set of Callback mechanisms. Callbacks are available both on Data updates and Data Structure alteration. Data Callbacks enables soft trigger implementations for handling all of inserts, updates and delete operations. Data Structure Callbacks makes it possible to capture Data Structure changes and perform even extra alteration when needed.
## Portable support for custom and complex datatypes
UPA supports all common data types, besides it provides a portable manner to extend supported types with new custom/complex ones. This features is similar to Embedded/Embeddable features in JPA although it provides a more extensible manner.
## Designed to work equally on Java and .Net platforms
UPA is designed to work with major Object Oriented languages although the very first implementation it provides is with Java(c) and C# (c). Design consideration imposes some restrictions to language advanced features but provides betted concepts understanding, a cleaner implementation and perhaps makes it more intuitive at its usage.
## Soft learning curve
UPA provide better performance and a softer learning curve, we have made the choice to make UPQL nearer to SQL than to JPQL. UPA have also native support of views defined using the very same UPQL language. 


# Common Features
## Vendor Neural Persistence Layer
UPA helps you build a persistence layer that is vendor neutral and any persistence provider can be used. Although, UPA provides a reference implementation that is particularly performant and ready to use. 
## Pluggable Providers
UPA supports pluggable, third party persistence providers as it is defined as an API with a reference implementation
## Inside/Outside containers
UPA application can run outside the container also. So, developers can use UPA capabilities in desktop applications also.
## Annotations based meta-data
No need to write deployment descriptors. Annotations based meta-data very similar of JPA’s are supported Besides, annotations defaults can be used in model class, which saves a lot of development time
## Standardized ORM
Provides clean, easy, and standardized object-relational mapping
## Query language
UPQL is very powerfully query language provided by UPA providing abstraction layer over the persistence model. UPQL makes it possible to avoid specific RDBMS dialects.
## Model generation
UPA application can also be configured to generate database schema based on persistence model
## Portability
It is also very easy to switch to most performing persistence provider. You can easily move to any commercial persistence providers when needed
## Intuitive
UPA is very simple to apprehend for developers that have already worked especially with JPA and JPA annotations. 
