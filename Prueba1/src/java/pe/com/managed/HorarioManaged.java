/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.managed;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;

/**
 *
 * @author Administrador
 */
@ManagedBean(name="horarioManaged")
@ViewScoped
public class HorarioManaged implements Serializable{
    private List<String> listaSemanas = new ArrayList<String>();

    public HorarioManaged(){
        listaSemanas.add("del 4/05 al 10/05");
        listaSemanas.add("del 11/05 al 17/05");
        listaSemanas.add("del 18/05 al 24/05");
    }
    /**
     * @return the listaSemanas
     */
    public List<String> getListaSemanas() {
        return listaSemanas;
    }

    /**
     * @param listaSemanas the listaSemanas to set
     */
    public void setListaSemanas(List<String> listaSemanas) {
        this.listaSemanas = listaSemanas;
    }
}
