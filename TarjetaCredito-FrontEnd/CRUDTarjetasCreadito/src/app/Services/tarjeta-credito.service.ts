import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Tarjeta } from '../Models/tarjeta'

@Injectable({
  providedIn: 'root'
})
export class TarjetaCreditoService {

  private baseUrl =environment.baseUrl;
  public list : Tarjeta[]; 

  //Establezco variable para el envio de informacion de un componente a otro (Lista-tarjetas-credito a CreditCard)
  private _sendInformation = new BehaviorSubject<Tarjeta>({} as any); 

  constructor(private http: HttpClient) { }

  GuardarTarjeta(tarjeta : Tarjeta) :Observable<Tarjeta>{
    return this.http.post( this.baseUrl + "api/Tarjeta/PostTarjetas", tarjeta);
  }


  // getAllTarjetas() :Observable<Tarjeta>{
  //   return this.http.get( this.baseUrl + "api/Tarjeta/GetTarjetas");
  // }

  getAllTarjetas(){
    this.http.get(this.baseUrl + "api/Tarjeta/GetTarjetas").toPromise()
                                                          .then( data => {
                                                              this.list = data as Tarjeta[];
                                                          })
  }

  eliminarTarjeta(id : Tarjeta) : Observable<Tarjeta>{
    console.log(id);
    return this.http.put( this.baseUrl + "api/Tarjeta/Delete", id);
  }

  modificarTarjeta(id : number, modifTarjeta : Tarjeta) : Observable<Tarjeta>{
    return this.http.put( this.baseUrl + "api/Tarjeta/" + id, modifTarjeta);
  }


  envioInfEntreComponentes(tarjeta){
      this._sendInformation.next(tarjeta);
  }

  reciboTarjeta() : Observable<Tarjeta>{

    return this._sendInformation.asObservable();

  }


}
