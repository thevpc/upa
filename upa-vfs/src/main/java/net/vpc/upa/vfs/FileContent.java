/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.vfs;

import net.vpc.upa.UserFieldModifier;
import net.vpc.upa.config.Entity;
import net.vpc.upa.config.Field;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.Path;

/**
 *
 * @author vpc
 */
@Entity
@Path("FileSystem")
public class FileContent {

    @Id
    @Field(modifiers = UserFieldModifier.MAIN)
    public Integer id;
    public byte[] content;
    @Field(modifiers = UserFieldModifier.SUMMARY)
    public long length;
    @Field(modifiers = UserFieldModifier.SUMMARY)
    public long lastModified;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public byte[] getContent() {
        return content;
    }

    public void setContent(byte[] content) {
        this.content = content;
    }

    public long getLength() {
        return length;
    }

    public void setLength(long length) {
        this.length = length;
    }

    public long getLastModified() {
        return lastModified;
    }

    public void setLastModified(long lastModified) {
        this.lastModified = lastModified;
    }

}
