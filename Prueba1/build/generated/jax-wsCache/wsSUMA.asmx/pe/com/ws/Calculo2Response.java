
package pe.com.ws;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Clase Java para anonymous complex type.
 * 
 * <p>El siguiente fragmento de esquema especifica el contenido que se espera que haya en esta clase.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="Calculo2Result" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "calculo2Result"
})
@XmlRootElement(name = "Calculo2Response")
public class Calculo2Response {

    @XmlElement(name = "Calculo2Result")
    protected String calculo2Result;

    /**
     * Obtiene el valor de la propiedad calculo2Result.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getCalculo2Result() {
        return calculo2Result;
    }

    /**
     * Define el valor de la propiedad calculo2Result.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCalculo2Result(String value) {
        this.calculo2Result = value;
    }

}
