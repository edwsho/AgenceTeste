import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Consultores } from '../Models/consultores'

@Injectable({
  providedIn: 'root'
})
export class ConsultoresService {

  private baseUrlPublishBackEnd = environment.baseUrlPublishBackEnd;
  private baseUrl = environment.baseUrl;
  public list : Consultores[]; 

  constructor(private http: HttpClient) { }


  async getAllConsultores() : Promise<any>{
     
    //  --------------------------------------------- Cambiar de Falg al desplegar----------------------------- a baseUrlPublishBackEnd
    let response = await this.http.get(this.baseUrlPublishBackEnd + "/api/Consultores/GetUsers").toPromise();

    let arrayConsultores = []

    for (var consultores in response) {
      
      arrayConsultores.push(response[consultores].userName);
  }

  return arrayConsultores;
    
    
  }


  async getReceitasConsultores(allConsultores : Consultores[], desde : any, hasta : any) : Promise<any>{
    //debugger
    console.log(allConsultores);
    console.log("LLegue");
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin':'*',
        "Access-Control-Allow-Methods": "*"
      })
    };
    
    // let response = await this.http.post(this.baseUrl + "api/Tarjeta/GetReceitasUser", allConsultores)
    // .subscribe((response: any) =>{
    //   debugger
    //         if(response){
      
    //            //do something
    //            console.log(response);
      
    //         }
    //   });

    let response = await this.http.post(this.baseUrlPublishBackEnd + "/api/Consultores/GetReceitasUser", allConsultores).toPromise()
    console.log(response);
    return response;
  }

}
