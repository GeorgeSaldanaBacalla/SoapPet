/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.soappet.dao;

import java.util.List;
import org.hibernate.Query;
import pe.com.soappet.dominio.Doctor;
import org.hibernate.SessionFactory;
import org.hibernate.Session;
import org.hibernate.Transaction;
/**
 *
 * @author Administrador
 */
public class DoctorDAO {
    public void registrarDoctor(Doctor doctor){
        SessionFactory sf = null;
        Session sesion = null;
        Transaction tx = null;
        
        try {
            sf = HibernateUtil.getSessionFactory();
            sesion = sf.openSession();
            tx = sesion.beginTransaction();
            sesion.saveOrUpdate(doctor);
            tx.commit();
            sesion.flush();
            sesion.close();
        } catch (Exception e) {
            tx.rollback();
            throw new RuntimeException("No se pudo guardar el doctor");
        }
    }
    
    public Doctor obtenerDoctor(int id){
        SessionFactory sf = HibernateUtil.getSessionFactory();
        Session sesion = sf.openSession();
        Doctor doc = (Doctor)sesion.get(Doctor.class,id);
        if(doc != null)
            return doc;
        else throw new RuntimeException("El doctor con id "+ id +" no existe");
    }
    
    public List<Doctor> listarDoctores(){
       SessionFactory sf = HibernateUtil.getSessionFactory();
        Session sesion = sf.openSession();
        Transaction tx = sesion.beginTransaction();
        Query q = sesion.createQuery("from Doctor as doc where doc.estado = 1");
        List<Doctor> lista = (List<Doctor>)q.list();
        
        return lista;
    }
    
    public void eliminarDoctor(int idDoctor){
        SessionFactory sf = null;
        Session sesion = null;
        Transaction tx = null;
        Doctor doctor = new Doctor();
        doctor.setIdDoctor(idDoctor);
        doctor.setEstado(0);
        try {
            sf = HibernateUtil.getSessionFactory();
            sesion = sf.openSession();
            tx = sesion.beginTransaction();
            sesion.update(doctor);
            tx.commit();
            sesion.flush();
            sesion.close();
        } catch (Exception e) {
            tx.rollback();
            throw new RuntimeException("No se pudo guardar el doctor");
        }
    }
}
