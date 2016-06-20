/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.vfs;

import net.vpc.upa.UserFieldModifier;
import net.vpc.upa.config.Entity;
import net.vpc.upa.config.Field;
import net.vpc.upa.config.Hierarchy;
import net.vpc.upa.config.Id;
import net.vpc.upa.config.ManyToOne;
import net.vpc.upa.config.Path;
import net.vpc.upa.types.DateTime;
import net.vpc.common.vfs.VFileType;

/**
 *
 * @author vpc
 */
@Entity
@Path("FileSystem")
public class FileEntry {

    @Id
    private Integer id;
    @Field(modifiers = UserFieldModifier.MAIN)
    private String name;
    private String path;
    @Field(modifiers = UserFieldModifier.SUMMARY)
    private String parentPath;
    @Field(modifiers = UserFieldModifier.SUMMARY)
    private VFileType type;
    @Hierarchy
    private FileEntry parent;
    @Field(modifiers = UserFieldModifier.SUMMARY)
    private long length;
    @Field(modifiers = UserFieldModifier.SUMMARY)
    private DateTime lastModifed;
    @ManyToOne(targetEntity = "FileContent")
    private Integer contentId;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPath() {
        return path;
    }

    public void setPath(String path) {
        this.path = path;
    }

    public String getParentPath() {
        return parentPath;
    }

    public void setParentPath(String parentPath) {
        this.parentPath = parentPath;
    }

    public VFileType getType() {
        return type;
    }

    public void setType(VFileType type) {
        this.type = type;
    }

    public FileEntry getParent() {
        return parent;
    }

    public void setParent(FileEntry parent) {
        this.parent = parent;
    }

    public long getLength() {
        return length;
    }

    public void setLength(long length) {
        this.length = length;
    }

    public DateTime getLastModifed() {
        return lastModifed;
    }

    public void setLastModifed(DateTime lastModifed) {
        this.lastModifed = lastModifed;
    }

    public Integer getContentId() {
        return contentId;
    }

    public void setContentId(Integer contentId) {
        this.contentId = contentId;
    }
    
}
