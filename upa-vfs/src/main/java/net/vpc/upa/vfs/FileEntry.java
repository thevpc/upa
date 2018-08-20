/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.vfs;

import net.vpc.upa.config.*;
import net.vpc.upa.types.DateTime;
import net.vpc.common.vfs.VFileType;

/**
 *
 * @author taha.bensalah@gmail.com
 */
@Entity
@Path("FileSystem")
public class FileEntry {

    @Id
    private Integer id;
    @Main
    private String name;
    private String path;
    @Summary
    private String parentPath;
    @Summary
    private VFileType fileType;
    @Hierarchy
    private FileEntry parent;
    @Summary
    private long length;
    @Summary
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

    public VFileType getFileType() {
        return fileType;
    }

    public void setFileType(VFileType fileType) {
        this.fileType = fileType;
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
