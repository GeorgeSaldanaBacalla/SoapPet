/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.managed;

import java.io.IOException;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
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
@ManagedBean(name="listadoDoctoresManaged")
@ViewScoped
public class ListadoDoctoresManaged implements Serializable{
    private List<Doctor> listaDoctores = new ArrayList<>();
    
    
    @PostConstruct
    public void init(){
        //listarDoctores();
    }
    
    public ListadoDoctoresManaged(){
        listarDoctores();
    }

    /**
     * @return the listaDoctores
     */
    public List<Doctor> getListaDoctores() {
        return listaDoctores;
    }

    /**
     * @param listaDoctores the listaDoctores to set
     */
    public void setListaDoctores(List<Doctor> listaDoctores) {
        this.listaDoctores = listaDoctores;
    }

    public  void listarDoctores() {
        pe.com.soappet.service.DoctorWS_Service service = new pe.com.soappet.service.DoctorWS_Service();
        pe.com.soappet.service.DoctorWS port = service.getDoctorWSPort();
        listaDoctores = port.listarDoctores();
    }
    
    public void eliminar(int idDoctor){
        eliminarDoctor(idDoctor);
        String mensaje="Se eliminó correctamente";
        listarDoctores();
        FacesContext.getCurrentInstance().addMessage(null, new FacesMessage(FacesMessage.SEVERITY_INFO, mensaje, null));
    }

    private void eliminarDoctor(int idDoctor) {
        pe.com.soappet.service.DoctorWS_Service service = new pe.com.soappet.service.DoctorWS_Service();
        pe.com.soappet.service.DoctorWS port = service.getDoctorWSPort();
        port.eliminarDoctor(idDoctor);
    }
    
    public void editar(int idDoctor){
        try {
             HttpSession s = (HttpSession) FacesContext.getCurrentInstance().getExternalContext().getSession(false);
            s.setAttribute("idDoctor",idDoctor);
            FacesContext.getCurrentInstance().getExternalContext().redirect("doctorForm.xhtml");
        } catch (IOException ex) {
            Logger.getLogger(ListadoDoctoresManaged.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
