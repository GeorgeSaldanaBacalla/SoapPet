
package pe.com.soappet.service;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the pe.com.soappet.service package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _EliminarDoctor_QNAME = new QName("http://service.soappet.com.pe/", "eliminarDoctor");
    private final static QName _ListarDoctores_QNAME = new QName("http://service.soappet.com.pe/", "listarDoctores");
    private final static QName _GuardarDoctor_QNAME = new QName("http://service.soappet.com.pe/", "guardarDoctor");
    private final static QName _ListarDoctoresResponse_QNAME = new QName("http://service.soappet.com.pe/", "listarDoctoresResponse");
    private final static QName _ObtenerDoctor_QNAME = new QName("http://service.soappet.com.pe/", "obtenerDoctor");
    private final static QName _ObtenerDoctorResponse_QNAME = new QName("http://service.soappet.com.pe/", "obtenerDoctorResponse");
    private final static QName _GuardarDoctorResponse_QNAME = new QName("http://service.soappet.com.pe/", "guardarDoctorResponse");
    private final static QName _EliminarDoctorResponse_QNAME = new QName("http://service.soappet.com.pe/", "eliminarDoctorResponse");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: pe.com.soappet.service
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link EliminarDoctor }
     * 
     */
    public EliminarDoctor createEliminarDoctor() {
        return new EliminarDoctor();
    }

    /**
     * Create an instance of {@link GuardarDoctor }
     * 
     */
    public GuardarDoctor createGuardarDoctor() {
        return new GuardarDoctor();
    }

    /**
     * Create an instance of {@link ListarDoctores }
     * 
     */
    public ListarDoctores createListarDoctores() {
        return new ListarDoctores();
    }

    /**
     * Create an instance of {@link EliminarDoctorResponse }
     * 
     */
    public EliminarDoctorResponse createEliminarDoctorResponse() {
        return new EliminarDoctorResponse();
    }

    /**
     * Create an instance of {@link ListarDoctoresResponse }
     * 
     */
    public ListarDoctoresResponse createListarDoctoresResponse() {
        return new ListarDoctoresResponse();
    }

    /**
     * Create an instance of {@link GuardarDoctorResponse }
     * 
     */
    public GuardarDoctorResponse createGuardarDoctorResponse() {
        return new GuardarDoctorResponse();
    }

    /**
     * Create an instance of {@link ObtenerDoctorResponse }
     * 
     */
    public ObtenerDoctorResponse createObtenerDoctorResponse() {
        return new ObtenerDoctorResponse();
    }

    /**
     * Create an instance of {@link ObtenerDoctor }
     * 
     */
    public ObtenerDoctor createObtenerDoctor() {
        return new ObtenerDoctor();
    }

    /**
     * Create an instance of {@link Doctor }
     * 
     */
    public Doctor createDoctor() {
        return new Doctor();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link EliminarDoctor }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://service.soappet.com.pe/", name = "eliminarDoctor")
    public JAXBElement<EliminarDoctor> createEliminarDoctor(EliminarDoctor value) {
        return new JAXBElement<EliminarDoctor>(_EliminarDoctor_QNAME, EliminarDoctor.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ListarDoctores }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://service.soappet.com.pe/", name = "listarDoctores")
    public JAXBElement<ListarDoctores> createListarDoctores(ListarDoctores value) {
        return new JAXBElement<ListarDoctores>(_ListarDoctores_QNAME, ListarDoctores.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link GuardarDoctor }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://service.soappet.com.pe/", name = "guardarDoctor")
    public JAXBElement<GuardarDoctor> createGuardarDoctor(GuardarDoctor value) {
        return new JAXBElement<GuardarDoctor>(_GuardarDoctor_QNAME, GuardarDoctor.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ListarDoctoresResponse }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://service.soappet.com.pe/", name = "listarDoctoresResponse")
    public JAXBElement<ListarDoctoresResponse> createListarDoctoresResponse(ListarDoctoresResponse value) {
        return new JAXBElement<ListarDoctoresResponse>(_ListarDoctoresResponse_QNAME, ListarDoctoresResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ObtenerDoctor }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://service.soappet.com.pe/", name = "obtenerDoctor")
    public JAXBElement<ObtenerDoctor> createObtenerDoctor(ObtenerDoctor value) {
        return new JAXBElement<ObtenerDoctor>(_ObtenerDoctor_QNAME, ObtenerDoctor.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ObtenerDoctorResponse }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://service.soappet.com.pe/", name = "obtenerDoctorResponse")
    public JAXBElement<ObtenerDoctorResponse> createObtenerDoctorResponse(ObtenerDoctorResponse value) {
        return new JAXBElement<ObtenerDoctorResponse>(_ObtenerDoctorResponse_QNAME, ObtenerDoctorResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link GuardarDoctorResponse }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://service.soappet.com.pe/", name = "guardarDoctorResponse")
    public JAXBElement<GuardarDoctorResponse> createGuardarDoctorResponse(GuardarDoctorResponse value) {
        return new JAXBElement<GuardarDoctorResponse>(_GuardarDoctorResponse_QNAME, GuardarDoctorResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link EliminarDoctorResponse }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://service.soappet.com.pe/", name = "eliminarDoctorResponse")
    public JAXBElement<EliminarDoctorResponse> createEliminarDoctorResponse(EliminarDoctorResponse value) {
        return new JAXBElement<EliminarDoctorResponse>(_EliminarDoctorResponse_QNAME, EliminarDoctorResponse.class, null, value);
    }

}
