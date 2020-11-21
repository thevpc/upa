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



namespace Net.TheVpc.Upa
{


    /**
     * Created by vpc on 6/12/16.
     */
    public interface UpdateQuery {

         Net.TheVpc.Upa.UpdateQuery SetNone();

         Net.TheVpc.Upa.UpdateQuery SetValues(object @object);

         Net.TheVpc.Upa.UpdateQuery SetValues(Net.TheVpc.Upa.Document document);

         object GetValues();

         Net.TheVpc.Upa.UpdateQuery ById(object expr);

          Net.TheVpc.Upa.UpdateQuery ByIdList<T>(System.Collections.Generic.IList<T> expr);

         Net.TheVpc.Upa.UpdateQuery ByKey(Net.TheVpc.Upa.Key expr);

         Net.TheVpc.Upa.UpdateQuery ByObject(object expr);

         Net.TheVpc.Upa.UpdateQuery ByPrototype(object expr);

         Net.TheVpc.Upa.UpdateQuery ByDocument(Net.TheVpc.Upa.Document expr);

         Net.TheVpc.Upa.UpdateQuery ByPrototype(Net.TheVpc.Upa.Document expr);

         Net.TheVpc.Upa.UpdateQuery ByKeyList(System.Collections.Generic.IList<Net.TheVpc.Upa.Key> expr);

         Net.TheVpc.Upa.UpdateQuery ByExpressionList(System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> expr);

         Net.TheVpc.Upa.UpdateQuery ByExpression(Net.TheVpc.Upa.Expressions.Expression expr);

         Net.TheVpc.Upa.UpdateQuery ByAll();

         Net.TheVpc.Upa.ConditionType GetUpdateConditionType();

         object GetUpdateCondition();

         System.Collections.Generic.IDictionary<string , object> GetHints();

         System.Collections.Generic.IDictionary<string , object> GetHints(bool autoCreate);

         Net.TheVpc.Upa.UpdateQuery SetHints(System.Collections.Generic.IDictionary<string , object> hints);

         Net.TheVpc.Upa.UpdateQuery SetHint(string name, object @value);

         Net.TheVpc.Upa.UpdateQuery AddUpdatableField(string name);

         Net.TheVpc.Upa.UpdateQuery RemoveUpdatableField(string name);

         Net.TheVpc.Upa.UpdateQuery AddUpdatableFields(params string [] names);

         Net.TheVpc.Upa.UpdateQuery RemoveUpdatableFields(params string [] names);

         Net.TheVpc.Upa.UpdateQuery AddUpdatableFields(System.Collections.Generic.ICollection<string> names);

         Net.TheVpc.Upa.UpdateQuery RemoveUpdatableFields(System.Collections.Generic.ICollection<string> names);

         Net.TheVpc.Upa.UpdateQuery UpdateAll();

         System.Collections.Generic.ISet<string> GetUpdatedFields();

         Net.TheVpc.Upa.UpdateQuery SetUpdatedFields(System.Collections.Generic.ICollection<string> partialUpdateFields);

         Net.TheVpc.Upa.UpdateQuery Update(System.Collections.Generic.ICollection<string> partialUpdateFields);

         Net.TheVpc.Upa.UpdateQuery Update(params string [] partialUpdateFields);

         Net.TheVpc.Upa.UpdateQuery Update(string partialUpdateFields);

         Net.TheVpc.Upa.UpdateQuery RemoveUpdatedFields(System.Collections.Generic.ICollection<string> partialUpdateFields);

         Net.TheVpc.Upa.Filters.FieldFilter GetFormulaFields();

         Net.TheVpc.Upa.UpdateQuery Validate(string formulaField);

         Net.TheVpc.Upa.UpdateQuery Validate(params string [] formulaFields);

         Net.TheVpc.Upa.UpdateQuery Validate(System.Collections.Generic.ICollection<string> formulaFields);

         Net.TheVpc.Upa.UpdateQuery Validate(Net.TheVpc.Upa.Filters.FieldFilter formulaFields);

         Net.TheVpc.Upa.UpdateQuery ValidateAll();

         Net.TheVpc.Upa.UpdateQuery ValidateNone();

         bool IsIgnoreUnspecified();

         Net.TheVpc.Upa.UpdateQuery SetIgnoreUnspecified(bool ignoreUnspecified);

         long Execute();
    }
}
