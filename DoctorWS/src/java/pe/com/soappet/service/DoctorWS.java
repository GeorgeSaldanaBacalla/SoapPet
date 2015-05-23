/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.soappet.service;

import java.util.List;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import pe.com.soappet.dao.DoctorDAO;
import pe.com.soappet.dominio.Doctor;

/**
 *
 * @author Administrador
 */
@WebService(serviceName = "DoctorWS")
public class DoctorWS {


    /**
     * Web service operation
     */
    @WebMethod(operationName = "obtenerDoctor")
    public Doctor obtenerDoctor(@WebParam(name = "id") int id) {
        DoctorDAO doctorDao = new DoctorDAO();
        return doctorDao.obtenerDoctor(id);
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "listarDoctores")
    public List<Doctor> listarDoctores() {
        DoctorDAO doctorDao = new DoctorDAO();
        return doctorDao.listarDoctores();
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "guardarDoctor")
    public String guardarDoctor(@WebParam(name = "doctor") Doctor doctor) {
        DoctorDAO doctorDao = new DoctorDAO();
        doctorDao.registrarDoctor(doctor);
        return "Los datos se guardaron exitosamente";
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "eliminarDoctor")
    public String eliminarDoctor(@WebParam(name = "idDoctor") int idDoctor) {
        DoctorDAO doctorDao = new DoctorDAO();
        doctorDao.eliminarDoctor(idDoctor);
        return "Se elimino exitosamente";
    }

}
