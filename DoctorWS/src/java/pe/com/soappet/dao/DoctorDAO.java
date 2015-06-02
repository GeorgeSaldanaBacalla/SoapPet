/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.soappet.dao;

import java.math.BigInteger;
import java.util.ArrayList;
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

    public DoctorDAO() {
       /* Doctor doc = new Doctor();
        doc.setNombre("prueba");
        doc.setApePaterno("apePrueba");
        doc.setApeMaterno("apePrueba");
        Doctor das = registrarDoctor(doc);
        System.out.println(das.getIdDoctor());*/
        Doctor doc = obtenerDoctor(4);
        System.out.println("id "+doc.getIdDoctor());
        
    }

    public static void main(String[] args) {
        new DoctorDAO();
    }

    public Doctor registrarDoctor(Doctor doctor) {
        SessionFactory sf = null;
        Session sesion = null;
        Transaction tx = null;
        Doctor doc = null;
        try {
            sf = HibernateUtil.getSessionFactory();
            sesion = sf.openSession();
            tx = sesion.beginTransaction();
            sesion.saveOrUpdate(doctor);
            tx.commit();
            int lastId = ((BigInteger) sesion.createSQLQuery("SELECT LAST_INSERT_ID()").uniqueResult()).intValue();
            sesion.flush();
            doc = (Doctor) sesion.get(Doctor.class,lastId);
        } catch (Exception e) {
            e.printStackTrace();
            tx.rollback();
            throw new RuntimeException("No se pudo guardar el doctor");
        } finally {
            sesion.close();
            //sf.close();
        }
        return doc;
    }

    public Doctor obtenerDoctor(int id) {
        SessionFactory sf = null;
        Session sesion = null;
        Doctor doc = null;
        try {
            sf = HibernateUtil.getSessionFactory();
            sesion = sf.openSession();
            doc = (Doctor) sesion.get(Doctor.class, id);
            if (doc != null) {
                return doc;
            } else {
                throw new Exception();
            }
        } catch (Exception e) {
            throw new RuntimeException("El doctor con id " + id + " no existe");
        } finally {
            sesion.close();
             //sf.close();
        }

    }

    public List<Doctor> listarDoctores() {
        SessionFactory sf = HibernateUtil.getSessionFactory();
        Session sesion = sf.openSession();
        Transaction tx = sesion.beginTransaction();
        List<Doctor> lista = new ArrayList<>();
        try {
            sf = HibernateUtil.getSessionFactory();
            sesion = sf.openSession();
            tx = sesion.beginTransaction();
            Query q = sesion.createQuery("from Doctor as doc where doc.estado = 1");
            lista = (List<Doctor>) q.list();
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        } finally {
            sesion.close();
            //sf.close();
        }
        return lista;
    }

    public void eliminarDoctor(int idDoctor) {
        SessionFactory sf = null;
        Session sesion = null;
        Transaction tx2 = null;
        try {
            sf = HibernateUtil.getSessionFactory();
            sesion = sf.openSession();
            
            Doctor doctor = (Doctor)   sesion.load(Doctor.class, idDoctor);
          
             tx2 = sesion.beginTransaction();
            doctor.setEstado(0);
            sesion.update(doctor);
            tx2.commit();
            
            sesion.flush();

        } catch (Exception e) {
            tx2.rollback();
            throw new RuntimeException("No se pudo guardar el doctor");
        } finally{
            sesion.close();
            //sf.close();
        }
    }
}
