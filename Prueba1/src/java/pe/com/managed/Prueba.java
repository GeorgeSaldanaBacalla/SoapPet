/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.managed;

import pe.com.ws.Calculo2;
import pe.com.ws.ObjectFactory;
import pe.com.ws.WSSUMA;
import pe.com.ws.WSSUMASoap;

/**
 *
 * @author Administrador
 */
public class Prueba {
    public Prueba(){
        ObjectFactory o = new ObjectFactory();
        Calculo2 cal = o.createCalculo2();
        cal.setA(1);
        cal.setA(2);
        
        WSSUMA service = new WSSUMA();
        String s = service.getWSSUMASoap().calculo2(1, 2);
        System.out.println(s);
    }
    
    public static void main(String[] args) {
        new Prueba();
    }
}
