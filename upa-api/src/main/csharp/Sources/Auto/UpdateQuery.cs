/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    /**
     * Created by vpc on 6/12/16.
     */
    public interface UpdateQuery {

         Net.Vpc.Upa.UpdateQuery SetNone();

         Net.Vpc.Upa.UpdateQuery SetValues(object @object);

         Net.Vpc.Upa.UpdateQuery SetValues(Net.Vpc.Upa.Document document);

         object GetValues();

         Net.Vpc.Upa.UpdateQuery ById(object expr);

          Net.Vpc.Upa.UpdateQuery ByIdList<T>(System.Collections.Generic.IList<T> expr);

         Net.Vpc.Upa.UpdateQuery ByKey(Net.Vpc.Upa.Key expr);

         Net.Vpc.Upa.UpdateQuery ByObject(object expr);

         Net.Vpc.Upa.UpdateQuery ByPrototype(object expr);

         Net.Vpc.Upa.UpdateQuery ByDocument(Net.Vpc.Upa.Document expr);

         Net.Vpc.Upa.UpdateQuery ByPrototype(Net.Vpc.Upa.Document expr);

         Net.Vpc.Upa.UpdateQuery ByKeyList(System.Collections.Generic.IList<Net.Vpc.Upa.Key> expr);

         Net.Vpc.Upa.UpdateQuery ByExpressionList(System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expr);

         Net.Vpc.Upa.UpdateQuery ByExpression(Net.Vpc.Upa.Expressions.Expression expr);

         Net.Vpc.Upa.UpdateQuery ByAll();

         Net.Vpc.Upa.ConditionType GetUpdateConditionType();

         object GetUpdateCondition();

         System.Collections.Generic.IDictionary<string , object> GetHints();

         System.Collections.Generic.IDictionary<string , object> GetHints(bool autoCreate);

         Net.Vpc.Upa.UpdateQuery SetHints(System.Collections.Generic.IDictionary<string , object> hints);

         Net.Vpc.Upa.UpdateQuery SetHint(string name, object @value);

         Net.Vpc.Upa.UpdateQuery AddUpdatableField(string name);

         Net.Vpc.Upa.UpdateQuery RemoveUpdatableField(string name);

         Net.Vpc.Upa.UpdateQuery AddUpdatableFields(params string [] names);

         Net.Vpc.Upa.UpdateQuery RemoveUpdatableFields(params string [] names);

         Net.Vpc.Upa.UpdateQuery AddUpdatableFields(System.Collections.Generic.ICollection<string> names);

         Net.Vpc.Upa.UpdateQuery RemoveUpdatableFields(System.Collections.Generic.ICollection<string> names);

         Net.Vpc.Upa.UpdateQuery UpdateAll();

         System.Collections.Generic.ISet<string> GetUpdatedFields();

         Net.Vpc.Upa.UpdateQuery SetUpdatedFields(System.Collections.Generic.ICollection<string> partialUpdateFields);

         Net.Vpc.Upa.UpdateQuery Update(System.Collections.Generic.ICollection<string> partialUpdateFields);

         Net.Vpc.Upa.UpdateQuery Update(params string [] partialUpdateFields);

         Net.Vpc.Upa.UpdateQuery Update(string partialUpdateFields);

         Net.Vpc.Upa.UpdateQuery RemoveUpdatedFields(System.Collections.Generic.ICollection<string> partialUpdateFields);

         Net.Vpc.Upa.Filters.FieldFilter GetFormulaFields();

         Net.Vpc.Upa.UpdateQuery Validate(string formulaField);

         Net.Vpc.Upa.UpdateQuery Validate(params string [] formulaFields);

         Net.Vpc.Upa.UpdateQuery Validate(System.Collections.Generic.ICollection<string> formulaFields);

         Net.Vpc.Upa.UpdateQuery Validate(Net.Vpc.Upa.Filters.FieldFilter formulaFields);

         Net.Vpc.Upa.UpdateQuery ValidateAll();

         Net.Vpc.Upa.UpdateQuery ValidateNone();

         bool IsIgnoreUnspecified();

         Net.Vpc.Upa.UpdateQuery SetIgnoreUnspecified(bool ignoreUnspecified);

         long Execute();
    }
}
