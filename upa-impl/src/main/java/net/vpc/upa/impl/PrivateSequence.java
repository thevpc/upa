/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.types.DateTime;
import net.vpc.upa.EntityModifier;
import net.vpc.upa.config.Entity;
import net.vpc.upa.config.Field;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Ignore;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@Entity(name = PrivateSequence.ENTITY_NAME, modifiers= EntityModifier.SYSTEM)
@Ignore
public class PrivateSequence {
    public static final String ENTITY_NAME = "PrivateSequence";

    @Id
    @Field(max = "4000")
    private String name;

    @Id
    @Field(max = "4000")
    private String group;

    private boolean locked;

    private DateTime lockDate;

    @Field(max = "128")
    private String lockUserId;

    private int value;

    private int increment;

    public String getGroup() {
        return group;
    }

    public void setGroup(String group) {
        this.group = group;
    }

    public boolean isLocked() {
        return locked;
    }

    public void setLocked(boolean locked) {
        this.locked = locked;
    }

    public DateTime getLockDate() {
        return lockDate;
    }

    public void setLockDate(DateTime lockDate) {
        this.lockDate = lockDate;
    }

    public String getLockUserId() {
        return lockUserId;
    }

    public void setLockUserId(String lockUserId) {
        this.lockUserId = lockUserId;
    }

    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
    }

    public int getIncrement() {
        return increment;
    }

    public void setIncrement(int increment) {
        this.increment = increment;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
