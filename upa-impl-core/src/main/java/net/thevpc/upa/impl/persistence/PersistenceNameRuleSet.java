package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.*;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;

import net.thevpc.upa.impl.util.StringUtils;
import net.thevpc.upa.persistence.PersistenceNameStrategyCondition;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class PersistenceNameRuleSet {
    private List<PersistenceNameRule> rules = new ArrayList<>();
    public Map<String, List<PersistenceNameRule>> rulesByName = new HashMap<>();

    private String key(PersistenceNameRule r) {
        if (r instanceof ColumnPersistenceNameRule) {
            ColumnPersistenceNameRule cr = (ColumnPersistenceNameRule) r;
            if (StringUtils.isNullOrEmpty(cr.getEntityName())) {
                throw new IllegalUPAArgumentException("InvalidColumnPersistenceNameRule");
            }
            if (StringUtils.isNullOrEmpty(cr.getFieldName())) {
                throw new IllegalUPAArgumentException("InvalidColumnPersistenceNameRule");
            }
            return "ColumnPersistenceNameRule:" + cr.getEntityName() + ":" + cr.getFieldName();
        }
        if (r instanceof TablePersistenceNameRule) {
            TablePersistenceNameRule cr = (TablePersistenceNameRule) r;
            if (StringUtils.isNullOrEmpty(cr.getEntityName())) {
                throw new IllegalUPAArgumentException("InvalidColumnPersistenceNameRule");
            }
            return "TablePersistenceNameRule:" + cr.getEntityName();
        }
        if (r instanceof IndexPersistenceNameRule) {
            IndexPersistenceNameRule cr = (IndexPersistenceNameRule) r;
            if (StringUtils.isNullOrEmpty(cr.getEntityName())) {
                throw new IllegalUPAArgumentException("InvalidColumnPersistenceNameRule");
            }
            return "IndexPersistenceNameRule:" + cr.getEntityName() + ":" + cr.getIndexName();
        }
        if (r instanceof RelationshipPersistenceNameRule) {
            RelationshipPersistenceNameRule cr = (RelationshipPersistenceNameRule) r;
            if (StringUtils.isNullOrEmpty(cr.getRelationName())) {
                throw new IllegalUPAArgumentException("InvalidColumnPersistenceNameRule");
            }
            return "RelationshipPersistenceNameRule:" + cr.getRelationName();
        }
        return null;
    }

    public void addRule(PersistenceNameRule rule) {
        String key = key(rule);
        rules.remove(rule);
        List<PersistenceNameRule> found = rulesByName.get(key);
        if (found == null) {
            found = new ArrayList<>();
            rulesByName.put(key, found);
        }
        found.add(rule);
    }

    public void removeRule(PersistenceNameRule rule) {
        rules.remove(rule);
        List<PersistenceNameRule> found = rulesByName.get(key(rule));
        if (found != null) {
            found.remove(rule);
        }
    }

    private boolean acceptTableRule(PersistenceNameRule rule, PersistenceNameStrategyCondition condition) {
        return (condition.accept(rule.getDatabaseProduct(),rule.getDatabaseVersion(),rule.getStrategyName()));
    }

    public TablePersistenceNameRule getTableRule(String entityName, PersistenceNameStrategyCondition condition) {
        List<PersistenceNameRule> found = rulesByName.get("TablePersistenceNameRule:" + entityName);
        if (found != null) {
            for (PersistenceNameRule rule : found) {
                if (acceptTableRule(rule, condition)) {
                    return (TablePersistenceNameRule) rule;
                }
            }
        }
        return null;
    }

    public ColumnPersistenceNameRule getColumnRule(String entityName, String fieldName, PersistenceNameStrategyCondition condition) {
        List<PersistenceNameRule> found = rulesByName.get("ColumnPersistenceNameRule:" + entityName + ":" + fieldName);
        if (found != null) {
            for (PersistenceNameRule rule : found) {
                if (acceptTableRule(rule, condition)) {
                    return (ColumnPersistenceNameRule) rule;
                }
            }
        }
        return null;
    }

    public IndexPersistenceNameRule getIndexRule(String entityName, String indexName, PersistenceNameStrategyCondition condition) {
        List<PersistenceNameRule> found = rulesByName.get("IndexPersistenceNameRule:" + entityName + ":" + indexName);
        if (found != null) {
            for (PersistenceNameRule rule : found) {
                if (acceptTableRule(rule, condition)) {
                    return (IndexPersistenceNameRule) rule;
                }
            }
        }
        return null;
    }

    public RelationshipPersistenceNameRule getRelationshipRule(String relationName, PersistenceNameStrategyCondition condition) {
        List<PersistenceNameRule> found = rulesByName.get("RelationshipPersistenceNameRule:" + relationName);
        if (found != null) {
            for (PersistenceNameRule rule : found) {
                if (acceptTableRule(rule, condition)) {
                    return (RelationshipPersistenceNameRule) rule;
                }
            }
        }
        return null;
    }

    public PersistenceNameRule[] getRules() {
        return rules.toArray(new PersistenceNameRule[rules.size()]);
    }
}
