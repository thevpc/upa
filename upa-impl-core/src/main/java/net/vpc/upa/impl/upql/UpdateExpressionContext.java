/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql;

import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author vpc
 */
public class UpdateExpressionContext {

    private Map<String, Object> cache = new HashMap<>();
    private Map<String, Object> hints = new HashMap<>();

    public Map<String, Object> getCache() {
        return cache;
    }

    public void setCache(Map<String, Object> cache) {
        this.cache = cache;
    }

    public Map<String, Object> getHints() {
        return hints;
    }

    public void setHints(Map<String, Object> hints) {
        this.hints = hints;
    }

    public UpdateExpressionContext copy() {
        UpdateExpressionContext cc = new UpdateExpressionContext();
        cc.cache.putAll(cache);
        cc.hints.putAll(hints);
        return cc;
    }
}
