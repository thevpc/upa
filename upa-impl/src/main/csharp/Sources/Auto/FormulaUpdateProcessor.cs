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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FormulaUpdateProcessor {

        internal bool nothingToValidate = false;

        internal bool forceExpressionTypeCasting = false;

        private System.Collections.Generic.IDictionary<int? , Net.Vpc.Upa.Impl.ValidationPass[]> orderedPasses = new System.Collections.Generic.Dictionary<int? , Net.Vpc.Upa.Impl.ValidationPass[]>(1);

        private System.Collections.Generic.ISet<Net.Vpc.Upa.Field> inUseFields = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Field>();

        private int size = 0;

        private Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.Entity entity;

        private bool onInsert;

        private Net.Vpc.Upa.Expressions.Expression expr;

        private Net.Vpc.Upa.Persistence.EntityExecutionContext context;

        private System.Collections.Generic.IList<object> keysToUpdate = null;

        public FormulaUpdateProcessor(bool onInsert, System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields, Net.Vpc.Upa.Expressions.Expression expr, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityOperationManager epm) {
            this.entityOperationManager = epm;
            this.entity = entity;
            this.expr = expr;
            this.context = context;
            this.onInsert = onInsert;
            this.persistenceUnit = entity.GetPersistenceUnit();
            foreach (Net.Vpc.Upa.Field field in fields) {
                AddField(field);
            }
        }

        private static Net.Vpc.Upa.Expressions.Expression GetFieldExpression(Net.Vpc.Upa.Field field, bool forInsert) {
            if (forInsert) {
                return (field.GetInsertFormula() is Net.Vpc.Upa.ExpressionFormula) ? ((Net.Vpc.Upa.ExpressionFormula) field.GetInsertFormula()).GetExpression() : null;
            } else {
                return (field.GetUpdateFormula() is Net.Vpc.Upa.ExpressionFormula) ? ((Net.Vpc.Upa.ExpressionFormula) field.GetUpdateFormula()).GetExpression() : null;
            }
        }

        public virtual bool AddField(Net.Vpc.Upa.Field f) {
            if (inUseFields.Contains(f)) {
                return false;
            }
            Net.Vpc.Upa.Formula formula = onInsert ? f.GetInsertFormula() : f.GetUpdateFormula();
            Net.Vpc.Upa.Impl.ValidationPass pass = null;
            int formulaPassInteger = onInsert ? f.GetInsertFormulaOrder() : f.GetUpdateFormulaOrder();
            // passIndexes.add(formulaPassInteger);
            Net.Vpc.Upa.Impl.ValidationPass[] passArray = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<int?,Net.Vpc.Upa.Impl.ValidationPass[]>(orderedPasses,formulaPassInteger);
            if (passArray == null) {
                orderedPasses[formulaPassInteger]=passArray = new Net.Vpc.Upa.Impl.ValidationPass[((Net.Vpc.Upa.Impl.ValidationPassType[])System.Enum.GetValues(typeof(Net.Vpc.Upa.Impl.ValidationPassType))).Length];
            }
            int pass1 = formulaPassInteger;
            if (formula is Net.Vpc.Upa.CustomUpdaterFormula) {
                pass = passArray[((int)Net.Vpc.Upa.Impl.ValidationPassType.MANUAL_VALIDATION)];
                if (pass == null) {
                    pass = passArray[((int)Net.Vpc.Upa.Impl.ValidationPassType.MANUAL_VALIDATION)] = new Net.Vpc.Upa.Impl.ValidationPass(pass1, Net.Vpc.Upa.Impl.ValidationPassType.MANUAL_VALIDATION);
                    size++;
                }
            } else if (formula is Net.Vpc.Upa.CustomFormula) {
                pass = passArray[((int)Net.Vpc.Upa.Impl.ValidationPassType.CUSTOM_VALIDATION)];
                if (pass == null) {
                    pass = passArray[((int)Net.Vpc.Upa.Impl.ValidationPassType.CUSTOM_VALIDATION)] = new Net.Vpc.Upa.Impl.ValidationPass(pass1, Net.Vpc.Upa.Impl.ValidationPassType.CUSTOM_VALIDATION);
                    size++;
                }
            } else {
                if (!entityOperationManager.GetPersistenceStore().IsComplexSelectSupported()) {
                    Net.Vpc.Upa.Expressions.Expression fe = GetFieldExpression(f, onInsert);
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ce = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) entity.Compile(fe);
                    System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> found = ce.FindExpressionsList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>(Net.Vpc.Upa.Impl.Uql.CompiledExpressionHelper.QUERY_STATEMENT_FILTER);
                    if ((found).Count > 0) {
                        pass = passArray[((int)Net.Vpc.Upa.Impl.ValidationPassType.ITERATIVE_VALIDATION)];
                        if (pass == null) {
                            pass = passArray[((int)Net.Vpc.Upa.Impl.ValidationPassType.ITERATIVE_VALIDATION)] = new Net.Vpc.Upa.Impl.ValidationPass(pass1, Net.Vpc.Upa.Impl.ValidationPassType.ITERATIVE_VALIDATION);
                            size++;
                        }
                    } else {
                        pass = passArray[((int)Net.Vpc.Upa.Impl.ValidationPassType.DEFAULT_VALIDATION)];
                        if (pass == null) {
                            pass = passArray[((int)Net.Vpc.Upa.Impl.ValidationPassType.DEFAULT_VALIDATION)] = new Net.Vpc.Upa.Impl.ValidationPass(pass1, Net.Vpc.Upa.Impl.ValidationPassType.DEFAULT_VALIDATION);
                            size++;
                        }
                    }
                } else {
                    pass = passArray[((int)Net.Vpc.Upa.Impl.ValidationPassType.DEFAULT_VALIDATION)];
                    if (pass == null) {
                        pass = passArray[((int)Net.Vpc.Upa.Impl.ValidationPassType.DEFAULT_VALIDATION)] = new Net.Vpc.Upa.Impl.ValidationPass(pass1, Net.Vpc.Upa.Impl.ValidationPassType.DEFAULT_VALIDATION);
                        size++;
                    }
                }
            }
            pass.fields.Add(f);
            inUseFields.Add(f);
            System.Collections.Generic.ICollection<Net.Vpc.Upa.PrimitiveField> dependency = (System.Collections.Generic.ICollection<Net.Vpc.Upa.PrimitiveField>) f.GetProperties().GetObject<System.Collections.Generic.ICollection<Net.Vpc.Upa.PrimitiveField>>(onInsert ? Net.Vpc.Upa.Impl.DefaultEntity.INSERT_DEPENDENT_FIELDS : Net.Vpc.Upa.Impl.DefaultEntity.UPDATE_DEPENDENT_FIELDS);
            if (dependency != null) {
                foreach (Net.Vpc.Upa.PrimitiveField aDependency in dependency) {
                    Net.Vpc.Upa.PrimitiveField df = (Net.Vpc.Upa.PrimitiveField) aDependency;
                    // add only formulas fields that are validateSupported
                    if (onInsert) {
                        Net.Vpc.Upa.Formula ff = df.GetInsertFormula();
                        if (ff != null && df.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA)) {
                            AddField(df);
                        }
                    } else {
                        Net.Vpc.Upa.Formula ff = df.GetUpdateFormula();
                        if (ff != null && df.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA)) {
                            AddField(df);
                        }
                    }
                }
            }
            return true;
        }

        public virtual int Size() {
            return size;
        }

        public virtual int Size0() {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.Impl.ValidationPass> ts = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Impl.ValidationPass>();
            foreach (Net.Vpc.Upa.Impl.ValidationPass[] o in (orderedPasses).Values) {
                for (int i = 0; i < 4; i++) {
                    if (o[i] != null) {
                        ts.Add(o[i]);
                    }
                }
            }
            return (ts).Count;
        }

        public virtual System.Collections.Generic.ICollection<Net.Vpc.Upa.Impl.ValidationPass> GetValidationPasses() {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.Impl.ValidationPass> ts = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Impl.ValidationPass>();
            foreach (Net.Vpc.Upa.Impl.ValidationPass[] o in (orderedPasses).Values) {
                for (int i = 0; i < 4; i++) {
                    if (o[i] != null) {
                        ts.Add(o[i]);
                    }
                }
            }
            return ts;
        }

        public virtual void UpdateFormulasCore() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Object transaction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
            //        boolean transactionSucceeded = false;
            //        try {
            keysToUpdate = null;
            //            if (monitor != null) {
            //                if (monitor.isStopped()) {
            //                    return;
            //                }
            //                monitor.setIndeterminate(false);
            //                monitor.setIndex(0);
            //                monitor.setMax(data.size0());
            //                System.out.println("Validate " + getName() + " : max = "
            //                        + monitor.getMax());
            //            }
            foreach (Net.Vpc.Upa.Impl.ValidationPass validationPass in GetValidationPasses()) {
                int updates = 0;
                switch(validationPass.type) {
                    case Net.Vpc.Upa.Impl.ValidationPassType.DEFAULT_VALIDATION:
                        {
                            updates = ValidateDefault(validationPass.fields, expr);
                            break;
                        }
                    case Net.Vpc.Upa.Impl.ValidationPassType.ITERATIVE_VALIDATION:
                        {
                            updates = ValidateDefaultIterative(validationPass.fields, expr);
                            break;
                        }
                    case Net.Vpc.Upa.Impl.ValidationPassType.CUSTOM_VALIDATION:
                        {
                            updates = ValidateCustomFormula(validationPass.fields);
                            break;
                        }
                    case Net.Vpc.Upa.Impl.ValidationPassType.MANUAL_VALIDATION:
                        {
                            // System.out.println("MANUAL_VALIDATION = " +
                            // validationPass.pass+" : "+validationPass.fields);
                            updates = ValidateCustomUpdaterFormula(validationPass.fields);
                            //                        if (monitor != null) {
                            //                            if (monitor.isStopped()) {
                            //                                return;
                            //                            }
                            //                            monitor.progress(String.valueOf(validationPass.pass),
                            //                                    "Passe " + (validationPass.pass + 1), null);
                            //                        }
                            break;
                        }
                }
                if (updates == 0) {
                    break;
                }
            }
        }

        protected internal virtual int ValidateCustomUpdaterFormula(System.Collections.Generic.ISet<Net.Vpc.Upa.Field> fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.CustomUpdaterFormula> unique = new System.Collections.Generic.HashSet<Net.Vpc.Upa.CustomUpdaterFormula>();
            foreach (Net.Vpc.Upa.Field field in fields) {
                Net.Vpc.Upa.CustomUpdaterFormula c = (Net.Vpc.Upa.CustomUpdaterFormula) (onInsert ? field.GetInsertFormula() : field.GetUpdateFormula());
                unique.Add(c);
            }
            foreach (Net.Vpc.Upa.CustomUpdaterFormula f in unique) {
                f.UpdateFormula(fields, expr, context);
            }
            return (int) entity.GetEntityCount(expr);
        }

        protected internal virtual int ValidateCustomFormula(System.Collections.Generic.ISet<Net.Vpc.Upa.Field> fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //                        if (monitor != null) {
            //                            if (monitor.isStopped()) {
            //                                return;
            //                            }
            //                            monitor.stepIn(keysToUpdate.size());
            //                        }
            int x = 0;
            foreach (object aKeysToUpdate in GetKeysToUpdate()) {
                //                            if (monitor != null) {
                //                                if (monitor.isStopped()) {
                //                                    return;
                //                                }
                //                                monitor.progress(String.valueOf(validationPass.pass), "Passe "
                //                                        + (validationPass.pass + 1), null);
                //                            }
                // System.out.println("ITERATIVE_VALIDATION = " +
                // validationPass.pass+" : "+validationPass.fields+" :
                // "+keysToUpdate[r]);
                Net.Vpc.Upa.Record u = entity.GetBuilder().CreateRecord();
                foreach (Net.Vpc.Upa.Field field in fields) {
                    Net.Vpc.Upa.CustomFormula cf = (Net.Vpc.Upa.CustomFormula) (onInsert ? field.GetInsertFormula() : field.GetUpdateFormula());
                    object v = cf.GetValue(field, aKeysToUpdate, context);
                    u.SetObject(field.GetName(), new Net.Vpc.Upa.Expressions.Cast(new Net.Vpc.Upa.Expressions.Param(null, v), field.GetDataType()));
                }
                x += entity.UpdateCore(u, entity.GetBuilder().IdToExpression(aKeysToUpdate, entity.GetName()), context);
            }
            //                        if (monitor != null) {
            //                            monitor.stepOut();
            //                        }
            return x;
        }

        private System.Collections.Generic.IList<object> GetKeysToUpdate() {
            if (keysToUpdate == null) {
                keysToUpdate = entity.CreateQueryBuilder().SetExpression(expr).SetOrder(entity.GetUpdateFormulasOrder()).GetIdList<object>();
                if ((keysToUpdate.Count==0)) {
                    nothingToValidate = true;
                }
            }
            return keysToUpdate;
        }

        protected internal virtual int ValidateDefaultIterative(System.Collections.Generic.ISet<Net.Vpc.Upa.Field> fields, Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //                        if (monitor != null) {
            //                            if (monitor.isStopped()) {
            //                                return;
            //                            }
            //                            monitor.stepIn(keysToUpdate.size());
            //                        }
            int x = 0;
            foreach (object aKeysToUpdate in GetKeysToUpdate()) {
                //                            if (monitor != null) {
                //                                if (monitor.isStopped()) {
                //                                    return;
                //                                }
                //                                monitor.progress(String.valueOf(validationPass.pass), "Passe "
                //                                        + (validationPass.pass + 1), null);
                //                            }
                // System.out.println("ITERATIVE_VALIDATION = " +
                // validationPass.pass+" : "+validationPass.fields+" :
                // "+keysToUpdate[r]);
                x += ValidateDefault(fields, entity.GetBuilder().IdToExpression(aKeysToUpdate, entity.GetName()));
            }
            //                        if (monitor != null) {
            //                            monitor.stepOut();
            //                        }
            return x;
        }

        protected internal virtual int ValidateDefault(System.Collections.Generic.ICollection<Net.Vpc.Upa.Field> fields, Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            // System.out.println("DEFAULT_VALIDATION = " +
            // validationPass.pass+" : "+ validationPass.fields);
            Net.Vpc.Upa.Record u = entity.GetBuilder().CreateRecord();
            foreach (Net.Vpc.Upa.Field field in fields) {
                Net.Vpc.Upa.Expressions.Expression fieldExpression = GetFieldExpression(field, onInsert);
                Net.Vpc.Upa.Expressions.Expression validExpression = fieldExpression;
                if (forceExpressionTypeCasting || (fieldExpression is Net.Vpc.Upa.Expressions.Literal && ((Net.Vpc.Upa.Expressions.Literal) fieldExpression).GetValue() == null)) {
                    validExpression = new Net.Vpc.Upa.Expressions.Cast(fieldExpression, field.GetDataType());
                }
                u.SetObject(field.GetName(), validExpression);
            }
            try {
                return entity.UpdateCore(u, expression, context);
            } catch (Net.Vpc.Upa.Exceptions.UPAException ex) {
                //            Log.bug(ex);
                Net.Vpc.Upa.Expressions.Select sb0 = new Net.Vpc.Upa.Expressions.Select();
                foreach (Net.Vpc.Upa.Field f in fields) {
                    Net.Vpc.Upa.Expressions.Expression fieldExpression = GetFieldExpression(f, onInsert);
                    sb0.Field(fieldExpression, f.GetName() + "Expression");
                    Net.Vpc.Upa.Expressions.Expression validExpression = fieldExpression;
                    if (forceExpressionTypeCasting || (fieldExpression is Net.Vpc.Upa.Expressions.Literal && ((Net.Vpc.Upa.Expressions.Literal) fieldExpression).GetValue() == null)) {
                        validExpression = new Net.Vpc.Upa.Expressions.Cast(fieldExpression, f.GetDataType());
                    }
                    sb0.Field(validExpression, f.GetName() + "CastExpression");
                }
                sb0.From(entity.GetName());
                sb0.SetWhere(expression);
                //            Log.bug("Values to update are : ");
                foreach (Net.Vpc.Upa.Record ur in entity.CreateQuery(sb0).GetRecordList()) {
                    foreach (System.Collections.Generic.KeyValuePair<string , object> entry in ur.ToMap()) {
                    }
                }
                //Log.bug(entry.getKey() + " : " + entry.getValue());
                throw ex;
            }
        }
    }
}
