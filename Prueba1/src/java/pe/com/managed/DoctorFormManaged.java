/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.managed;

import java.io.IOException;
import java.io.Serializable;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.context.FacesContext;
import pe.com.soappet.service.Doctor;

/**
 *
 * @author Administrador
 */
@ManagedBean(name = "doctorForm")
public class DoctorFormManaged implements Serializable {

    private Doctor doctor = new Doctor();

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
        doctor.setEstado(1);
        String mensaje = port.guardarDoctor(doctor);
        FacesContext.getCurrentInstance().addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, mensaje, null));
        return null;
    }

    public void ver(int idDoctor){
        try {
            doctor = obtenerDoctor(idDoctor);
            FacesContext.getCurrentInstance().getExternalContext().redirect("doctorForm.xhtml");
        } catch (IOException ex) {
            Logger.getLogger(DoctorFormManaged.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private  Doctor obtenerDoctor(int id) {
        pe.com.soappet.service.DoctorWS_Service service = new pe.com.soappet.service.DoctorWS_Service();
        pe.com.soappet.service.DoctorWS port = service.getDoctorWSPort();
        return port.obtenerDoctor(id);
    }
}
