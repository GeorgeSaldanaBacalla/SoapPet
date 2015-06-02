/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.managed;

import java.io.Serializable;
import javax.annotation.PostConstruct;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;
import javax.faces.context.FacesContext;
import javax.servlet.http.HttpSession;
import pe.com.soappet.service.Doctor;

/**
 *
 * @author Administrador
 */
@ManagedBean(name = "doctorForm")
@ViewScoped
public class DoctorFormManaged implements Serializable {

    private Doctor doctor = new Doctor();

    @PostConstruct
    public void init() {
        HttpSession s = (HttpSession) FacesContext.getCurrentInstance().getExternalContext().getSession(false);
        Integer id =(Integer)s.getAttribute("idDoctor");
        s.removeAttribute("idDoctor");
        if (id != null) {
            ver(id);
        }
    }

    /**
     * @return the doctor
     */
    public Doctor getDoctor() {
        return doctor;
    }

    /**
     * @param doctor the doctor to set
     */
    public void setDoctor(Doctor doctor) {
        this.doctor = doctor;
    }

    public String guardarDoctor() {
        pe.com.soappet.service.DoctorWS_Service service = new pe.com.soappet.service.DoctorWS_Service();
        pe.com.soappet.service.DoctorWS port = service.getDoctorWSPort();
        Doctor doctorRegistrado = port.guardarDoctor(doctor);
        String mensaje = "Se guardaron los datos correctamente";
        FacesContext.getCurrentInstance().addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, mensaje, null));
        return null;
    }

    private void ver(int idDoctor) {

        doctor = obtenerDoctor(idDoctor);

    }

    private Doctor obtenerDoctor(int id) {
        pe.com.soappet.service.DoctorWS_Service service = new pe.com.soappet.service.DoctorWS_Service();
        pe.com.soappet.service.DoctorWS port = service.getDoctorWSPort();
        return port.obtenerDoctor(id);
    }
}
