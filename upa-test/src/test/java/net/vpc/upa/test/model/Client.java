package net.vpc.upa.test.model;

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
@Entity(path = "Test Modules/Model")
public class Client {
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
    private ClientType clientType;

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

    public ClientType getClientType() {
        return clientType;
    }

    public void setClientType(ClientType clientType) {
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
    

    /**
     * This function is provided only for test purposes the compare expected and found values
     * {@inheritDoc}
     */
    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Client client = (Client) o;

        if (id != client.id) return false;
        if (firstName != null ? !firstName.equals(client.firstName) : client.firstName != null) return false;
        if (lastName != null ? !lastName.equals(client.lastName) : client.lastName != null) return false;

        return true;
    }

    /**
     * This function is provided only for test purposes the compare expected and found values
     * {@inheritDoc}
     */
    @Override
    public int hashCode() {
        int result = id;
        result = 31 * result + (firstName != null ? firstName.hashCode() : 0);
        return result;
    }
}
