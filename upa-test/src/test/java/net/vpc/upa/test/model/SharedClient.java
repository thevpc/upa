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
     * uql keyword
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
                "id=" + id +
                ", firstName='" + firstName + '\'' +
                ", lastName='" + lastName + '\'' +
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

        if (id != client.id) return false;
        if (firstName != null ? !firstName.equals(client.firstName) : client.firstName != null) return false;
        if (lastName != null ? !lastName.equals(client.lastName) : client.lastName != null) return false;
        if (birthDate != null ? !birthDate.equals(client.birthDate) : client.birthDate != null) return false;
        if (timestampValue != null ? !timestampValue.equals(client.timestampValue) : client.timestampValue != null)
            return false;
        if (dateTimeValue != null ? !dateTimeValue.equals(client.dateTimeValue) : client.dateTimeValue != null)
            return false;
        if (dateOnlyValue != null ? !dateOnlyValue.equals(client.dateOnlyValue) : client.dateOnlyValue != null)
            return false;
        if (monthValue != null ? !monthValue.equals(client.monthValue) : client.monthValue != null) return false;
        if (integerValue != null ? !integerValue.equals(client.integerValue) : client.integerValue != null)
            return false;
        if (longValue != null ? !longValue.equals(client.longValue) : client.longValue != null) return false;
        if (clientType != client.clientType) return false;
        return !(right != null ? !right.equals(client.right) : client.right != null);

    }

    @Override
    public int hashCode() {
        int result = id;
        result = 31 * result + (firstName != null ? firstName.hashCode() : 0);
        result = 31 * result + (lastName != null ? lastName.hashCode() : 0);
        result = 31 * result + (birthDate != null ? birthDate.hashCode() : 0);
        result = 31 * result + (timestampValue != null ? timestampValue.hashCode() : 0);
        result = 31 * result + (dateTimeValue != null ? dateTimeValue.hashCode() : 0);
        result = 31 * result + (dateOnlyValue != null ? dateOnlyValue.hashCode() : 0);
        result = 31 * result + (monthValue != null ? monthValue.hashCode() : 0);
        result = 31 * result + (integerValue != null ? integerValue.hashCode() : 0);
        result = 31 * result + (longValue != null ? longValue.hashCode() : 0);
        result = 31 * result + (clientType != null ? clientType.hashCode() : 0);
        result = 31 * result + (right != null ? right.hashCode() : 0);
        return result;
    }
}
