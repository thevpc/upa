package net.vpc.upa.test.model;

import net.vpc.upa.EntityModifier;
import net.vpc.upa.types.Date;
import net.vpc.upa.types.DateTime;
import net.vpc.upa.types.Month;
import net.vpc.upa.config.Entity;
import net.vpc.upa.config.Id;

import java.sql.Timestamp;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/16/12 10:03 PM
 */
@Entity(path = "Test Modules/Model",modifiers = EntityModifier.CLEAR)
public class SharedClient {
    @Id
    private int id;
    private String firstName;
    private String lastName;
    private java.util.Date birthDate;
    private Timestamp timestampValue;
    private DateTime dateTimeValue;
    private Date dateOnlyValue;
    private Month monthValue;
    private Integer integerValue;
    private Long longValue;
    private SharedClientType clientType;
    /**
     * UPQL keyword
     */
    private String right;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public java.util.Date getBirthDate() {
        return birthDate;
    }

    public void setBirthDate(java.util.Date dateValue) {
        this.birthDate = dateValue;
    }

    public Timestamp getTimestampValue() {
        return timestampValue;
    }

    public void setTimestampValue(Timestamp timestampValue) {
        this.timestampValue = timestampValue;
    }

    public DateTime getDateTimeValue() {
        return dateTimeValue;
    }

    public void setDateTimeValue(DateTime dateTimeValue) {
        this.dateTimeValue = dateTimeValue;
    }

    public Date getDateOnlyValue() {
        return dateOnlyValue;
    }

    public void setDateOnlyValue(Date dateOnlyValue) {
        this.dateOnlyValue = dateOnlyValue;
    }

    public Month getMonthValue() {
        return monthValue;
    }

    public void setMonthValue(Month monthValue) {
        this.monthValue = monthValue;
    }

    public Integer getIntegerValue() {
        return integerValue;
    }

    public void setIntegerValue(Integer integerValue) {
        this.integerValue = integerValue;
    }

    public Long getLongValue() {
        return longValue;
    }

    public void setLongValue(Long longValue) {
        this.longValue = longValue;
    }

    public SharedClientType getClientType() {
        return clientType;
    }

    public void setClientType(SharedClientType clientType) {
        this.clientType = clientType;
    }
    
    

    @Override
    public String toString() {
        return "Client{" +
                "id=" + getId() +
                ", firstName='" + getFirstName() + '\'' +
                ", lastName='" + getLastName() + '\'' +
                '}';
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getRight() {
        return right;
    }

    public void setRight(String right) {
        this.right = right;
    }

    public SharedClient compact(){
        SharedClient client = new SharedClient();
        client.setId(getId());
        client.setFirstName(getFirstName());
        client.setLastName(getLastName());
        return client;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof SharedClient)) return false;

        SharedClient client = (SharedClient) o;

        if (getId() != client.getId()) return false;
        if (getFirstName() != null ? !getFirstName().equals(client.getFirstName()) : client.getFirstName() != null) return false;
        if (getLastName() != null ? !getLastName().equals(client.getLastName()) : client.getLastName() != null) return false;
        if (getBirthDate() != null ? !getBirthDate().equals(client.getBirthDate()) : client.getBirthDate() != null) return false;
        if (getTimestampValue() != null ? !getTimestampValue().equals(client.getTimestampValue()) : client.getTimestampValue() != null)
            return false;
        if (getDateTimeValue() != null ? !getDateTimeValue().equals(client.getDateTimeValue()) : client.getDateTimeValue() != null)
            return false;
        if (getDateOnlyValue() != null ? !getDateOnlyValue().equals(client.getDateOnlyValue()) : client.getDateOnlyValue() != null)
            return false;
        if (getMonthValue() != null ? !getMonthValue().equals(client.getMonthValue()) : client.getMonthValue() != null) return false;
        if (getIntegerValue() != null ? !getIntegerValue().equals(client.getIntegerValue()) : client.getIntegerValue() != null)
            return false;
        if (getLongValue() != null ? !getLongValue().equals(client.getLongValue()) : client.getLongValue() != null) return false;
        if (getClientType() != client.getClientType()) return false;
        return !(getRight() != null ? !getRight().equals(client.getRight()) : client.getRight() != null);

    }

    @Override
    public int hashCode() {
        int result = id;
        result = 31 * result + (getFirstName() != null ? getFirstName().hashCode() : 0);
        result = 31 * result + (getLastName() != null ? getLastName().hashCode() : 0);
        result = 31 * result + (getBirthDate() != null ? getBirthDate().hashCode() : 0);
        result = 31 * result + (getTimestampValue() != null ? getTimestampValue().hashCode() : 0);
        result = 31 * result + (getDateTimeValue() != null ? getDateTimeValue().hashCode() : 0);
        result = 31 * result + (getDateOnlyValue() != null ? getDateOnlyValue().hashCode() : 0);
        result = 31 * result + (getMonthValue() != null ? getMonthValue().hashCode() : 0);
        result = 31 * result + (getIntegerValue() != null ? getIntegerValue().hashCode() : 0);
        result = 31 * result + (getLongValue() != null ? getLongValue().hashCode() : 0);
        result = 31 * result + (getClientType() != null ? getClientType().hashCode() : 0);
        result = 31 * result + (getRight() != null ? getRight().hashCode() : 0);
        return result;
    }
}
