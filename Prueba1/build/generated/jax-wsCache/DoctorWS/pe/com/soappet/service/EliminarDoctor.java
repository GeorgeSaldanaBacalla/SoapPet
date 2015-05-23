
package pe.com.soappet.service;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Clase Java para eliminarDoctor complex type.
 * 
 * <p>El siguiente fragmento de esquema especifica el contenido que se espera que haya en esta clase.
 * 
 * <pre>
 * &lt;complexType name="eliminarDoctor">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="idDoctor" type="{http://www.w3.org/2001/XMLSchema}int"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "eliminarDoctor", propOrder = {
    "idDoctor"
})
public class EliminarDoctor {

    protected int idDoctor;

    /**
     * Obtiene el valor de la propiedad idDoctor.
     * 
     */
    public int getIdDoctor() {
        return idDoctor;
    }

    /**
     * Define el valor de la propiedad idDoctor.
     * 
     */
    public void setIdDoctor(int value) {
        this.idDoctor = value;
    }

}
